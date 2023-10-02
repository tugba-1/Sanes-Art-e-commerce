using eticaret_data.Abstract;
using eticaret_entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Concrete.SQL
{
    public class SqlCardRepository : SqlGenericRepository<Card, artContext>, ICardRepository
    {

        //public SqlCardRepository(artContext context) : base(context)
        //{

        //}
        //private artContext context
        //{
        //    get { return context as artContext; }
        //}

        public Card GetByUserId(string UserId)
        {
            using (var context = new artContext())
            {
                return context.Cards
                     .Include(i => i.CardItems)
                     .ThenInclude(i => i.Product)
                     .FirstOrDefault(i => i.UserId == UserId);
            }
        }
        public override void update(Card entity)
        {
            using (var context = new artContext())
            {
                context.Cards.Update(entity);
                context.SaveChanges();
            }
        }

        public void DeleteFromCard(int id, int productId)
        {
            using (var context = new artContext())
            {
                var cmd = @"delete from CardItems where CardId=@p0 and ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd, id, productId);
            }
        }

        public void ClearCard(int cardId)
        {
            using (var context = new artContext())
            {
                var cmd = @"delete from CardItems where CardId=@p0";
                context.Database.ExecuteSqlRaw(cmd, cardId);
            }
        }
    }
}
