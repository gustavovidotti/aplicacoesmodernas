using Vidotti.Domain.Entities;

namespace Vidotti.Domain.Repositories
{
   public interface IOrderRepository
    {
        void Save(Order order);
}
}