using System;
using Vidotti.Shared.Entities;

namespace Vidotti.Domain.Entities
{
    public class User : Entity
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Active = true;

        }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;
    }
}