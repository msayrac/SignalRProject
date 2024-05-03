﻿using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
	public class EfProductDal : EfGenericRepository<Product>, IProductDal
	{
		public EfProductDal(SignalRContext context) : base(context)
		{
		}

		public List<Product> GetProductsWithCategories()
		{
			var context = new SignalRContext();

			var values = context.Products.Include(x => x.Category).ToList();
			return values;
		}

		public int ProductByCategoryNameDrink()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
			
		}

		public int ProductByCategoryNameHamburger()
		{
			using var context = new SignalRContext();

			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
		}

		public int ProductCount()
		{
			using var context = new SignalRContext();

			return context.Products.Count();
		}
	}
}
