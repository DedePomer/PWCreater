using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWCreater.Infrastructure.Srvices
{
    public class StringToInt
    {
        //конвертируеи числа только до 99
        public int ConvertStringToInt(string strokeToConvert)
        {
            int number = 0;
            for (int i = 0; i < strokeToConvert.Length; i++)
            {
                if (strokeToConvert.Length == 1)
                {
                    number += ConvertCahrToInt(strokeToConvert[i]);
                }
                else if (strokeToConvert.Length == 2)
                {
                    if (i == 0)
                    {
                        number += ConvertCahrToInt(strokeToConvert[i]) * 10;
                    }
                    else if (i == 1)
                    {
                        number += ConvertCahrToInt(strokeToConvert[i]);
                    }
                }         
                            
            }
            return number;
        }
        private int ConvertCahrToInt(char symbol)
        {
            switch (symbol)
            {
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case '0':
                    return 0;
                default:
                    return 0;

            }
        }

    }
}
