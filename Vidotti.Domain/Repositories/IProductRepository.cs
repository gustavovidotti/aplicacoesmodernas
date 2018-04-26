using System;
using System.Collections.Generic;
using Vidotti.Domain.Commands.Results;
using Vidotti.Domain.Entities;

namespace Vidotti.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<GetProductListCommandResult> Get();
}
}