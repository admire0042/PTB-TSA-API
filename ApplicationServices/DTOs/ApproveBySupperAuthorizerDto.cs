using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs
{
    public class ApproveBySupperAuthorizerDto
    {
        public Guid Id { get; set; }
        public string SuperAuthorizerComment { get; set; }
        public string SuperAuthorizedby { get; set; }
    }
}
