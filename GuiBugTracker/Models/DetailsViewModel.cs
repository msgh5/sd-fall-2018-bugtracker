using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiBugTracker.Models
{
    public class DetailsViewModel
    {
        public string Title { get; set; }
        public Ticket Ticket { get; set; }
        public UserViewModel UserViewMOdel { get; set; }
    }
}