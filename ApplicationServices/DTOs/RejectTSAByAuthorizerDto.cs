using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs
{
    public class RejectTSAByAuthorizerDto
    {
        public Guid Id { get; set; }
        public string Rejectedby { get; set; }
        public string AuthorizerComment { get; set; }
    }
}
