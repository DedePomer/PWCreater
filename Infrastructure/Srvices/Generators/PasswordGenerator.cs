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
        private const string SpecialSymbolsAlphabet = "!@#-";

        private readonly int[] NumberOfNumericalAlphabet = {5};
        private readonly int[] NumberOfLowerLatinLettersAlphabet = { 1,2 };
        private readonly int[] NumberOfUpperLatinLettersAlphabet = { 3,4 };
        private readonly int[] NumberOfSpecialSymbolsAlphabet = { 6 };

        private const int CountByetsOnSha256 = 32;

        

        public string GeneratePassword (int passwordLength, SymbolAlphabet symbol, GenerationMethodEnum generationMethod) 
        {
            byte[,] hashBytes = SelectGenerationMethod(passwordLength, symbol, generationMethod);
            StringBuilder password = GetPassword(hashBytes, symbol, passwordLength);
            return password.ToString(); 
        }

        //метод для выбора способа генерации
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

        private bool IsConstArrayCorrect(int number, bool alphabet, int[] numberArrey)
        {
            for (int i = 0; i < numberArrey.Length; i++)
            {
                if (number == numberArrey[i] && alphabet == true)
                {
                    return true;
                }
            }
            return false;
        }

        //проверяет сгенерированное число
        private bool IsNumberCorrect(int number, SymbolAlphabet symbol)
        {
            if (number == NumberOfNumericalAlphabet[0])
                return true;
            else if (IsConstArrayCorrect(number, symbol.SpecialSymbols, NumberOfSpecialSymbolsAlphabet))
                return true;
            else if (IsConstArrayCorrect(number, symbol.UpperLatinLetters, NumberOfUpperLatinLettersAlphabet))
                return true;
            else if (IsConstArrayCorrect(number, symbol.LowerLatinLetters, NumberOfLowerLatinLettersAlphabet))
                return true;
            else
                return false;
        }

        //метод котырый выбирает из какого алфавита выбрать символ
        private string ChooseSymbols(SymbolAlphabet symbol)
        {
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            int randomNumber;
            byte[] randomByte = new byte[1];

            do
            {
                randomNumberGenerator.GetBytes(randomByte);
                randomNumber = randomByte[0] % 7 ;

            } while (!IsNumberCorrect(randomNumber, symbol));


            randomNumberGenerator.Dispose();

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

            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] metaIndex = new byte[1];

            for (int i = 0; i < passwordLength; i++)
            {
                randomNumberGenerator.GetBytes(metaIndex);
                alphabet = ChooseSymbols(symbol);
                int index = hsahBytes[i, metaIndex[0] % CountByetsOnSha256] % alphabet.Length;
                password.Append(alphabet[index]);
            }
            randomNumberGenerator.Dispose();
            return password;
        }

    }
}
