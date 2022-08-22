using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagementAPI.Models
{
    public class Quote
    {  

        [Required]
        public int QuoteId { get; set; }

        [Required]
        public string QuoteType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DueDate {get; set; }

        [Required]
        public double Premium { get; set; }

        [Required]
        public string Sales { get; set; }
    }
}