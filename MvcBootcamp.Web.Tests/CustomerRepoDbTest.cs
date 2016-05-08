using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NorthwindRepository.Interfaces;
using NorthwindRepository.Repositories;
using DataAccessLayer;
using Telerik.JustMock;
using MvcBootcamp.Web.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace MvcBootcamp.Web.Tests
{
    [TestClass]
    public class CustomerRepoDbTest
    {
        [TestMethod]
        public void GetAllData_ReturnAllCustomers()
        {
            var repo = new CustomerRepository();
            var allCustomers = repo.GetAllData().ToList();
            Assert.AreEqual(92, allCustomers.Count());
        }

        [TestMethod]
        public void Search_ReturnACustomer()
        {
            var repo = new CustomerRepository();
            var customer = repo.Search("ALFKI");
            Assert.AreNotEqual("Alfred F", customer.CompanyName);
        }
    }
}
