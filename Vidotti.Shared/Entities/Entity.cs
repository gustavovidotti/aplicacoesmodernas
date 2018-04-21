using System;
using FluentValidator;

namespace Vidotti.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid();

        }
        public Guid Id { get; private set; }
    }
}