using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReqSense.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIndicesToProjectAndRequirement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_AspNetUsers_CreatedBy",
                table: "Requirements");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Requirements",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Requirements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_Title",
                table: "Requirements",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Title",
                table: "Projects",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_AspNetUsers_CreatedBy",
                table: "Requirements",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_AspNetUsers_CreatedBy",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Requirements_Title",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Projects_Title",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Requirements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Requirements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_AspNetUsers_CreatedBy",
                table: "Requirements",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
