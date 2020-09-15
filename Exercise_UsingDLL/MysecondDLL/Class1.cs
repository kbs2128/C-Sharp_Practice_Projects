using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using A = System.Console;

namespace MysecondDll
{
    public class Class1
    {
        public int yob;
        public int mob;
        public int dob;
        public void Readdata()
        {
            A.WriteLine("Enter the Year of birth");
            yob = int.Parse(A.ReadLine());
            A.WriteLine("Enter the Month of birth");
            mob = int.Parse(A.ReadLine());
            A.WriteLine("Enter the Day of birth");
            dob = int.Parse(A.ReadLine());

        }
        public void validitycheck(int yob, int mob, int dob)
        {
            DateTime bdate = new DateTime(yob, mob, dob);
            DateTime tdate = DateTime.Today;
            int rvalue = DateTime.Compare(bdate, tdate);
            if (rvalue < 0)
            {
                if ((tdate.Year - bdate.Year) >= 135)
                {

                    A.WriteLine("You are lucky to have lived>=135 years");

                }
                else if ((mob == DateTime.Today.Month && dob == DateTime.Today.Day))
                {
                    A.WriteLine("Hey Happy Birthday");
                    int y = (tdate.Year - bdate.Year);
                    int m = (tdate.Month - bdate.Month);
                    if (m < 0)
                        m = -(m);
                    int d = (tdate.Day - bdate.Day);
                    if (d < 0)
                        d = -(d);
                    A.WriteLine("Your Age is: " + y + " Years " + m + " Months " + d + " days");

                }
                else
                {
                    int y = (tdate.Year - bdate.Year);
                    int m = (tdate.Month - bdate.Month);
                    if (m < 0)
                        m = -(m);
                    int d = (tdate.Day - bdate.Day);
                    if (d < 0)
                        d = -(d);
                    A.WriteLine("Your Age is: " + y + " Years " + m + " Months " + d + " days");

                }
            }
            else if (rvalue == 0)
            {
                if (tdate.Day - bdate.Day == 0)
                {
                    A.WriteLine("Hey You are born this day");

                }
                else if (tdate.Year == bdate.Year)
                {
                    int y = (tdate.Year - bdate.Year);
                    int m = (tdate.Month - bdate.Month);
                    if (m < 0)
                        m = -(m);
                    int d = (tdate.Day - bdate.Day);
                    if (d < 0)
                        d = -(d);
                    A.WriteLine("Your Age is: " + y + " Years " + m + " Months " + d + " days");

                }

            }
            else
            {
                A.WriteLine("OOPS! You have entered a future date");
            }
        }
        public string Sunsign(int mob, int dob)
        {
            switch (mob)
            {
                case 1:
                    if (dob <= 21)
                        return "Capricorn";
                    else
                        return "Aquarius";
                case 2:
                    if (dob <= 20)
                        return "Aquarius";
                    else
                        return "Pisces";
                case 3:
                    if (dob <= 19)
                        return "Pisces";
                    else
                        return "Aries";
                case 4:
                    if (dob <= 20)
                        return "Aries";
                    else
                        return "Taurus";
                case 5:
                    if (dob <= 21)
                        return "Taurus";
                    else
                        return "Gemini";
                case 6:
                    if (dob <= 22)
                        return "Gemini";
                    else
                        return "Cancer";
                case 7:
                    if (dob <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case 8:
                    if (dob <= 22)
                        return "Leo";
                    else
                        return "Virgo";
                case 9:
                    if (dob <= 22)
                        return "Virgo";
                    else
                        return "Libra";
                case 10:
                    if (dob <= 22)
                        return "Libra";
                    else
                        return "Scorpio";
                case 11:
                    if (dob <= 22)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case 12:
                    if (dob <= 22)
                        return "Sagittarius";
                    else
                        return "Capricorn";
                default:
                    return "Not Found";
                    break;

            }
        }
    }
}
