using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class NibbsPrptyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorizerRejectionComment",
                table: "TSAReports");

            migrationBuilder.RenameColumn(
                name: "SuperRejectionComment",
                table: "TSAReports",
                newName: "NibbsStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSentToNibbs",
                table: "TSAReports",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSentToNibbs",
                table: "TSAReports");

            migrationBuilder.RenameColumn(
                name: "NibbsStatus",
                table: "TSAReports",
                newName: "SuperRejectionComment");

            migrationBuilder.AddColumn<string>(
                name: "AuthorizerRejectionComment",
                table: "TSAReports",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
