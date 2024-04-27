using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReqSense.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLastEditorToRequirement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Requirements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Requirements",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_LastModifiedBy",
                table: "Requirements",
                column: "LastModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_AspNetUsers_LastModifiedBy",
                table: "Requirements",
                column: "LastModifiedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_AspNetUsers_LastModifiedBy",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Requirements_LastModifiedBy",
                table: "Requirements");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Requirements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Requirements",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);
        }
    }
}
