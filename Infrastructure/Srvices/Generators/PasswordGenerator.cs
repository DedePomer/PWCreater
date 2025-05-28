using System.Security.Cryptography;
using System.Text;
using PWCreater.Infrastructure.Enums;
using PWCreater.Model.UserType;

namespace PWCreater.Infrastructure.Srvices.Generators
{
    public class PasswordGenerator
    {
        private const string NumberAlphabet = "1234567890";
        private const string LowerLatinLettersAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperLatinLettersAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SpecialSymbolsAlphabet = "!!!!!!!@@@@@@@@#-";

        private const int CountByetsOnSha256 = 32;


        public string GeneratePasswordFromByte(byte[,] hashBytes, int passwordLength, SymbolAlphabet symbol) 
        {
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            string alphabet = AlphabetCreater(symbol);
            StringBuilder password = new StringBuilder(passwordLength);

            for (int i = 0; i < passwordLength; i++)
            {
                int averageByte = 0;
                for (int y = 0; y < CountByetsOnSha256; y++)
                {
                    averageByte += hashBytes[i, y];
                }
                averageByte /= CountByetsOnSha256;
                int index = /*averageByte*/ hashBytes[i, 0 % CountByetsOnSha256] % alphabet.Length;
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
