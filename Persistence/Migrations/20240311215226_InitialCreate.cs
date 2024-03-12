using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TSAReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestId = table.Column<string>(type: "varchar(100)", nullable: false),
                    BankId = table.Column<string>(type: "varchar(3)", nullable: false),
                    UniqueReference = table.Column<string>(type: "varchar(20)", nullable: false),
                    BankBranchId = table.Column<string>(type: "varchar(10)", nullable: false),
                    BatchId = table.Column<string>(type: "varchar(20)", nullable: false),
                    BranchPhoneNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    Bvn = table.Column<string>(type: "varchar(11)", nullable: false),
                    CbnAcct = table.Column<string>(type: "varchar(50)", nullable: false),
                    Channel = table.Column<string>(type: "varchar(100)", nullable: false),
                    payColDate = table.Column<string>(type: "varchar(100)", nullable: false),
                    CollectedAmount = table.Column<decimal>(type: "DECIMAL(25,2)", nullable: true),
                    Currency = table.Column<string>(type: "varchar(3)", nullable: false),
                    CustomerAccount = table.Column<string>(type: "varchar(50)", nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(200)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "varchar(200)", nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    CustomerTin = table.Column<string>(type: "varchar(50)", nullable: false),
                    Fee = table.Column<decimal>(type: "DECIMAL(25,2)", nullable: true),
                    FeedType = table.Column<string>(type: "varchar(5)", nullable: false),
                    GifmisCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    ItemCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    ItemName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LocationCode = table.Column<string>(type: "varchar(20)", nullable: false),
                    LocationName = table.Column<string>(type: "varchar(100)", nullable: false),
                    MdaCode = table.Column<string>(type: "varchar(100)", nullable: false),
                    MdaName = table.Column<string>(type: "varchar(max)", nullable: false),
                    NarrationDescription = table.Column<string>(type: "varchar(200)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PsspCode = table.Column<string>(type: "varchar(20)", nullable: false),
                    PsspName = table.Column<string>(type: "varchar(200)", nullable: false),
                    RemittedAmount = table.Column<decimal>(type: "DECIMAL(25,2)", nullable: true),
                    RequestedAmount = table.Column<decimal>(type: "DECIMAL(25,2)", nullable: true),
                    SessionId = table.Column<int>(type: "Int", nullable: true),
                    SettlementRef = table.Column<string>(type: "varchar(50)", nullable: false),
                    TsaPcCodename = table.Column<string>(type: "varchar(200)", nullable: false),
                    TsaPcCoderef = table.Column<string>(type: "varchar(100)", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Payer = table.Column<string>(type: "varchar(100)", nullable: false),
                    TransmittedDate = table.Column<string>(type: "varchar(100)", nullable: true),
                    ConfigId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDescription = table.Column<string>(type: "varchar(100)", nullable: false),
                    StatusCode = table.Column<string>(type: "varchar(100)", nullable: false),
                    Initiatedby = table.Column<string>(type: "varchar(100)", nullable: false),
                    InitiatorBranch = table.Column<string>(type: "varchar(100)", nullable: false),
                    InitiatedDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Authorizedby = table.Column<string>(type: "varchar(100)", nullable: true),
                    AuthorizerComment = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsAuthorized = table.Column<string>(type: "varchar(100)", nullable: true),
                    AuthorizedDate = table.Column<DateTime>(type: "Date", nullable: true),
                    IsSuperAuthorized = table.Column<bool>(type: "Bit", nullable: true),
                    SuperAuthorizerComment = table.Column<string>(type: "varchar(100)", nullable: true),
                    SuperAuthorizedby = table.Column<string>(type: "varchar(100)", nullable: true),
                    SuperAuthorizedDate = table.Column<DateTime>(type: "Date", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSAReports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TSAReports");
        }
    }
}
