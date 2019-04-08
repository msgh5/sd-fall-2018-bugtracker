﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiBugTracker.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual List<ApplicationUser> Users { get; set; }

        public Project()
        {
            Users = new List<ApplicationUser>();
        }
    }
}