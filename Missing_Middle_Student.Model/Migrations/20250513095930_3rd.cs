using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Missing_Middle_Student.Model.Migrations
{
    /// <inheritdoc />
    public partial class _3rd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantID",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DeviceID",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Technician_DeviceID",
                table: "Staffs");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffNumbeer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Income = table.Column<double>(type: "float", nullable: false),
                    Reccomendation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportingDoc = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Accademic_record = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Devices");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantID",
                table: "Staffs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceID",
                table: "Staffs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Staffs",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Technician_DeviceID",
                table: "Staffs",
                type: "int",
                nullable: true);
        }
    }
}
