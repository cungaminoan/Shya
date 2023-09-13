using Shya.DataAccess.Data;
using Shya.DataAccess.Repository.IRepository;
using Shya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shya.DataAccess.Repository
{
	public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
		private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db): base(db)
        {
			_db = db;
        }
		public void Update(OrderHeader obj)
		{
			_db.OrderHeaders.Update(obj);
		}
	}
}
