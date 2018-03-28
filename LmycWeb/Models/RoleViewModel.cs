﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.Models
{
    public class RoleViewModel
    {
        public string RoleId { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public string UserId { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
