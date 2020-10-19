using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = System.Console;
using MyThirdDLL;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities u1 = new Utilities();
            //u1.Readdata();
            //u1.Validation();
            int n = int.Parse(A.ReadLine());
            A.WriteLine(n + " is pm_? : " + Utilities.Primenumber_Validation(n));
        }
    }
}
