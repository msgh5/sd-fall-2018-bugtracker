﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiBugTracker.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ApplicationUser CreatedBy { get; set; }
        public string CreatedById { get; set; }

        public ApplicationUser AssignedTo { get; set; }
        public string AssignedToId { get; set; }

        public virtual TicketStatus TicketStatus { get; set; }
        public int TicketStatusId { get; set; }
    }
}