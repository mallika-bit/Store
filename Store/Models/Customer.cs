using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //  [Display(Name = "Membership Type")]

        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeID { get; set; }

        [Display(Name="Date Of Birth")]
        [Min18YearsIfaMember]
        public DateTime? Birthdate { get; set; }


     
    }
}