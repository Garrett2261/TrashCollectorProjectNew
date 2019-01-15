using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickupStatus
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CustomerId")]
        public Customers Customers { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "PickedUp?")]
        public bool? StatusOfPickup { get; set; }
    }
}