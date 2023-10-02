//using eticaret_data.Abstract;
//using eticaret_entity.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace eticaret_data.Concrete.SQL
//{
//    public class SqlOrderRepository : SqlGenericRepository<Order, artContext>, IOrderRepository
//    {
//        //public SqlOrderRepository(artContext context) : base(context)
//        //{

//        //}
//        //private artContext context
//        //{
//        //    get { return context as artContext; }
//        //}
//        public List<Order> GetOrders(string UserId)
//        {
//            using (var context = new artContext())
//            {
//                var orders = context.Orders
//                    .Include(i => i.OrderItems)
//                    .ThenInclude(i => i.Product)
//                    .AsQueryable();
//                if (!string.IsNullOrEmpty(UserId))
//                {
//                    orders = orders.Where(i => i.UserId == UserId);
//                }
//                return orders.ToList();
//            }
//        }
//    }
//}
