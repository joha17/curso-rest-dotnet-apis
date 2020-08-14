using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
