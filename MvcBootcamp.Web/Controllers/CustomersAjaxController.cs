using NorthwindRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.Web.Controllers
{
    public class CustomersAjaxController : Controller
    {
        private CustomerRepository custRepo = new CustomerRepository();

        // GET: CustomersAjax
        public ActionResult Index()
        {
            return View(custRepo.GetAllData().Take(10));
        }

        public ActionResult Search(string companyName)
        {
            var customers = custRepo.GetAllData().Where(c => c.CompanyName.Contains(companyName));

            if (Request.IsAjaxRequest())
            {
                return PartialView("_search", customers);
            }

            return View(customers);
        }
    }
}