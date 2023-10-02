using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Abstract
{
    public interface ICardRepository:IRepository<Card>
    {
        Card GetByUserId(string UserId);
        void DeleteFromCard(int CardId, int ProductId);
        void ClearCard(int cardId);
    }
}
