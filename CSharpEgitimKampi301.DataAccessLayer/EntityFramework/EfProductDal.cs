﻿using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Context;
using CSharpEgitimKampi301.DataAccessLayer.Repositories;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Object> GetProductsWithCategory()
        {
            var context = new KampContext();
            var values = context.Products
                .Select(x => new 
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductStok = x.ProductStok,
                    ProductPrice = x.ProductPrice,
                    ProductDescription = x.ProductDescription,
                    ProductCategoryName = x.Category.CategoryName
                }).ToList();
            return values.Cast<object>().ToList();
        }
    }
}