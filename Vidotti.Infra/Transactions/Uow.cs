using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidotti.Infra.Contexts;

namespace Vidotti.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly VidottiDataContext _context;

        public Uow(VidottiDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Do nothing :)
        }
    }
}
