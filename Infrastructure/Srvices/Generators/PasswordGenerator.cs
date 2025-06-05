using System;
using System.Security.Cryptography;
using System.Text;
using PWCreater.Infrastructure.Enums;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator;
using PWCreater.Model.UserType;

namespace PWCreater.Infrastructure.Srvices.Generators
{
    public class PasswordGenerator
    {
        private const string NumericalAlphabet = "1234567890";
        private const string LowerLatinLettersAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperLatinLettersAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SpecialSymbolsAlphabet = "!!!!@@@@@#-";

        private const int NumberOfNumericalAlphabet = 5;
        private const int NumberOfLowerLatinLettersAlphabet = 1;
        private const int NumberOfUpperLatinLettersAlphabet = 3;
        private const int NumberOfSpecialSymbolsAlphabet = 6;

        private const int CountByetsOnSha256 = 32;

        //int index = /*averageByte*/ hashBytes[i, 0 % CountByetsOnSha256] % alphabet.Length;

        public string GeneratePassword (int passwordLength, SymbolAlphabet symbol, GenerationMethodEnum generationMethod) 
        {
            byte[,] hashBytes = SelectGenerationMethod(passwordLength, symbol, generationMethod);
            StringBuilder password = GetPassword(hashBytes, symbol, passwordLength);
            return password.ToString(); 
        }

        private byte[,] SelectGenerationMethod(int passwordLength, SymbolAlphabet symbol, GenerationMethodEnum generationMethod)
        {
            PositionStringGenerator positionStringGenerator = new PositionStringGenerator();
            //AudioStringGenrator audioStringGenrator = new AudioStringGenrator();
            byte[,] hashBytes = { };
            switch (generationMethod)
            {
                case GenerationMethodEnum.AudioGenerator:
                    //в разоаботке
                    return hashBytes;
                case GenerationMethodEnum.CursorGenerator:
                    return positionStringGenerator.GetPasswordBytes(passwordLength, symbol);
                default:
                    return hashBytes;
            }
        }

        //проверяет сгенерированное число
        private bool IsNumberCorrect(int number, SymbolAlphabet symbol)
        {
            if (number == NumberOfNumericalAlphabet)
                return true;
            else if (number == NumberOfSpecialSymbolsAlphabet && symbol.SpecialSymbols == true)
                return true;
            else if ((number == NumberOfLowerLatinLettersAlphabet || number == NumberOfLowerLatinLettersAlphabet + 1) && symbol.LowerLatinLetters == true)
                return true;
            else if ((number == NumberOfUpperLatinLettersAlphabet || number == NumberOfUpperLatinLettersAlphabet + 1) && symbol.UpperLatinLetters == true)
                return true;
            else
                return false;
        }

        //метод котырый выбирает из какого алфавита выбрать символ
        private string ChooseSymbols(SymbolAlphabet symbol)
        {
            //не очень надёжный рандомайзер
            Random randomNumberGenerator = new Random();
            int randomNumber;

            do
            {
                randomNumber = randomNumberGenerator.Next(1, 6);
            } while (IsNumberCorrect(randomNumber, symbol));
                

            switch (randomNumber)
            {
                case 1: case 2:
                    return LowerLatinLettersAlphabet;
                case 3: case 4:
                    return UpperLatinLettersAlphabet;
                case 5:
                    return NumericalAlphabet;
                case 6:
                    return SpecialSymbolsAlphabet;
                default:
                    return NumericalAlphabet;
            };
        }

        //метод возвращающий пароль
        private StringBuilder GetPassword(byte[,] hsahBytes, SymbolAlphabet symbol, int passwordLength)
        {
            StringBuilder password = new StringBuilder(passwordLength);
            string alphabet;
            for (int i = 0; i < passwordLength; i++)
            {
                for (int o = 0; o < CountByetsOnSha256; o++)
                {
                    alphabet = ChooseSymbols(symbol);
                    int index = hsahBytes[i, o % CountByetsOnSha256] % alphabet.Length;
                    password.Append(alphabet[index]);
                }
            }
            return password;
        }

    }
}
