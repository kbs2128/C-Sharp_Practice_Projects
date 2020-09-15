using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using A = System.Console;
using MysecondDll;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 a = new Class1();
            try
            {
                a.Readdata();
            }
            catch (FormatException e)
            {
                A.WriteLine("Inappropriate Input");
                A.WriteLine("Enter the accurate credentials this time\n");
                a.Readdata();
            }

            a.validitycheck(a.yob, a.mob, a.dob);
            A.WriteLine("Your Sunsign is " + a.Sunsign(a.mob, a.dob));
        }
    }
}
