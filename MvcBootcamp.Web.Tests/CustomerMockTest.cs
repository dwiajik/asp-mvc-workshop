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
    public class CustomerMockTest
    {
        [TestMethod]
        public void GetAllData_ReturnAllCustomers()
        {
            var customerRepository = Mock.Create<IEntityRepository<Customer, string>>();

            Mock.Arrange(() => customerRepository.GetAllData()).Returns(
                new List<Customer>()
                {
                    new Customer {CustomerID = "1", CompanyName = "MSP Jabek" },
                    new Customer {CustomerID = "2", CompanyName = "MSP Bodeta" },
                    new Customer {CustomerID = "3", CompanyName = "MSP Jabar" },
                    new Customer {CustomerID = "4", CompanyName = "MSP DIY" }
                }.AsQueryable()).MustBeCalled();

            CustomersController controller = new CustomersController(customerRepository);
            ViewResult view = controller.Index() as ViewResult;
            var model = view.Model as IEnumerable<Customer>;

            //Assert.AreEqual(4, model.Count());
            Assert.IsNotNull(model);
            //Assert.AreEqual("MSP Jabek", model.ToList()[0].CompanyName);
            //Assert.AreEqual("MSP Bodeta", model.ToList()[1].CompanyName);
            //Assert.AreEqual("MSP Jabar", model.ToList()[2].CompanyName);
            //Assert.AreEqual("MSP DIY", model.ToList()[3].CompanyName);
        }

        [TestMethod]
        public void Search_ReturnACustomer()
        {
            var customerRepository = Mock.Create<IEntityRepository<Customer, string>>();

            Mock.Arrange(() => customerRepository.Search("1")).Returns(
                new Customer
                {
                    CustomerID = "1",
                    CompanyName = "MSP DIY"
                }).MustBeCalled();

            CustomersController controller = new CustomersController(customerRepository);
            ViewResult view = controller.Details("1") as ViewResult;
            var model = view.Model as Customer;

            Assert.AreEqual("MSP DIY", model.CompanyName);
        }
    }
}
