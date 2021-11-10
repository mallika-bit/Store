using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models;
using Store.ViewModels;


namespace Store.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();

        }

      protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customer
       public ViewResult Index()
        {

             List<Customer> customers = _context.Customers.Include(c=>c.MembershipType).ToList();
             return View(customers);
           
        }
        public ActionResult CustomerDetails(int id)
        {
            var customer =  _context.Customers.SingleOrDefault(c=>c.Id == id);

            return View(customer);
        }

       //New Cutomer Form
       public ActionResult NewCustomer()
       {
            var MembershipTypes = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel()
            {
                Customer = new Customer(),   
                membershipTypes = MembershipTypes
            };
            return View("NewCustomer",viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    membershipTypes = _context.MembershipTypes.ToList()

                };
              return View("NewCustomer", viewmodel);
             }

            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c=>c.Id == customer.Id);

                customerInDb.Id = customer.Id;
                customerInDb.Name = customer.Name;
                 customerInDb.MembershipTypeID = customer.MembershipTypeID;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
              }
          
            _context.SaveChanges();

            return RedirectToAction("Index","Customer");
          }
      

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel {

                Customer = customer,
                membershipTypes = _context.MembershipTypes.ToList()
            };
            return View("NewCustomer",viewModel);
        }
    }
}