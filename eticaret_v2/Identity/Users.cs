﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.Identity
{
    public class Users:IdentityUser
    {     
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
