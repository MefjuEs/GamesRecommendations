﻿using Microsoft.AspNetCore.Identity;

namespace MAG.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
