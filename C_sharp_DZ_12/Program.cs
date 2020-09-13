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

    public class MONITOR_INFO_2
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumMonitors(string pName, uint level, IntPtr pMonitors, uint cbBuf, ref uint pcbNeeded, ref uint pcReturned);
        public const int ERROR_INSUFFICIENT_BUFFER = 122;
        public static List<MONITOR_INFO_2> GetMonitors()
        {
            List<MONITOR_INFO_2> ports = new List<MONITOR_INFO_2>();
            uint pcbNeeded = 0;
            uint pcReturned = 0;

            if (EnumMonitors(null, 2, IntPtr.Zero, 0, ref pcbNeeded, ref pcReturned))
            {
                //succeeds, but must not, because buffer is zero (too small)!
                throw new Exception("EnumMonitors should fail!");
            }

            int lastWin32Error = Marshal.GetLastWin32Error();
            if (lastWin32Error == ERROR_INSUFFICIENT_BUFFER)
            {

                IntPtr pMonitors = Marshal.AllocHGlobal((int)pcbNeeded);
                if (EnumMonitors(null, 2, pMonitors, pcbNeeded, ref pcbNeeded, ref pcReturned))
                {
                    IntPtr currentMonitor = pMonitors;

                    for (int i = 0; i < pcReturned; i++)
                    {
                        ports.Add((MONITOR_INFO_2)Marshal.PtrToStructure(currentMonitor, typeof(MONITOR_INFO_2)));
                        currentMonitor = (IntPtr)(currentMonitor.ToInt32() + Marshal.SizeOf(typeof(MONITOR_INFO_2)));
                    }
                    Marshal.FreeHGlobal(pMonitors);

                    return ports;
                }
            }
            throw new Win32Exception(Marshal.GetLastWin32Error());

        }


    }

    //http://pinvoke.net/default.aspx/user32/EnumDisplayMonitors.html


    



    class Program
    {

        



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
