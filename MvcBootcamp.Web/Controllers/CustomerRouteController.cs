﻿using NorthwindRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.Web.Controllers
{
    [RoutePrefix("CustomerData")]
    public class CustomerRouteController : Controller
    {
        private CustomerRepository custRepo = new CustomerRepository();

        // GET: CustomersAjax
        //[Route("CustomerData/AllCustomer")]
        [Route("AllCustomer")]
        public ActionResult Index()
        {
            return View(custRepo.GetAllData().Take(5));
        }

        //[Route("CustomerData/{id}")]
        [Route("{id}")]
        public ActionResult Search(string id)
        {
            return View(custRepo.Search(id));
        }
    }
}