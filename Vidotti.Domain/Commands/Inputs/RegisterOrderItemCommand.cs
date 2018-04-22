using System;
using Vidotti.Shared.Commands;

namespace Vidotti.Domain.Commands.Inputs
{
    public class RegisterOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}