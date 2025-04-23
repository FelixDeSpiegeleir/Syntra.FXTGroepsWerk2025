using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.FXTGroepsWerk2025.Objects
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string? FirstName { get; set; }

        [PersonalData]
        public string? LastName { get; set; }

        [PersonalData]
        public string? Address { get; set; }

        [PersonalData]
        public string? PostalCode { get; set; }
    }
}
