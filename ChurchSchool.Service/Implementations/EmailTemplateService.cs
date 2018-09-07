using ChurchSchool.Service.Contracts;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChurchSchool.Service.Implementations
{
    public class EmailTemplateService : IEmailTemplateService
    {
        private IFileProvider _fileProvider;

        public EmailTemplateService()
        {
            
        }

        public String GetEmailTemplate(string fileName)
        {

            var file = _fileProvider.GetFileInfo($@"\EmailTemplates\${fileName}");

            if (file.Exists)
            {
                var content = System.IO.File.ReadAllText(file.PhysicalPath);
                return content;
            }

            return string.Empty;
        }
    }
}
