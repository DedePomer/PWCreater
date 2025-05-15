using PWCreater.Infrastructure.Interfaces;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator.DataType;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator.Enums;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator.Structurs;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator
{
    public class PositionStringGenerator : IStringGenerator
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out PointStruct lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        private int _fistZone = 2;
        private int _secondZone = 2;
        private int _thirdZone = 20;
        private int _fourthZone = 20;
        private int _fifthZone = 10;
        private int _sixthZone = 10;



        public string[] GetGeneratedString(int stringCount)
        {
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
