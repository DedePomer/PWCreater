using System;
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

        private bool IsNumberCorrect(int number, SymbolAlphabet symbol)
        { 
            
        }


        private string ChooseSymbols(SymbolAlphabet symbol)
        {
            //не очень надёжный рандомайзер
            Random randomNumberGenerator = new Random();
            int randomNumber;

            do 
            {
                randomNumber = randomNumberGenerator.Next(1, 6)
            } while()
                

            switch ()
            {
                case 1: case 2:
                    return LowerLatinLettersAlphabet;

                case 3: case 4:
                    return UpperLatinLettersAlphabet;
                case 5:
                    return NumberAlphabet;
                case 6:
                    return SpecialSymbolsAlphabet;
                default:
                    return NumberAlphabet;
            };
        }

    }
}
