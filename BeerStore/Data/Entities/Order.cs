using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerStore.Data.Entities
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public DateTime Date { get; set; }

        [BindNever]
        [MaxLength(10)]
        public string Number { get; set; }

        [BindNever]
        [MaxLength(450)]
        public string UserId { get; set; }        

        [BindNever]
        [MaxLength(256)]
        public string FirstName { get; set; }

        [BindNever]
        [MaxLength(256)]
        public string LastName { get; set; }

        [BindNever]
        public Customer Customer { get; set; }

        [BindNever]
        public Outlet Outlet { get; set; }

        [BindNever]
        public Warehouse Warehouse { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        public bool ThisReturn { get; set; }

        public bool Finance { get; set; }

        public PayType PayType { get; set; }

        public string Comment { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
    }

    public enum PayType
    {
        [Display(Name = "Наличные")]
        Cash,
        [Display(Name = "Безналичные")]
        Cashless,
        [Display(Name = "Отсрочка платежа")]
        DelayOfPayment
    }
}
