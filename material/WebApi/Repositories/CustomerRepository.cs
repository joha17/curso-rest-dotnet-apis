using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infrastructure.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repositories
{
    public class CustomerRepository
    {
        public AdventureworksContext UnitOfWork { get; set; }
        public CustomerRepository(Infrastructure.Data.Models.AdventureworksContext dbContext)
        {
            //UoW
            UnitOfWork = dbContext;
        }
        private readonly List<string> Products = new List<string>
        {
            "Jeans", "T-shirt", "Pants"
        };


        public object[] Get()
        {
            return UnitOfWork.Customer
                      .Select(p => new {
                          CustomerId = p.CustomerId,
                          Title = p.Title,
                          FirstName = p.FirstName,
                          MiddleName = p.MiddleName,
                          LastName = p.LastName,
                          CompanyName = p.CompanyName,
                          EmailAddress = p.EmailAddress,
                          Phone = p.Phone
                      })
                      .ToArray();
        }

        public object Get(int id)
        {
            var query = UnitOfWork.Customer.Where(p => p.CustomerId == id)
                     .Select(p => new {
                         CustomerId = p.CustomerId,
                         Title = p.Title,
                         FirstName = p.FirstName,
                         MiddleName = p.MiddleName,
                         LastName = p.LastName,
                         CompanyName = p.CompanyName,
                         EmailAddress = p.EmailAddress,
                         Phone = p.Phone
                     })
                     .FirstOrDefault();

            return query;
        }

        public int Save(CustomerViewModel customer)
        {
            //Store in DB
            //AsQueryble lo que hace es como un array pero no ejecutado, si no unicamemte cuando se llena cuando se llama.
            var query = UnitOfWork.Set<Customer>().AsQueryable();

            var next = query.Max(p => p.CustomerId) + 1;

            var model = new Customer
            {
                FirstName = customer.FirstName,
                Title = customer.Title,
                LastName = customer.LastName,
                MiddleName = customer.MiddleName,
                CompanyName = customer.CompanyName,
                EmailAddress = customer.EmailAddress,
                PasswordHash = "jtF9jBoFYeJTaET7x+eJDkd7BzMz15Wo9odbGPBaIak=",
                PasswordSalt = "wVLnvHo=",
                Phone = customer.Phone
            };

            UnitOfWork.Set<Customer>().Add(model);
            UnitOfWork.SaveChanges();

            return model.CustomerId;
        }

        public bool Update(int id, CustomerViewModel request)
        {
            Customer model = UnitOfWork.Customer.Find(id);
            if (model == null)
            {
                return false;
            }
            model.FirstName = request.FirstName;
            model.Title = request.Title;
            model.MiddleName = request.MiddleName;
            model.LastName = request.LastName;
            model.CompanyName = request.CompanyName;
            model.EmailAddress = request.CompanyName;
            model.PasswordHash = "jtF9jBoFYeJTaET7x+eJDkd7BzMz15Wo9odbGPBaIak=";
            model.PasswordSalt = "wVLnvHo=";
            model.Phone = request.Phone;

            UnitOfWork.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            UnitOfWork.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var model = UnitOfWork.Customer.Find(id);
            if (model == null)
            {
                return false;
            }

            UnitOfWork.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            UnitOfWork.SaveChanges();
            return true;
        }
    }
}
