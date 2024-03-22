using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AdminRejectionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorizerRejectionComment",
                table: "TSAReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "TSAReports",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuperRejected",
                table: "TSAReports",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rejectedby",
                table: "TSAReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RejectionDate",
                table: "TSAReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuperRejectedby",
                table: "TSAReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuperRejectionComment",
                table: "TSAReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SuperRejectionDate",
                table: "TSAReports",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorizerRejectionComment",
                table: "TSAReports");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "TSAReports");

            migrationBuilder.DropColumn(
                name: "IsSuperRejected",
                table: "TSAReports");

            migrationBuilder.DropColumn(
                name: "Rejectedby",
                table: "TSAReports");

            migrationBuilder.DropColumn(
                name: "RejectionDate",
                table: "TSAReports");

            migrationBuilder.DropColumn(
                name: "SuperRejectedby",
                table: "TSAReports");

            migrationBuilder.DropColumn(
                name: "SuperRejectionComment",
                table: "TSAReports");

            migrationBuilder.DropColumn(
                name: "SuperRejectionDate",
                table: "TSAReports");
        }
    }
}
