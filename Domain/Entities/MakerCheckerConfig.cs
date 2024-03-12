using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MakerCheckerConfig
    {
        public string ConfigId { get; set; }
        public string StatusDescription { get; set; }
        public string StatusCode { get; set; }
        public string Initiatedby { get; set; }
        public string InitiatorBranch { get; set; }
        public DateTime? InitiatedDate { get; set; }
        public string? Authorizedby { get; set; }
        public string? AuthorizerComment { get; set; }
        public bool? IsAuthorized { get; set; } = false;
        public DateTime? AuthorizedDate { get; set; }
        public bool? IsSuperAuthorized { get; set; } = false;
        public string? SuperAuthorizerComment { get; set; }
        public string? SuperAuthorizedby { get; set; }
        public DateTime? SuperAuthorizedDate { get; set; }
    }
}
