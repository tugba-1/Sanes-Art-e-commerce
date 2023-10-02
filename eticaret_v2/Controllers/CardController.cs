using eticaret_business.Concrete;
using eticaret_entity.Models;
using eticaret_v2.Identity;
using eticaret_v2.ViewModels;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eticaret_v2.ViewModels.OrderListModel;

namespace eticaret_v2.Controllers
{
    [Authorize]
    public class CardController:Controller
    {
        private CardManager _cardManager;
        private UserManager<Identity.Users> _userManager;
        //private OrderManager _orderManager;
        public CardController(CardManager cardManager, UserManager<Identity.Users> userManager)
        {
            _cardManager = cardManager;
            _userManager = userManager;
            //_orderManager = orderManager;
        }
        public IActionResult Indexc()
        {
            var card = _cardManager.GetCardByUserId(_userManager.GetUserId(User));
            return View(new CardModel() { 
                   CardId=card.Id,
                   CardItems=card.CardItems.Select(i=>new CardItemModel() 
                   { 
                       Id=i.Id,
                       ProductId=i.Product.Id,
                       Name=i.Product.Name,
                       Price=(decimal)i.Product.Price,
                       ImageUrl=i.Product.ImgUrl,
                       Quantity=i.Quantity
                   }).ToList()
            });
        }
        [HttpPost]
        public IActionResult AddtoCard(int ProductId, int Quantity)
        {
            var userid = _userManager.GetUserId(User);
            _cardManager.AddtoCard(userid, ProductId, Quantity);
            return RedirectToAction("Indexc");
        }
        [HttpPost]
        public IActionResult DeleteFromCard(int ProductId)
        {
            var UserId= _userManager.GetUserId(User);
            _cardManager.DeleteFromCard(UserId, ProductId);
            return RedirectToAction("Indexc");
        }
        public IActionResult Checkout()
        {
            var card = _cardManager.GetCardByUserId(_userManager.GetUserId(User));

            var orderModel = new OrderModel();

            orderModel.CardModel = new CardModel()
            {
                CardId = card.Id,
                CardItems = card.CardItems.Select(i => new CardItemModel()
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price =(decimal)i.TotalPrice,
                    ImageUrl = i.Product.ImgUrl,
                    Quantity = i.Quantity
                }).ToList()
            };

            return View(orderModel);
        }

        //[HttpPost]
        //public IActionResult Checkout(OrderModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var userId = _userManager.GetUserId(User);
        //        var card = _cardManager.GetCardByUserId(userId);
        //        model.CardModel = new CardModel()
        //        {
        //            CardId = card.Id,
        //            CardItems = card.CardItems.Select(i => new CardItemModel()
        //            {
        //                Id = i.Id,
        //                ProductId = i.ProductId,
        //                Name = i.Product.Name,
        //                Price = (decimal)i.Product.Price,
        //                ImageUrl = i.Product.ImgUrl,
        //                Quantity = i.Quantity,
        //                CardId=i.CardId

        //            }).ToList()
        //        };
        //        var payment = PaymentProcess(model);
        //        //if (payment.PaymentStatus == "SUCCESS")
        //        //{
        //        SaveOrder(model, payment, userId);
        //        ClearCard(model.CardModel.CardId);
        //        return View("Success");
        //        //}
        //        //else
        //        //{
        //        //    var msg = new AlertMessage()
        //        //    {
        //        //        Message = $"{payment.ErrorMessage}",
        //        //        AlertType = "danger"
        //        //    };

        //        //    TempData["message"] = JsonConvert.SerializeObject(msg);
        //        //}
        //    }
        //    return View(model);
        //}

        private void ClearCard(int cardId)
        {           
            _cardManager.ClearCard(cardId);
        }

        //private void SaveOrder(OrderModel model, Payment payment, string userId)
        //{
        //    var order = new Order();

        //    order.SiparisNo = new Random().Next(111111,999999);
        //    //order.OrderState = EnumOrderState.completed;
        //    //order.PaymentType = EnumPaymentType.CreditCard;
        //    order.PaymentId = new Random().Next(111111111, 999999999).ToString();
        //    order.ConversationId = payment.ConversationId;
        //    order.DateAdded = new DateTime();
        //    order.FirstName = model.FirstName;
        //    order.LastName = model.LastName;
        //    order.UserId = userId;
        //    order.Address = model.Address;
        //    order.Phone = model.Phone;
        //    order.Email = model.Email;
        //    order.City = model.City;
        //    order.Note = model.Note;

        //    order.OrderItems = new List<eticaret_entity.Models.OrderItem>();

        //    foreach (var item in model.CardModel.CardItems)
        //    {
        //        var orderItem = new eticaret_entity.Models.OrderItem()
        //        {
        //            Price = (decimal)item.Price,
        //            Quantity = item.Quantity,
        //            ProductId = item.ProductId
        //        };
        //        //order.OrderItems = new List<eticaret_entity.Models.OrderItem>();
        //        order.OrderItems.Add(orderItem);
        //    }
        //    _orderManager.create(order);
        //}
        //public IActionResult GetOrders()
        //{
        //    var UserId = _userManager.GetUserId(User);
        //    var orders = _orderManager.GetOrders(UserId);
        //    var orderListModel = new List<OrderListModel>();
        //    OrderListModel orderModel;
        //    foreach (var order in orders)
        //    {
        //        orderModel = new OrderListModel();

        //        orderModel.OrderId = order.Id;
        //        orderModel.SiparisNo = order.SiparisNo;
        //        orderModel.DateAdded = order.DateAdded;
        //        orderModel.Phone = order.Phone;
        //        orderModel.FirstName = order.FirstName;
        //        orderModel.LastName = order.LastName;
        //        orderModel.Email = order.Email;
        //        orderModel.Address = order.Address;
        //        orderModel.City = order.City;
        //        //orderModel.OrderState = order.OrderState;
        //        //orderModel.PaymentType = order.PaymentType;

        //        orderModel.OrderItems = order.OrderItems.Select(i => new ViewModels.OrderItem()
        //        {
        //            OrderItemId = i.OrderId,
        //            Name = i.Product.Name,
        //            Price = (decimal)i.Price,
        //            Quantity = i.Quantity,
        //            ImageUrl = i.Product.ImgUrl
        //        }).ToList();

        //        orderListModel.Add(orderModel);
        //    }
        //    return View(orderListModel);

        //    //return View(new OrderListModel
        //    //{
        //    //    orders=_orderManager.GetOrders()
        //    //});
        //}

        private Payment PaymentProcess(OrderModel model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-6UNVVa0D6YAdjmhqlXqJRUSE69NyvEd9";
            options.SecretKey = "sandbox-sucjI3Q12cMraX1zj7R2TI0kjURt3AGR";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString(); 
            request.Price = model.CardModel.TotalPrice().ToString();
            request.PaidPrice = model.CardModel.TotalPrice().ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CardName;
            paymentCard.CardNumber = model.CardNumber;
            paymentCard.ExpireMonth = model.ExpirationMonth;
            paymentCard.ExpireYear = model.ExpirationYear;
            paymentCard.Cvc = model.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = model.FirstName;
            buyer.Surname = model.LastName;
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;

            foreach (var item in model.CardModel.CardItems)
            {

                basketItem = new BasketItem();
                basketItem.Id = item.ProductId.ToString();
                basketItem.Name = item.Name;
                basketItem.Category1 = "Karadeniz1";
                basketItem.Price = model.CardModel.TotalPrice().ToString();
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItems.Add(basketItem);
            }
            request.BasketItems = basketItems;

            //BasketItem firstBasketItem = new BasketItem();
            //firstBasketItem.Id = "BI101";
            //firstBasketItem.Name = "Binocular";
            //firstBasketItem.Category1 = "Collectibles"; 
            //firstBasketItem.Category2 = "Accessories";
            //firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            //firstBasketItem.Price = "0.3";
            //basketItems.Add(firstBasketItem);

            //BasketItem secondBasketItem = new BasketItem();
            //secondBasketItem.Id = "BI102";
            //secondBasketItem.Name = "Game code";
            //secondBasketItem.Category1 = "Game";
            //secondBasketItem.Category2 = "Online Game Items";
            //secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            //secondBasketItem.Price = "0.5";
            //basketItems.Add(secondBasketItem);

            //BasketItem thirdBasketItem = new BasketItem();
            //thirdBasketItem.Id = "BI103";
            //thirdBasketItem.Name = "Usb";
            //thirdBasketItem.Category1 = "Electronics";
            //thirdBasketItem.Category2 = "Usb / Cable";
            //thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            //thirdBasketItem.Price = "0.2";
            //basketItems.Add(thirdBasketItem);
            //request.BasketItems = basketItems;

            return Payment.Create(request, options);
            //return View("Success");
        }
    }
}


//  paymentCard.CardNumber = "5400360000000003";
// paymentCard.ExpireMonth = "12";
// paymentCard.ExpireYear = "2030";
// paymentCard.Cvc = "123";
