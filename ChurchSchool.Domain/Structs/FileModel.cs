using System;
using System.Linq;

namespace ChurchSchool.Domain.Models
{
    public class FileModel
    {
        public string FileName { get; private set; }
        public byte[] Content { get; private set; }

        public FileModel(string fileName, byte[] content)
        {
            if (content.Any())
                throw new ArgumentException("Content is empty");

            this.FileName = fileName;
            this.Content = content;
        }


        public FileModel(string fileName, string base64Content)
        {
            if (string.IsNullOrEmpty(base64Content))
                throw new ArgumentException("Content is empty");

            this.FileName = fileName;
            this.Content = Convert.FromBase64String(base64Content);
        }

    }
}
