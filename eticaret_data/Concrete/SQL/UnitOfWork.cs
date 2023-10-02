//using eticaret_data.Abstract;
//using eticaret_entity.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace eticaret_data.Concrete.SQL
//{
//    public class UnitOfWork : IDisposable, IUnitOfWork
//    {
//        private readonly artContext context;
//        public UnitOfWork(artContext context)
//        {
//            context = context;
//        }
//        private SqlProductRepository _productRepository;
//        private SqlCardRepository _cardRepository;
//        private SqlCategoryRepository _categoryRepository;
//        private SqlCommentRepository _commentRepository;
//        private SqlOrderRepository _orderRepository;
//        public IProductRepository Product =>
//            _productRepository = _productRepository ?? new SqlProductRepository(context);

//        public ICardRepository Card => 
//            _cardRepository=_cardRepository ?? new SqlCardRepository(context);

//        public ICategoryRepository Category =>
//            _categoryRepository = _categoryRepository ?? new SqlCategoryRepository(context);

//        public ICommentRepository Comments =>
//            _commentRepository = _commentRepository ?? new SqlCommentRepository(context);
//        public IOrderRepository Orders =>
//            _orderRepository = _orderRepository ?? new SqlOrderRepository(context);

//        public void Dispose()
//        {
//            context.Dispose();
//        }

//        public void save()
//        {
//            context.SaveChanges();
//        }
//    }
//}
