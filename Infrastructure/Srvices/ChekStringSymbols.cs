using System;

namespace PWCreater.Infrastructure.Srvices
{
    public class ChekStringSymbols
    {
        private bool ThisStrigIsNumber(string number)
        {
            char[] numbers = number.ToCharArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                switch (numbers[i])
                {
                    case '0':
                        break;
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case '6':
                        break;
                    case '7':
                        break;
                    case '8':
                        break;
                    case '9':
                        break;
                    default:
                        return false;

                }


            }

            return true;
        }

        public bool IsNumberSuitable(string number)
        {
            if (ThisStrigIsNumber(number) && number.Length > 0)
            {
                int intNumber = Convert.ToInt32(number);
                if (intNumber > 0 && intNumber < 33)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
