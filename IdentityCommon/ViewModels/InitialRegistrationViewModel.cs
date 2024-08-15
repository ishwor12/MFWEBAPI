using IdentityCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityCommon.ViewModels
{
    public class InitialRegistrationViewModel
    {
        public RegisterType RegisterType { get; set; }
        public string ReturnUrl { get; set; }
    }
}
