using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiBugTracker.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> UserRoles { get; set; }
    }
}