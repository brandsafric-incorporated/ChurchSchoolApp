using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Service.Contracts
{
    public interface IEmailTemplateService
    {
        String GetEmailTemplate(string fileName);
    }
}
