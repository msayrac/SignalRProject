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
	public class EfBookingDal : EfGenericRepository<Booking>, IBookingDal
	{
		public EfBookingDal(SignalRContext context) : base(context)
		{
		}
	}
}
