using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.Web.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public string Index()
        {
            //return View();
            return "All hail pizza!";
        }

        public string Browse(string category)
        {
            return HttpUtility.HtmlEncode("This is pizza category: " + category);
        }

        public string News(int year, int month, int day)
        {
            return HttpUtility.HtmlEncode("The doomsday will be " + day + "/" + month + "/" + year);
        }

        public ActionResult Home()
        {
            return View("~/Views/Home/About.cshtml");
        }

        public ActionResult DataSample()
        {
            ViewData["event"] = "MSP Bootcamp";
            ViewData["place"] = "Hotel Neo Dipatiukur";

            ViewBag.eventbag = "MSP Bootcamp Bag";
            ViewBag.placebag = "Hotel Neo Bag";

            var books = new List<string>() { "ASP Ayam Saus Pedas", "SQL Sequel", "Windows Jendela" };
            ViewBag.fckinglist = books;

            return View();
        }

        public ViewResult StronglyTypeView()
        {
            var newCust = new Models.CustomerData()
            {
                CompanyName = "Microsoft",
                City = "Jakarta, Indonesia"
            };

            return View(newCust);
        }

        public ViewResult StronglyTypeViewList()
        {
            var custList = new List<Models.CustomerData>(){
                new Models.CustomerData() { CompanyName = "Microsoft", City = "Jakarta, Indonesia" },
                new Models.CustomerData() { CompanyName = "AirBnB", City = "US" }
            };

            return View(custList);
        }
    }
}