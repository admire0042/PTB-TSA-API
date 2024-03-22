using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Enum
{
    public enum StatusEnum
    {
        [Description("Draft")]
        Draft = 1,
        [Description("Pending")]
        Pending = 2,
        [Description("Authorizer Approved")]
        Authorizer_Aproved = 3,
        [Description("Super Authorizer Approved")]
        SuperAuthorizer_Approved = 4,
        [Description("Authorizer Rejected")]
        Authorizer_Rejected = 5,
        [Description("Super Authorizer Rejected")]
        SuperAuthorizer_Rejected = 6
    }
}
