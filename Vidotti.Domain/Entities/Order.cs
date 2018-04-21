using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator.Validation;
using Vidotti.Domain.Enums;
using Vidotti.Shared.Entities;

namespace Vidotti.Domain.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            this.Customer = customer;
            this.CreateDate = DateTime.Now;
            this.Number = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            this.Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            this.DeliveryFee = deliveryFee;
            this.Discount = discount;

            AddNotifications(new ValidationContract()
            .Requires()
            .IsGreaterThan(this.DeliveryFee, 0, nameof(DeliveryFee), "A taxa de entrega deve ser maior que 0")
            .IsGreaterThan(this.Discount, -1, nameof(Discount), "O desconto deve ser maior ou igual a 0"));
        }
        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get { return _items.ToArray(); } }
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }

        public decimal SubTotal() => Items.Sum(x => x.Total());
        public decimal Total() => SubTotal() + DeliveryFee - Discount;

        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);
            if (item.IsValid)
                _items.Add(item);
        }
    }
}