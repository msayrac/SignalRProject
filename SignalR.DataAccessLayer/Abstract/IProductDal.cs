using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IProductDal : IGenericDal<Product>
	{
		List<Product> GetProductsWithCategories();
		public int ProductCount();
		public int ProductByCategoryNameHamburger();
		public int ProductByCategoryNameDrink();
		public decimal ProductPriceAvg();
		public string ProductNameByMaxPrice();
		public string ProductNameByMinPrice();
		public decimal ProductAvgPriceByHamburger();
		public decimal ProductPriceBySteakBurger();
		public decimal TotalPriceByDrinkCategory();
		public decimal TotalPriceBySaladCategory();





	}
}
