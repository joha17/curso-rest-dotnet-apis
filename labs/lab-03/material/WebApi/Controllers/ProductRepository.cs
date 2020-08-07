﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Infrastructure.Data.Models;

namespace WebApi.Controllers
{
    public class ProductRepository
    {
        public AdventureworksContext UnitOfWork {get; set;}
        public ProductRepository(Infrastructure.Data.Models.AdventureworksContext dbContext)
        {
            UnitOfWork = dbContext;
        }
        private readonly List<string> Products = new List<string>
        {
            "Jeans", "T-shirt", "Pants"
        };


        public object[] Get()
        {
            var i = 0;

            return Products.Select(model => new {
                Name = model,
                Id = i++
            }).ToArray();
        }

        public object GetById(int id)
        {
            int i = 0;

            var result = Products.Select(model => new {
                Name = model,
                Id = i++
            }).ToList();

            return result.ElementAtOrDefault(id);
        }

        public void Save(string name)
        {
            Products.Add(name);
        }
    }
}