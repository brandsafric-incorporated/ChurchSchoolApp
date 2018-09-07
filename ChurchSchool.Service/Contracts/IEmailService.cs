using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Service.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string to, string title, string content, bool isHtmlBody);
    }
}
