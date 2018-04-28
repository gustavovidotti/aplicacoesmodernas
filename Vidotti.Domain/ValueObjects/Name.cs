using FluentValidator;
using FluentValidator.Validation;

namespace Vidotti.Domain.ValueObjects
{
public class Name : Notifiable
    {
        protected Name() { }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
            .Requires()
            .HasMinLen(FirstName, 3, nameof(FirstName), "O nome deve conter pelo menos 3 caracteres")
            .HasMaxLen(FirstName, 40, nameof(FirstName), "O nome deve conter no maximo 40 caracteres")
            .HasMinLen(LastName, 3, nameof(LastName), "O sobrenome deve conter pelo menos 3 caracteres")
            .HasMaxLen(LastName, 40, nameof(LastName), "O sobrenome deve conter no maximo 40 caracteres"));              
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
}
}