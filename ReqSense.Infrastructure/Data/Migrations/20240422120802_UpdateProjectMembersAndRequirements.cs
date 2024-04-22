using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReqSense.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectMembersAndRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Requirements");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Requirements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "JoinedDate",
                table: "ProjectsMembers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_CreatedBy",
                table: "Requirements",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_ProjectId",
                table: "Requirements",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_AspNetUsers_CreatedBy",
                table: "Requirements",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Projects_ProjectId",
                table: "Requirements",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_AspNetUsers_CreatedBy",
                table: "Requirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Projects_ProjectId",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Requirements_CreatedBy",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Requirements_ProjectId",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "JoinedDate",
                table: "ProjectsMembers");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Requirements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Requirements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
