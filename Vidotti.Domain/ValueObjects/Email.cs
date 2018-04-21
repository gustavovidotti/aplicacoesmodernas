using FluentValidator;
using FluentValidator.Validation;

namespace Vidotti.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
            .Requires()
            .IsEmail(Address, nameof(Address), "O E-mail é inválido"));
        }

        public string Address { get; private set; }
    }
}