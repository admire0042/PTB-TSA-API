using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TSAReport: Entity
    {
            public Guid Id { get; set; }
            public string RequestId { get; set; }
            public string BankId { get; set; }
            public string NibssSettlementRef { get; set; }
            public string UniqueReference { get; set; }
            public string BankBranchId { get; set; }
            public string BatchId { get; set; }
            public string BranchPhoneNumber { get; set; }
            public string Bvn { get; set; }
            public string CbnAcct { get; set; }
            public string Channel { get; set; }
            public DateTime payColDate { get; set; }
            public decimal? CollectedAmount { get; set; }
            public string Currency { get; set; }
            public string CustomerAccount { get; set; }
            public string CustomerName { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerPhoneNumber { get; set; }
            public string CustomerTin { get; set; }
            public decimal? Fee { get; set; }
            public string FeedType { get; set; }
            public string GifmisCode { get; set; }
            public string ItemCode { get; set; }
            public string ItemName { get; set; }
            public string LocationCode { get; set; }
            public string LocationName { get; set; }
            public string MdaCode { get; set; }
            public string MdaName { get; set; }
            public string NarrationDescription { get; set; }
            public DateTime? Date { get; set; }
            public string PsspCode { get; set; }
            public string PsspName { get; set; }
            public decimal? RemittedAmount { get; set; }
            public decimal? RequestedAmount { get; set; }
            public int? SessionId { get; set; }
            public string SettlementRef { get; set; }
            public string PcCodeName { get; set; }
            public string PcCodeRef { get; set; }
            public DateTime? ValueDate { get; set; }
            public string Payer { get; set; }
            public DateTime? TransmittedDate { get; set; }
            public MakerCheckerConfig checkerConfig { get; set; }

        public static TSAReport Create(TSAReport report)
        {
            return new TSAReport
            {
                RequestId = report.RequestId,
                BankId = report.BankId,
                NibssSettlementRef = report.NibssSettlementRef,
                UniqueReference = report.UniqueReference,
                BankBranchId = report.BankBranchId,
                BatchId = report.BatchId,
                BranchPhoneNumber = report.BranchPhoneNumber,
                Bvn = report.Bvn,
                CbnAcct = report.CbnAcct,
                Channel = report.Channel,
                CollectedAmount = report.CollectedAmount,
                Currency = report.Currency,
                CustomerAccount = report.CustomerAccount,
                CustomerName = report.CustomerName,
                CustomerEmail = report.CustomerEmail,
                CustomerPhoneNumber = report.CustomerPhoneNumber,
                CustomerTin = report.CustomerTin,
                Fee = report.Fee,
                FeedType = report.FeedType,
                GifmisCode = report.GifmisCode,
                ItemCode = report.ItemCode,
                ItemName = report.ItemName,
                LocationCode = report.LocationCode,
                LocationName = report.LocationName,
                MdaCode = report.MdaCode,
                MdaName = report.MdaName,
                NarrationDescription = report.NarrationDescription,
                Date = report.Date,
                PsspCode = report.PsspCode,
                PsspName = report.PsspName,
                RemittedAmount = report.RemittedAmount,
                RequestedAmount = report.RequestedAmount,
                SessionId = report.SessionId,
                SettlementRef = report.SettlementRef,
                PcCodeName = report.PcCodeName,
                PcCodeRef = report.PcCodeRef,
                ValueDate = report.ValueDate,
                Payer = report.Payer,
                TransmittedDate = report.TransmittedDate,
                checkerConfig = report.checkerConfig
            };
        }

    }
}
