using ReqSense.API.Extensions;
using ReqSense.API.Middlewares;
using ReqSense.API.Services;
using ReqSense.Application;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Infrastructure;

const string angularClientPolicyName = "angular-front";
const string secretsVariableName = "REQSENSE_SECRETS_PATH";

var builder = WebApplication.CreateBuilder(args);
var secretsPath = Environment.GetEnvironmentVariable(secretsVariableName);
if (secretsPath is null)
{
    throw new Exception("Secrets file location was not provided." +
                        $"Use '{secretsVariableName}' environment variable to specify the file.");
}

builder.Configuration.AddJsonFile(secretsPath);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.ConfigureCors(angularClientPolicyName, builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.ConfigureCookies();

builder.Services.AddScoped<ICurrentUser, CurrentUser>();

var app = builder.Build();
app.UseExceptionHandler(_ => { });

await app.InitialiseDatabaseAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(angularClientPolicyName);
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();