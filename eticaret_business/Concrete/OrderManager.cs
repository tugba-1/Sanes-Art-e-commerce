//using eticaret_business.Abstract;
//using eticaret_data.Abstract;
//using eticaret_data.Concrete.SQL;
//using eticaret_entity.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace eticaret_business.Concrete
//{
//    public class OrderManager : IOrderService
//    {
//        //private readonly IUnitOfWork _uniofwork;
//        //public OrderManager(IUnitOfWork unitofwork)
//        //{
//        //    _uniofwork = unitofwork;
//        //}
//        public IOrderRepository _orderRepository;
//        public OrderManager(IOrderRepository orderRepository)
//        {
//            _orderRepository = orderRepository;
//        }
//        public void create(Order entity)
//        {
//            _orderRepository.create(entity);
//        }

//        public List<Order> GetOrders(string UserId)
//        {
//            return _orderRepository.GetOrders(UserId);

//            //using (var context = new artContext())
//            //{
//            //    return context.Set<Order>().ToList();
//            //}
//        }
//    }
//}
