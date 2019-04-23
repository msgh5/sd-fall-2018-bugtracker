using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuiBugTracker.Models
{
    //[Table("tb_ticketstatuses")]
    public class TicketStatus
    {
        //[Column("n_id")]
        public int Id { get; set; }

        //[Required]
        //[StringLength(100)]
        public string Name { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
    }
}