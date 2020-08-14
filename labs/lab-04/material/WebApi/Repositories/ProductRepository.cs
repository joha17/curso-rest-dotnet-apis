using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Infrastructure.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repositories
{
    public class ProductRepository
    {
        public AdventureworksContext UnitOfWork {get; set;}
        public ProductRepository(Infrastructure.Data.Models.AdventureworksContext dbContext)
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
            return UnitOfWork.Product
                      .Select(p => new { 
                          Name = p.Name,
                          p.ListPrice,
                          Category = new { p.ProductCategory },
                          p.Weight
                      })
                      .ToArray();

        } 

        public object Get(int id)
        {
            var query = UnitOfWork.Product.Where(p => p.ProductId == id)
                     .Select(p => new {
                         Name = p.Name,
                         p.ListPrice,
                         Category = new { p.ProductCategory },
                         p.Weight
                     })
                     .FirstOrDefault();

            return query;
        }

        public int Save(ProductViewModel product)
        {
            //Store in DB
            //AsQueryble lo que hace es como un array pero no ejecutado, si no unicamemte cuando se llena cuando se llama.
            var query = UnitOfWork.Set<Product>().AsQueryable();

            var next = query.Max(p => p.ProductNumber) + 1;

            var model = new Product { 
                                    Name = product.Name,
                                    SellStartDate = DateTime.Now,
                                    SellEndDate = DateTime.Now.AddYears(1),
                                    ProductNumber = next
            };

            UnitOfWork.Set<Product>().Add(model);
            UnitOfWork.SaveChanges();

            return model.ProductId;
        }

        public bool Update(int id, ProductViewModel request)
        {
            Product model = UnitOfWork.Product.Find(id);
            if (model == null)
            {
                return false;
            }
            model.ListPrice = request.ListPrice;
            model.Name = request.Name;
            model.Weight = request.Weight;

            UnitOfWork.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            UnitOfWork.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var model = UnitOfWork.Product.Find(id);
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