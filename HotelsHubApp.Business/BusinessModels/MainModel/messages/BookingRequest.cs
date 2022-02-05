using Business.BusinessModel.MainModel.model;
using System;
using System.Collections.Generic;

namespace HotelsHubApp.Business.BusinessModels.MainModel.messages
{
    public class BookingRequest
    {
        public Authentication Authentication { get; set; }
        public Holder holder { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public object Paymenttype { get; set; }
        public string Nationality { get; set; }
        public int TimeoutMs { get; set; }
        public string HotelCode { get; set; }
        public string VoucherEmail { get; set; }
        public string Language { get; set; }
        public IList<BookingRoom> Rooms { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
