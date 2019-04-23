using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuiBugTracker.Models
{
    public class CreateTicketViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int StatusId { get; set; }

        public SelectList AllStatuses { get; set; }
    }
}