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
	public class EfMoneyCaseDal : EfGenericRepository<MoneyCase>, IMoneyCaseDal
	{
		public EfMoneyCaseDal(SignalRContext context) : base(context)
		{


		}

		public decimal TotalMoneyCaseAmount()
		{
			using var context = new SignalRContext();

			return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
		}
	}
}
