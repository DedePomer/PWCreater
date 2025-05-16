using PWCreater.Infrastructure.Interfaces;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator.DataType;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator.Enums;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator.Structurs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

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

        private RectangleZoneDataType _firstZone; /*спросить у миши как можно реализовать это по эстетичнее*/
        private RectangleZoneDataType _secondZone;
        private RectangleZoneDataType _thirdZone;
        private RectangleZoneDataType _fourthZone;
        private RectangleZoneDataType _fifthZone;
        private RectangleZoneDataType _sixthZone;





        public string[] GetGeneratedString(int stringCount)
        {
            List<string> dots = new List<string>();
            ScreenResolutionDataType screenResolution = GetScreenResolution();
            _firstZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * OneFourt, Y = screenResolution.Height * OneThrid },
                new DotDataType
                { X = screenResolution.Widh * TwoFourths, Y = screenResolution.Height * TwoThrids });
            _secondZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * TwoFourths, Y = screenResolution.Height * OneThrid },
                new DotDataType
                { X = screenResolution.Widh * ThreeFourths, Y = screenResolution.Height * TwoThrids });
            _thirdZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * ThreeFourths, Y = screenResolution.Height * Zero },
                new DotDataType
                { X = screenResolution.Widh * Unit, Y = screenResolution.Height * Zero });
            _fourthZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * Zero, Y = screenResolution.Height * Zero },
                new DotDataType
                { X = screenResolution.Widh * OneFourth, Y = screenResolution.Height * Unit });
            _fifthZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * OneFourth, Y = screenResolution.Height * Zero },
                new DotDataType
                { X = screenResolution.Widh * ThreeFourths, Y = screenResolution.Height * OneThrid });
            _sixthZone = new RectangleZoneDataType(
                new DotDataType
                { X = screenResolution.Widh * OneFourth, Y = screenResolution.Height * TwoThrids },
                new DotDataType
                { X = screenResolution.Widh * ThreeFourths, Y = screenResolution.Height * Unit });


            throw new NotImplementedException();
        }

        private  ScreenResolutionDataType GetScreenResolution() /*не проверял с несколькими экранами*/
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
