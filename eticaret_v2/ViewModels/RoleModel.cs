//using eticaret_v2.Data;
//using eticaret_v2.Models;
using eticaret_entity.Models;
using eticaret_v2.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.ViewModels
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }
    }
    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<Identity.Users> Members { get; set; }
        public IEnumerable<Identity.Users> NonMembers { get; set; }
    }
    public class RoleEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] IdstoAdd { get; set; }
        public string[] IdstoDelete { get; set; }
    }
}
