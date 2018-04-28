using FluentValidator;
using Vidotti.Domain.Commands.Inputs;
using Vidotti.Domain.Commands.Results;
using Vidotti.Domain.Entities;
using Vidotti.Domain.Repositories;
using Vidotti.Domain.Resources;
using Vidotti.Domain.Services;
using Vidotti.Domain.ValueObjects;
using Vidotti.Shared.Commands;

namespace Vidotti.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable,
            ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            // Passo 1. Verificar se o CPF já existe
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification(nameof(Document), "Este CPF já está em uso!");
                return null;
            }

            // Passo 2. Gerar o novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, email, document, user);

            // Passo 3. Adicionar as notificação
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            if (!IsValid)
                return null;

            // Passo 4. Inserir no banco
            _customerRepository.Save(customer);

            // Passo 5. Enviar E-mail de boas vindas     
            //https://foundation.zurb.com/emails/email-templates.html
            _emailService.Send(
                customer.Name.ToString(),
                customer.Email.Address,
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name));

            // Passo 6. Retornar algo
            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());
        }
    }
}