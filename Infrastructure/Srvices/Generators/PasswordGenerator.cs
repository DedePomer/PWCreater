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
        private const string SpecialSymbolsAlphabet = "!!!!@@@@@#-";

        private const int CountByetsOnSha256 = 32;
        //int index = /*averageByte*/ hashBytes[i, 0 % CountByetsOnSha256] % alphabet.Length;

        public string GeneratePassword(byte[,] hashBytes, int passwordLength, SymbolAlphabet symbol) 
        {

            return ""; 
        }

        private string ChooseSymbols(SymbolAlphabet symbol)
        {
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            switch(randomNumberGenerator.Get)

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
