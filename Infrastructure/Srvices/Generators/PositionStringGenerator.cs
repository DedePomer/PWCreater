using PWCreater.Infrastructure.Enums;
using PWCreater.Infrastructure.Interfaces;
using PWCreater.Infrastructure.Structurs;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PWCreater.Infrastructure.Srvices.Generators
{
    public class PositionStringGenerator : IStringGenerator
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out PointStruct lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        private const int FistZone = 2;
        private const int SecondZone = 2;
        private const int ThirdZone = 20;
        private const int FourthZone = 20;
        private const int FifthZone = 10;
        private const int SixthZone = 10;



        public string[] GetGeneratedString(int stringCount)
        {
            throw new NotImplementedException();
        }








        //метод для получения маштаба интерфейса, не используется
        /*private static float GetScalingFactor()
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
