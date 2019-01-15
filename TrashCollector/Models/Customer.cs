using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customers
    {
        ApplicationUser user = new ApplicationUser();
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Day of the Week")]
        public string PickupDay { get; set; }
        [Display(Name = "Extra Pickup Date ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        [Display(Name = "Suspend Pickup Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SuspensionStartDate { get; set; }
        [Display(Name = "Suspend Pickup End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SuspensionEndDate { get; set; }
        public double ZipCode { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public double? PickupBill { get; set; }
        public bool? PickupStatus { get; set; }
        


        //customer needs a bill
        //customer should not set bill
        //customer should have an amount that deals with the bill. It will be a boolean



    }
}