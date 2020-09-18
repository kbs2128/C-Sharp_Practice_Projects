using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = System.Console;

namespace Exercise4_Person
{
    class Person
    {
        private string firstname;
        private string lastname;
        private string email;
        private DateTime dob;
        public Person()
        {

        }

        public Person(string firstname, string lastname, DateTime dob)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.dob = dob;
        }

        public Person(string firstname, string lastname, string email)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
        }

        public Person(string firstname, string lastname, string email, DateTime dob)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.dob = dob;
        }

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Dob { get => dob; set => dob = value; }

        public bool Adult
        {
            get
            {
                if ((DateTime.Today.Year - dob.Year) >= 18)
                    return true;
                else
                    return false;

            }
        }
        public string Sunsign
        {
            get
            {
                switch (dob.Month)
                {
                    case 1:
                        if (dob.Month <= 21)
                            return "Capricorn";
                        else
                            return "Aquarius";
                    case 2:
                        if (dob.Month <= 20)
                            return "Aquarius";
                        else
                            return "Pisces";
                    case 3:
                        if (dob.Month <= 19)
                            return "Pisces";
                        else
                            return "Aries";
                    case 4:
                        if (dob.Month <= 20)
                            return "Aries";
                        else
                            return "Taurus";
                    case 5:
                        if (dob.Month <= 21)
                            return "Taurus";
                        else
                            return "Gemini";
                    case 6:
                        if (dob.Month <= 22)
                            return "Gemini";
                        else
                            return "Cancer";
                    case 7:
                        if (dob.Month <= 22)
                            return "Cancer";
                        else
                            return "Leo";
                    case 8:
                        if (dob.Month <= 22)
                            return "Leo";
                        else
                            return "Virgo";
                    case 9:
                        if (dob.Month <= 22)
                            return "Virgo";
                        else
                            return "Libra";
                    case 10:
                        if (dob.Month <= 22)
                            return "Libra";
                        else
                            return "Scorpio";
                    case 11:
                        if (dob.Month <= 22)
                            return "Scorpio";
                        else
                            return "Sagittarius";
                    case 12:
                        if (dob.Month <= 22)
                            return "Sagittarius";
                        else
                            return "Capricorn";
                    default:
                        return "Not Found";
                        break;
                }
            }
        }
        public bool Birthday
        {
            get
            {
                if (DateTime.Today.Month == dob.Month && DateTime.Today.Day == dob.Day)
                    return true;
                else
                    return false;
            }
        }
        public string Screenname
        {
            get
            {
                string screenname;
                //screenname = firstname.Substring(0, 4) + dob.Month.ToString();
                screenname = firstname + lastname;
                return screenname;

            }
        }
        static void Main(string[] args)
        {
            string fname, lname, email, dob;
            A.WriteLine("Enter the Details");
            A.WriteLine("Enter the First_Name");
            fname = A.ReadLine();
            A.WriteLine("Enter the Last_Name");
            lname = A.ReadLine();
            A.WriteLine("Enter the Email");
            email = A.ReadLine();
            A.WriteLine("Enter the DOB");
            dob = A.ReadLine();
            DateTime dt = new DateTime(int.Parse(dob.Substring(0, 4)), int.Parse(dob.Substring(4, 2)), int.Parse(dob.Substring(6, 2)));

            Person p1 = new Person(fname, lname, email, dt);
            A.WriteLine("\nThe Person is Adult or not ? " + p1.Adult);
            A.WriteLine("Sunsign: " + p1.Sunsign);
            A.WriteLine("Today is Birtday: " + p1.Birthday);
            A.WriteLine("Alloted Screenname is: " + p1.Screenname);

            string fn, ln, mail;
            A.WriteLine("\nEnter the Details");
            A.WriteLine("Enter the First_Name");
            fn = A.ReadLine();
            A.WriteLine("Enter the Last_Name");
            ln = A.ReadLine();
            A.WriteLine("Enter the Email");
            mail = A.ReadLine();

            Person p2 = new Person(fn, ln, mail);
            //A.WriteLine("\nThe Person is Adult or not ? " + p2.Adult);
            /* A.WriteLine("Sunsign: " + p2.Sunsign);
             A.WriteLine("Today is Birtday: " + p2.Birthday);*/
            A.WriteLine("Alloted Screenname is: " + p2.Screenname);

            string f, l, d;
            A.WriteLine("\nEnter the Details");
            A.WriteLine("Enter the First_Name");
            f = A.ReadLine();
            A.WriteLine("Enter the Last_Name");
            l = A.ReadLine();
            A.WriteLine("Enter the DOB");
            d = A.ReadLine();
            DateTime t = new DateTime(Convert.ToInt32(d.Substring(0, 4)), Convert.ToInt32(d.Substring(4, 2)), Convert.ToInt32(d.Substring(6, 2)));

            Person p3 = new Person(f, l, t);
            A.WriteLine("\nThe Person is Adult or not ? " + p3.Adult);
            A.WriteLine("Sunsign: " + p3.Sunsign);
            A.WriteLine("Today is Birtday: " + p3.Birthday);
            A.WriteLine("Alloted Screenname is: " + p3.Screenname);





        }
    }
}
