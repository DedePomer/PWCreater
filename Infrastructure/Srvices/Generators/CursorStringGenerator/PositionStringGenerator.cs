using PWCreater.Infrastructure.Interfaces;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator.DataType;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator.Enums;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator.Structurs;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator
{
    public class PositionStringGenerator : IStringGenerator
    {
        /*константы для определения границ зон*/
        private const float OneFourth = 0.25f;
        private const float TwoFourths = 0.5f;
        private const float ThreeFourths = 0.75f;
        private const float OneThrid = 0.33f;
        private const float TwoThrids = 0.67f;
        private const float Unit = 1f;
        private const float Zero = 0f;


        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out PointStruct lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        private int _countDotInFistZone = 2;
        private int _countDotInSecondZone = 2;
        private int _countDotInThirdZone = 20;
        private int _countDotInFourthZone = 20;
        private int _countDotInFifthZone = 10;
        private int _countDotInSixthZone = 10;



        public string[] GetPasswordString(int symbolCount)
        {
            string[] dots = GetCheckedString(symbolCount);
            string[] symbolString = new string[symbolCount];
            for (int i = 0; i < symbolCount; i++)
            {
                GetHASHbytes(dots[i]);
            }
        }

        private byte[] GetHASHbytes(string generatedString)
        {
            byte[] convertedString = Encoding.UTF8.GetBytes(generatedString);
            using (SHA256 mySHA256 = SHA256.Create())
            {
                return mySHA256.ComputeHash(convertedString);
            }
        }

        private string[] GetCheckedString(int stringCount)
        {
            string[] dots = new string[stringCount];
            int x = 0, y = 0;

            for (int i = 0; i < dots.Length; i++)
            {
                PointStruct point;
                if (GetCursorPos(out point) && point.X != x && point.Y != y
                    && IsChangedCountDotsInZone(new DotDataType() { X = point.X, Y = point.Y }))
                {
                    dots[i] = point.X + "" + point.Y;
                    x = point.X;
                    y = point.Y;
                }
                Thread.Sleep(300);
            }

            return dots;
        }

        private bool IsChangedCountDotsInZone(DotDataType dot)
        {
            ScreenResolutionDataType screenResolution = GetScreenResolution();
            RectangleZoneDataType firstZone = new RectangleZoneDataType(
        new DotDataType
        { X = screenResolution.Widh * OneFourth, Y = screenResolution.Height * OneThrid },
        new DotDataType
        { X = screenResolution.Widh * TwoFourths, Y = screenResolution.Height * TwoThrids });
            RectangleZoneDataType secondZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * TwoFourths, Y = screenResolution.Height * OneThrid },
                new DotDataType
                { X = screenResolution.Widh * ThreeFourths, Y = screenResolution.Height * TwoThrids });
            RectangleZoneDataType thirdZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * ThreeFourths, Y = screenResolution.Height * Zero },
                new DotDataType
                { X = screenResolution.Widh * Unit, Y = screenResolution.Height * Zero });
            RectangleZoneDataType fourthZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * Zero, Y = screenResolution.Height * Zero },
                new DotDataType
                { X = screenResolution.Widh * OneFourth, Y = screenResolution.Height * Unit });
            RectangleZoneDataType fifthZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * OneFourth, Y = screenResolution.Height * Zero },
                new DotDataType
                { X = screenResolution.Widh * ThreeFourths, Y = screenResolution.Height * OneThrid });
            RectangleZoneDataType sixthZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * OneFourth, Y = screenResolution.Height * TwoThrids },
                new DotDataType
                { X = screenResolution.Widh * ThreeFourths, Y = screenResolution.Height * Unit });

            if (IsDotLiesOnZone(dot, firstZone) && _countDotInFistZone > 0)
            {
                _countDotInFistZone--;
                return true;
            }

            if (IsDotLiesOnZone(dot, secondZone) && _countDotInSecondZone > 0)
            {
                _countDotInSecondZone--;
                return true;
            }

            if (IsDotLiesOnZone(dot, thirdZone) && _countDotInThirdZone > 0)
            {
                _countDotInThirdZone--;
                return true;
            }

            if (IsDotLiesOnZone(dot, fourthZone) && _countDotInFourthZone > 0)
            {
                _countDotInFourthZone--;
                return true;
            }

            if (IsDotLiesOnZone(dot, fifthZone) && _countDotInFifthZone > 0)
            {
                _countDotInFifthZone--;
                return true;
            }

            if (IsDotLiesOnZone(dot, sixthZone) && _countDotInSixthZone > 0)
            {
                _countDotInSixthZone--;
                return true;
            }

            return false;
        }

        private ScreenResolutionDataType GetScreenResolution() /*не проверял с несколькими экранами*/
        {
            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = graphics.GetHdc();

            ScreenResolutionDataType screenResolution = new ScreenResolutionDataType();
            screenResolution.Widh = GetDeviceCaps(desktop, (int)DeviceCapEnum.HORZRES);
            screenResolution.Height = GetDeviceCaps(desktop, (int)DeviceCapEnum.VERTRES);
            return screenResolution;
        }

        private bool IsDotLiesOnZone(DotDataType dot, RectangleZoneDataType zone) /*только для 4 чертверти системы координат*/
        {
            if ((dot.X > zone.firstPoint.X && dot.Y > zone.firstPoint.Y) && (dot.X < zone.secondPoint.X && dot.Y < zone.secondPoint.Y))
            {
                return true;
            }
            return false;
        }







        //метод для получения маштаба интерфейса, не используется
        /*private float GetScalingFactor()
        {
            using Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCapEnum.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCapEnum.DESKTOPVERTRES);

            g.ReleaseHdc(desktop);

            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;
            g.Dispose();

            return ScreenScalingFactor; // 1.25 = 125%
        }*/
    }
}
