using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataAccessLayer
{
	//[MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {

    }

    public class CustomerMetadata
    {
        [Display(Name = "Customer ID")]
        [Required(ErrorMessage = "Customer ID field cannot be empty")]
        [StringLength(5, ErrorMessage = "ID cannot have more than 5 characters")]
        [Remote("CheckCustomerID", "Customer", ErrorMessage = "Customer ID is exist")]
        public string CustomerID { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name field cannot be empty")]
        [StringLength(40, ErrorMessage = "Company name should not be more than 40 characters")]
        public string CompanyName { get; set; }
    }
}
