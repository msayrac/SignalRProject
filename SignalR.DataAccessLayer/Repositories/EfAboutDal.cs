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
	public class EfAboutDal : EfGenericRepository<About>, IAboutDal
	{
		public EfAboutDal(SignalRContext context) : base(context)
		{



		}

		
	}
}
