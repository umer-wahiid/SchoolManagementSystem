using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Users",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Teachers",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Subjects",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "SubjectResults",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Students",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Roles",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Results",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Enrollments",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Classes",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Attendances",
                newName: "ModifiedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Subjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SubjectResults",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Results",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Enrollments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Classes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Attendances",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SubjectResults");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Users",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Teachers",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Subjects",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "SubjectResults",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Students",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Roles",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Results",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Enrollments",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Classes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Attendances",
                newName: "ModifiedDate");
        }
    }
}
