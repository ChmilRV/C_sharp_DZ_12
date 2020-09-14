using System;
using static System.Console;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
/*Разработать приложение, позволяющее определить размер диагонали монитора текущего компьютера в дюймах.*/
namespace C_sharp_DZ_12
{
    public class DllImportDiag
    {
        [DllImport("user32.dll")]
        public static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, EnumMonitorsDelegate lpfnEnum, IntPtr dwData);
        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hmon, ref MonitorInfo mi);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MonitorInfo
    {
        public uint size;
        public Rect monitor;
        public Rect work;
        public uint flags;
    }
    public delegate bool EnumMonitorsDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);

    public class DisplayInfo
    {
        public string ScreenHeight { get; set; }
        public string ScreenWidth { get; set; }
    }
    public class DisplayInfoCollection : List<DisplayInfo>
    {
        public DisplayInfoCollection GetDisplays()
        {
            DisplayInfoCollection col = new DisplayInfoCollection();
            DllImportDiag.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                delegate (IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
                {
                    MonitorInfo mi = new MonitorInfo();
                    //mi.size = (uint)Marshal.SizeOf(mi);
                    bool success = DllImportDiag.GetMonitorInfo(hMonitor, ref mi);
                    if (success)
                    {
                        DisplayInfo di = new DisplayInfo();
                        di.ScreenWidth = (mi.monitor.right - mi.monitor.left).ToString();
                        di.ScreenHeight = (mi.monitor.bottom - mi.monitor.top).ToString();
                        WriteLine(di.ScreenWidth);
                        WriteLine(di.ScreenHeight);
                        col.Add(di);
                    }
                    return true;
                },
                IntPtr.Zero);
            return col;
        }


    }



    class Program
    {

        //public DisplayInfoCollection GetDisplays()
        //{
        //    DisplayInfoCollection col = new DisplayInfoCollection();
        //    DllImportDiag.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
        //        delegate (IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
        //        {
        //            MonitorInfo mi = new MonitorInfo();
        //            //mi.size = (uint)Marshal.SizeOf(mi);
        //            bool success = DllImportDiag.GetMonitorInfo(hMonitor, ref mi);
        //            if (success)
        //            {
        //                DisplayInfo di = new DisplayInfo();
        //                di.ScreenWidth = (mi.monitor.right - mi.monitor.left).ToString();
        //                di.ScreenHeight = (mi.monitor.bottom - mi.monitor.top).ToString();
        //                WriteLine(di.ScreenWidth);
        //                WriteLine(di.ScreenHeight);
        //                col.Add(di);
        //            }
        //            return true;
        //        },
        //        IntPtr.Zero);
        //    return col;
        //}


        static void Main(string[] args)
        {
            Title = "C_sharp_DZ_12";
            DisplayInfoCollection col = new DisplayInfoCollection();
            
            //  Запутался с реализацией...

            
            


            ReadKey();
        }
    }
}
