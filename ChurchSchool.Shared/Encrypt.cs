using System.Security.Cryptography;
using System.Text;

namespace ChurchSchool.Shared
{
    public class Encrypt
    {
        public static string Hash(string content)
        {
            var hashObj = SHA512.Create();
            var encryptedContent = hashObj.ComputeHash(Encoding.UTF8.GetBytes(content));

            var encryptedOutput = new StringBuilder();
            
            foreach (var item in encryptedContent)
            {
                encryptedOutput.Append(item.ToString("x2"));
            }

            return encryptedOutput.ToString();
        }
    }
}
