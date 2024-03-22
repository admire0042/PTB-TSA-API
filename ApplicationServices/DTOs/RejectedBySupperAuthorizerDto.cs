using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs
{
    public class RejectedBySupperAuthorizerDto
    {
        public Guid Id { get; set; }
        public string SuperAuthorizerComment { get; set; }
        public string SuperRejectedby { get; set; }
    }
}
