using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = System.Console;

namespace MyThirdDLL
{
    public class Utilities
    {
        int n, m;
       /* public void Readdata()
        {
            A.WriteLine("Enter value");
            n = int.Parse(A.ReadLine());
            A.WriteLine("Enter the Arstrng no.");
            m = int.Parse(A.ReadLine());
        }*/
        static int flag = 0;
        public static bool Primenumber_Validation(int n)
        {
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    flag = 1;
                    break;
                }
            }

            if (n == 1)
                return false;
            else
            {
                if (flag == 0)
                    return true;
                else
                    return false;
            }
        }
        public static bool Armstrong(int input)
        {
            int temp = input;
            int sum = 0;
            while (input != 0)
            {
                sum = sum + input % 10;
                input = input / 10;
            }

            if (sum == temp)
                return true;
            else
                return false;
        }
       /* public void Validation()
        {
            A.WriteLine(n + " is a Prime Number ? : " + Primenumber_Validation(n));
            A.WriteLine(m + " is Arm_num ? : " + Armstrong(m));
        }*/
    }
}
