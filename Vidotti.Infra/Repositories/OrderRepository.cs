using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidotti.Domain.Entities;
using Vidotti.Domain.Repositories;
using Vidotti.Infra.Contexts;

namespace Vidotti.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly VidottiDataContext _context;

        public OrderRepository(VidottiDataContext context)
        {
            _context = context;
        }

        public void Save(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}
