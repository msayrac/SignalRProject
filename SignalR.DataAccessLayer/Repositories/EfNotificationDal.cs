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
	public class EfNotificationDal : EfGenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRContext context) : base(context)
		{

		}

		public List<Notification> GetAllNotificationByFalse()
		{
			using var context = new SignalRContext();	

			return context.Notifications.Where(x=>x.Status==false).ToList();
		}

		public int NotificationCountByStatusFalse()
		{
			using var context = new SignalRContext();

			return context.Notifications.Where(x=>x.Status==false).Count();	



		}
	}
}
