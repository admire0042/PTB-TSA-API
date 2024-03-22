using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs
{
    public class ApproveTSAByAuthorizerDto
    {
        public Guid Id { get; set; }
        public string Authorizedby { get; set; }
        public string AuthorizerComment { get; set; }
    }
}
