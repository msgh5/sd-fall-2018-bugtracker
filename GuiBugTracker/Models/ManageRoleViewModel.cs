﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiBugTracker.Models
{
    public class ManageRoleViewModel
    {
        public List<RoleViewModel> UserRoles { get; set; }
        public List<RoleViewModel> AllRoles { get; set; }

        public ManageRoleViewModel()
        {
            UserRoles = new List<RoleViewModel>();
            AllRoles = new List<RoleViewModel>();
        }
    }

    public class RoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}