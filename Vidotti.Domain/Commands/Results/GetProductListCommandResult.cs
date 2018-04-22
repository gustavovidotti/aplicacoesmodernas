using System;
using Vidotti.Shared.Commands;

namespace Vidotti.Domain.Commands.Results
{
    public class GetProductListCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
}
}