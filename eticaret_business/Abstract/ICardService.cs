using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_business.Abstract
{
    interface ICardService
    {
        void InitializeCard(string UserId);
        Card GetCardByUserId(string UserId);
        void AddtoCard(string UserId, int ProductId, int Quantity);
        void DeleteFromCard(string UserId, int ProductId);
        void ClearCard(int cardId);
    }
}
