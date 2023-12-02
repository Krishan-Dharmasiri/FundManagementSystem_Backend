using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Models.Mail
{
    public class Email
    {
        /*
         * This is a just a class or type that is requjired as part of the Email service
         * This has nothing to do with the Domain entities and not persisted in the DB either
         * Hence this should not be declared in the Domain project
         */
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
