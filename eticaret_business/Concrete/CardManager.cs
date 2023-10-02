using eticaret_business.Abstract;
using eticaret_data.Abstract;
using eticaret_data.Concrete.SQL;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_business.Concrete
{
    public class CardManager : ICardService
    {
        //private readonly IUnitOfWork _uniofwork;
        //public CardManager(IUnitOfWork unitofwork)
        //{
        //    _uniofwork = unitofwork;
        //}
        SqlCardRepository cardRepository = new SqlCardRepository();
        public void AddtoCard(string UserId, int ProductId, int Quantity)
        {
            var card = GetCardByUserId(UserId);

            if (card != null)
            {
                // eklenmek isteyen ürün sepette varmı (güncelleme)
                // eklenmek isteyen ürün sepette var ve yeni kayıt oluştur. (kayıt ekleme)

                var index = card.CardItems.FindIndex(i => i.ProductId == ProductId);
                if (index < 0)
                {
                    card.CardItems.Add(new CardItems()
                    {
                        ProductId = ProductId,
                        Quantity = Quantity,
                        CardId = card.Id
                    });
                }
                else
                {
                    card.CardItems[index].Quantity += Quantity;
                }

                cardRepository.update(card);

            }
        }

        public Card GetCardByUserId(string UserId)
        {
            return cardRepository.GetByUserId(UserId);
        }

        public void InitializeCard(string UserId)
        {
            cardRepository.create(new Card() { UserId = UserId });
        }

        public void DeleteFromCard(string userId, int productId)
        {
            var Card = GetCardByUserId(userId);
            if (Card != null)
            {
                cardRepository.DeleteFromCard(Card.Id, productId);
            }
        }

        public void ClearCard(int cardId)
        {
            cardRepository.ClearCard(cardId);
        }
    }
}
