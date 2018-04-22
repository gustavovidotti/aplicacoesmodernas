using System;
using System.Collections.Generic;
using Vidotti.Shared.Commands;

namespace Vidotti.Domain.Commands.Inputs
{
    public class RegisterOrderCommand : ICommand
    {
        public Guid Customer { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }
}
}