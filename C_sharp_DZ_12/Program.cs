using System;
using static System.Console;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;
/*Разработать приложение, позволяющее определить размер диагонали монитора текущего компьютера в дюймах.*/
namespace C_sharp_DZ_12
{
    public class DllImportDiag
    {
        [DllImport("user32.dll")]
        public static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, EnumMonitorsDelegate lpfnEnum, IntPtr dwData);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    public delegate bool EnumMonitorsDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);

    public class DisplayInfo
    {
        public string Availability { get; set; }
        public string ScreenHeight { get; set; }
        public string ScreenWidth { get; set; }
        public Rect MonitorArea { get; set; }
        public Rect WorkArea { get; set; }
    }




    

    




    class Program
    {

        




        //"c:/windows/system32/user32.dll"
        static void Main(string[] args)
        {
            Title = "C_sharp_DZ_12";





            try
            {
               




            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            ReadKey();
        }
    }
}
