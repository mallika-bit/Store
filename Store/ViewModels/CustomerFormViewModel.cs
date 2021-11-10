using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models;

namespace Store.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> membershipTypes{ get; set; }

        public Customer Customer { get; set; }
    }
}