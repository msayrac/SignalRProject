﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IProductService : IGenericService<Product>
	{
		List<Product> TGetProductsWithCategories();
		public int TProductCount();
		public int TProductByCategoryNameHamburger();
		public int TProductByCategoryNameDrink();
		public decimal TProductPriceAvg();
		public string TProductNameByMaxPrice();
		public string TProductNameByMinPrice();

		public decimal TProductAvgPriceByHamburger();

		public decimal TProductPriceBySteakBurger();
		public decimal TTotalPriceByDrinkCategory();
		public decimal TTotalPriceBySaladCategory();




	}
}
