using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReqSense.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserIdFromProjectMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectsMembers",
                table: "ProjectsMembers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsMembers_MemberId",
                table: "ProjectsMembers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProjectsMembers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectsMembers",
                table: "ProjectsMembers",
                columns: new[] { "MemberId", "ProjectId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectsMembers",
                table: "ProjectsMembers");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ProjectsMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectsMembers",
                table: "ProjectsMembers",
                columns: new[] { "UserId", "ProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsMembers_MemberId",
                table: "ProjectsMembers",
                column: "MemberId");
        }
    }
}
