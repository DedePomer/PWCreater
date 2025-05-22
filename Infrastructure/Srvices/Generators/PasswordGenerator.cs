using System.Security.Cryptography;
using System.Text;
using PWCreater.Infrastructure.Enums;

namespace PWCreater.Infrastructure.Srvices.Generators
{
    public class PasswordGenerator
    {



        public string GeneratePasswordFromByte(byte[] hashBytes, int passwordLength) /*надо сделать свой тип данных для ChekBox-ов и добавить сюда*/ 
        {
            const string charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}";

            StringBuilder password = new StringBuilder();
            for (int i = 0; i < passwordLength; i++)
            {
                int index = hashBytes[i % hashBytes.Length] % charset.Length;
                password.Append(charset[index]);
            }

            return password.ToString();
        }

        private GenerationMethodEnum

    }
}
