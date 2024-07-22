using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReqSense.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixRequirementUniqueKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requirements_Title",
                table: "Requirements");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_Title_ProjectId",
                table: "Requirements",
                columns: new[] { "Title", "ProjectId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requirements_Title_ProjectId",
                table: "Requirements");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_Title",
                table: "Requirements",
                column: "Title",
                unique: true);
        }
    }
}
