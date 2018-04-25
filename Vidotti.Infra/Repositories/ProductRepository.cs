using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidotti.Domain.Commands.Results;
using Vidotti.Domain.Entities;
using Vidotti.Domain.Repositories;
using Vidotti.Infra.Contexts;

namespace Vidotti.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly VidottiDataContext _context;

        public ProductRepository(VidottiDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context
                .Products
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetProductListCommandResult> Get()
        {
            var query = "SELECT [Id], [Title], [Price], [Image] FROM [Product]";
            using (var conn = new SqlConnection(@"Server=localhost,11433;Database=vidottimodernstore;User ID=sa;Password=DockerSql2017!;"))
            {
                conn.Open();
                return conn.Query<GetProductListCommandResult>(query);
            }
        }
    }
}
