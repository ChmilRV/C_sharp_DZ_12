using System;
using static System.Console;
using System.Runtime.InteropServices;
using System.Drawing;
/*Разработать приложение, позволяющее определить размер диагонали монитора текущего компьютера в дюймах.*/
namespace C_sharp_DZ_12
{
    public class DllImp
    {
        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
    }
    class Program
    {
        static void Main(string[] args)
        {
            Title = "C_sharp_DZ_12";
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                IntPtr hdc = g.GetHdc();
                WriteLine($"Диагональ экрана: {Math.Round(Math.Sqrt(Math.Pow(DllImp.GetDeviceCaps(hdc, 4), 2) + Math.Pow(DllImp.GetDeviceCaps(hdc, 6), 2)) / 25.4, 1)} дюймов.");
                WriteLine($"Разрешение экрана {DllImp.GetDeviceCaps(hdc, 8)} х {DllImp.GetDeviceCaps(hdc, 10)}.");
                WriteLine($"Частота вертикальной развертки {DllImp.GetDeviceCaps(hdc, 116)} Hz.");
                g.ReleaseHdc();
            }
            ReadKey();
        }
    }
}
