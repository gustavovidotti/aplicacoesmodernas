using System;
using Vidotti.Domain.Entities;

namespace Vidotti.Domain.Repositories
{
  public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByUsername(string username);
        //GetCustomerCommandResult Get(string username);
        void Save(Customer customer);
        void Update(Customer customer);
        bool DocumentExists(string document);        
}
}