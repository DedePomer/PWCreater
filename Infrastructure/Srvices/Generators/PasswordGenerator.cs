using System;
using System.Security.Cryptography;
using System.Text;
using PWCreater.Infrastructure.Enums;
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
            StringBuilder password = GetPassword(, symbol, passwordLength);
            return ""; 
        }

        private byte[,] SelectGenerationMethod(GenerationMethodEnum generationMethod)
        {
            byte[,] hashBytes;

            switch (generationMethod)
            {
                case GenerationMethodEnum.AudioGenerator:

                    break;
                case GenerationMethodEnum.CursorGenerator:

                    break;
                default:

                    break;
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
