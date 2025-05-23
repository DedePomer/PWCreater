using System.Security.Cryptography;
using System.Text;
using PWCreater.Infrastructure.Enums;
using PWCreater.Model.UserType;

namespace PWCreater.Infrastructure.Srvices.Generators
{
    public class PasswordGenerator
    {
        private const string NumberAlphabet = "123456789";
        private const string LowerLatinLettersAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperLatinLettersAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SpecialSymbolsAlphabet = "!@#-";


        public string GeneratePasswordFromByte(byte[] hashBytes, int passwordLength, SymbolAlphabet symbol) 
        {          
            string alphabet = AlphabetCreater(symbol);
            StringBuilder password = new StringBuilder(passwordLength);

            for (int i = 0; i < passwordLength; i++)
            {
                int index = hashBytes[i % hashBytes.Length] % alphabet.Length;
                password.Append(alphabet[index]);
            }

            return password.ToString();
        }

        private string AlphabetCreater(SymbolAlphabet symbol)
        {
            string alphabet = NumberAlphabet;
            if (symbol.LowerLatinLetters)
            {
                alphabet += LowerLatinLettersAlphabet;
            }
            if (symbol.UpperLatinLetters)
            {
                alphabet += UpperLatinLettersAlphabet;
            }
            if (symbol.SpecialSymbols)
            {
                alphabet += SpecialSymbolsAlphabet;
            }
            return alphabet;
        }

    }
}
