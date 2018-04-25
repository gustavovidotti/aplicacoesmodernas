using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidotti.Domain.Services;

namespace Vidotti.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string name, string email, string subject, string body)
        {
            // System.Net.Mail => Enviar E-mail
        }
    }
}
