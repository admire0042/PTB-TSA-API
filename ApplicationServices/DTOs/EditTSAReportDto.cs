using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs
{
    public class EditTSAReportDto
    {
        public string RequestId { get; set; }
        public string BranchPhoneNumber { get; set; }
        public string Bvn { get; set; }
        public string CbnAcct { get; set; }
        public string Channel { get; set; }
        public decimal? CollectedAmount { get; set; }
        public string Currency { get; set; }
        public string CustomerAccount { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerTin { get; set; }
        public decimal? Fee { get; set; }
        //public string FeedType { get; set; }
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
        public string StatusCode { get; set; }
        public string Initiatedby { get; set; }
        public string InitiatorBranch { get; set; }
        public string UpdatedBy { get; set; }
    }
}

