﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
	public class EfOrder : EfGenericRepository<Order>, IOrderDal
	{
		public EfOrder(SignalRContext context) : base(context)
		{
		}

		public int ActiveOrderCount()
		{
			using var context = new SignalRContext();

			return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();

		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRContext();

			return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
		}

		public decimal TodayTotalPrice()
		{
			using var context = new SignalRContext();

			return context.Orders.Where(x => x.OrderDate == DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(y => y.TotalPrice);



		}

		public int TotalOrderCount()
		{
			using var context = new SignalRContext();

			return context.Orders.Count();
		}
	}
}
