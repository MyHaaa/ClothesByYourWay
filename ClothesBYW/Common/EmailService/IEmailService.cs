using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Common.EmailService
{
    public interface IEmailService
    {
        void Send(string from, string to, string subject, string html);
    }
}