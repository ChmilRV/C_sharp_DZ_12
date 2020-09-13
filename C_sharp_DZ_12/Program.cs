using System;
using static System.Console;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
/*Разработать приложение, позволяющее определить размер диагонали монитора текущего компьютера в дюймах.*/
namespace C_sharp_DZ_12
{
    public class DiagonalFromDll
    {
        //"C:/Windows/System32/wbem/cimwin32.dll"
        [DllImport("cimwin32.dll")]
        public static extern int ScreenHeight();


    }

    class Program
    {



        static void Main(string[] args)
        {
            Title = "C_sharp_DZ_12";
            //Assembly a = Assembly.Load("C:/Windows/System32/wbem/cimwin32.dll");
            try
            {

                WriteLine(DiagonalFromDll.ScreenHeight());


            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }



            



            ReadKey();
        }
    }
}
