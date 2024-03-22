using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "TSAReports",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        RequestId = table.Column<string>(type: "varchar(100)", nullable: true),
            //        BankId = table.Column<string>(type: "varchar(3)", nullable: true),
            //        UniqueReference = table.Column<string>(type: "varchar(20)", nullable: true),
            //        BankBranchId = table.Column<string>(type: "varchar(10)", nullable: true),
            //        BatchId = table.Column<string>(type: "varchar(20)", nullable: true),
            //        BranchPhoneNumber = table.Column<string>(type: "varchar(20)", nullable: true),
            //        Bvn = table.Column<string>(type: "varchar(11)", nullable: true),
            //        CbnAcct = table.Column<string>(type: "varchar(50)", nullable: true),
            //        Channel = table.Column<string>(type: "varchar(100)", nullable: true),
            //        payColDate = table.Column<string>(type: "varchar(100)", nullable: false),
            //        CollectedAmount = table.Column<decimal>(type: "DECIMAL(25,2)", nullable: true),
            //        Currency = table.Column<string>(type: "varchar(3)", nullable: true),
            //        CustomerAccount = table.Column<string>(type: "varchar(50)", nullable: true),
            //        CustomerName = table.Column<string>(type: "varchar(200)", nullable: true),
            //        CustomerEmail = table.Column<string>(type: "varchar(200)", nullable: true),
            //        CustomerPhoneNumber = table.Column<string>(type: "varchar(50)", nullable: true),
            //        CustomerTin = table.Column<string>(type: "varchar(50)", nullable: true),
            //        Fee = table.Column<decimal>(type: "DECIMAL(25,2)", nullable: true),
            //        FeedType = table.Column<string>(type: "varchar(5)", nullable: true),
            //        GifmisCode = table.Column<string>(type: "varchar(50)", nullable: true),
            //        ItemCode = table.Column<string>(type: "varchar(50)", nullable: true),
            //        ItemName = table.Column<string>(type: "varchar(50)", nullable: true),
            //        LocationCode = table.Column<string>(type: "varchar(20)", nullable: true),
            //        LocationName = table.Column<string>(type: "varchar(100)", nullable: true),
            //        MdaCode = table.Column<string>(type: "varchar(100)", nullable: true),
            //        MdaName = table.Column<string>(type: "varchar(max)", nullable: true),
            //        NarrationDescription = table.Column<string>(type: "varchar(200)", nullable: true),
            //        Date = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        PsspCode = table.Column<string>(type: "varchar(20)", nullable: true),
            //        PsspName = table.Column<string>(type: "varchar(200)", nullable: true),
            //        RemittedAmount = table.Column<decimal>(type: "DECIMAL(25,2)", nullable: true),
            //        RequestedAmount = table.Column<decimal>(type: "DECIMAL(25,2)", nullable: true),
            //        SessionId = table.Column<int>(type: "Int", nullable: true),
            //        SettlementRef = table.Column<string>(type: "varchar(50)", nullable: true),
            //        TsaPcCodename = table.Column<string>(type: "varchar(200)", nullable: true),
            //        TsaPcCoderef = table.Column<string>(type: "varchar(100)", nullable: true),
            //        ValueDate = table.Column<DateTime>(type: "Date", nullable: true),
            //        Payer = table.Column<string>(type: "varchar(100)", nullable: true),
            //        TransmittedDate = table.Column<string>(type: "varchar(100)", nullable: true),
            //        ConfigId = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        StatusDescription = table.Column<string>(type: "varchar(100)", nullable: true),
            //        StatusCode = table.Column<string>(type: "varchar(100)", nullable: true),
            //        Initiatedby = table.Column<string>(type: "varchar(100)", nullable: true),
            //        InitiatorBranch = table.Column<string>(type: "varchar(100)", nullable: true),
            //        InitiatedDate = table.Column<DateTime>(type: "Date", nullable: true),
            //        Authorizedby = table.Column<string>(type: "varchar(100)", nullable: true),
            //        AuthorizerComment = table.Column<string>(type: "varchar(100)", nullable: true),
            //        IsAuthorized = table.Column<string>(type: "varchar(100)", nullable: true),
            //        AuthorizedDate = table.Column<DateTime>(type: "Date", nullable: true),
            //        IsSuperAuthorized = table.Column<bool>(type: "Bit", nullable: true),
            //        SuperAuthorizerComment = table.Column<string>(type: "varchar(100)", nullable: true),
            //        SuperAuthorizedby = table.Column<string>(type: "varchar(100)", nullable: true),
            //        SuperAuthorizedDate = table.Column<DateTime>(type: "Date", nullable: true),
            //        DateAdded = table.Column<DateTime>(type: "DateTime2", nullable: true),
            //        DateModified = table.Column<DateTime>(type: "DateTime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TSAReports", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "TSAReports");
        }
    }
}
