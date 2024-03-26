using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs
{
    public class GetTSADto
    {
            public string RequestId { get; set; }
            public string BankId { get; set; }
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
            public string TsaPcCodename { get; set; }
            public string TsaPcCoderef { get; set; }
            public DateTime? ValueDate { get; set; }
            public string Payer { get; set; }
            public DateTime? TransmittedDate { get; set; }
        public string ConfigId { get; set; }
        public string StatusDescription { get; set; }
        public string StatusCode { get; set; }
        public string Initiatedby { get; set; }
        public string InitiatorBranch { get; set; }
        public DateTime? InitiatedDate { get; set; }
        public string Authorizedby { get; set; }
        public string AuthorizerComment { get; set; }
        public bool? IsAuthorized { get; set; } = false;
        public DateTime? AuthorizedDate { get; set; }
        public bool? IsSuperAuthorized { get; set; } = false;
        public string SuperAuthorizerComment { get; set; }
        public string SuperAuthorizedby { get; set; }
        public DateTime? SuperAuthorizedDate { get; set; }

        public string Rejectedby { get; set; }
        public bool? IsRejected { get; set; } = false;
        public DateTime? RejectionDate { get; set; }
        public string SuperRejectedby { get; set; }
        public bool? IsSuperRejected { get; set; } = false;
        public DateTime? SuperRejectionDate { get; set; }
        public string NibbsStatus { get; set; }
        public DateTime? DateSentToNibbs { get; set; }
    }
}
