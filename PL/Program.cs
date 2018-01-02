using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;


namespace PL
{
    class Program
    {
        static IBL bl = FactoryBL.GetBL();
        static DateTime[,] add = new DateTime[6, 2];
        static bool[] work = new bool[6];
        public static void needNanny()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("work in " + (DayOfWeek)i + "?");
                char b = Convert.ToChar(Console.ReadLine());
                while (b != 'y' && b != 'n')
                    b = Convert.ToChar(Console.ReadLine());
                if (b == 'n')
                    work[i] = false;
                else work[i] = true;
            }
        }
        public static void workDays()
        {


            int hour, minutes;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("work in " + (DayOfWeek)i + "?");
                char b = Convert.ToChar(Console.ReadLine());
                while (b != 'y' && b != 'n')
                    b = Convert.ToChar(Console.ReadLine());
                if (b == 'n')
                    work[i] = false;
                else work[i] = true;
                Console.WriteLine("enter the start time of " + (DayOfWeek)i + "/n");
                Console.WriteLine("hour:");
                hour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("/n minute:");
                minutes = Convert.ToInt32(Console.ReadLine());
                add[i, 0] = new DateTime(hour, minutes, 0);
                Console.WriteLine("enter the end time of " + (DayOfWeek)i + "/n");
                Console.WriteLine("hour:");
                hour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("/n minute:");
                minutes = Convert.ToInt32(Console.ReadLine());
                add[i, 1] = new DateTime(hour, minutes, 0);


            }


        }


        public static void mother()
        {
            Console.WriteLine("\nmother operations\n" +
                              "0: return\n" +
                              "1: delete mother\n" +
                              "2: add mother\n" +
                              "3: update mother\n" +
                              "4: search for a mother by ID number\n" +
                              "5: print all mothers in the database\n" +
                              "6: search nannies for a particular mother\n" +
                              "7: print specific mother data\n");
            int select = Convert.ToInt32(Console.ReadLine());
            if (select != 0)
                switch (select)
                {
                    case 1:
                        Console.WriteLine("enter the ID of mother to delete");
                        int id = Convert.ToInt32(Console.ReadLine());
                        bl.deleteMother(bl.getMother(id));
                        break;
                    case 2:
                        addMother();
                        break;
                    case 3:
                        updateMother();
                        break;
                    case 4:
                        break;
                    case 5:
                        foreach (var m in bl.GetAllMother())
                        {
                            Console.WriteLine(m.ToString());
                        }

                        break;
                }
        }






        static void addMother()
        {
            try
            {

                Console.WriteLine("enter the ID of mother");
                int id = Convert.ToInt32(Console.ReadLine());
                Mother temp = new Mother();
                Console.WriteLine("enter first name");
                temp.FirstName = Console.ReadLine();
                Console.WriteLine("enter last name");
                temp.LastName = Console.ReadLine();
                Console.WriteLine("enter the phone number");
                temp.Phone = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the address");
                temp.Adress = Console.ReadLine();
                Console.WriteLine("Other search address? [y/n]  (if yes enter the address)");
                char flag = Convert.ToChar(Console.ReadLine());
                if (flag == 'y')
                    temp.DesiredAddressOfNanny = Console.ReadLine();
                needNanny();
                temp.DaysOfNeedingNanny = work;
                Console.WriteLine("Recommendations");
                temp.Recommendations = Console.ReadLine();
                bl.addMother(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        static void nanny()
        {
            Console.WriteLine("\nnanny operations\n" +
                              "0: return\n" +
                              "1: delete nanny\n" +
                              "2: add nanny\n" +
                              "3: update nanny\n" +
                              "4: search for a nanny by ID number\n" +
                              "5: print all nannys in the database\n" +
                              "6: search for a particular nanny\n" );
            int select = Convert.ToInt32(Console.ReadLine());
            if (select != 0)
                switch (select)
                {
                    case 1:
                        Console.WriteLine("enter the ID of nanny to delete");
                        int id = Convert.ToInt32(Console.ReadLine());
                        bl.deleteNanny(bl.getNanny(id));
                        break;
                    case 2:
                        addNanny();
                        break;
                    case 3:
                        updateNanny();
                        break;
                    case 4:
                        Console.WriteLine("enter id");
                        int ID = Convert.ToInt32(Console.ReadLine());
                        bl.getNanny(ID);
                        break;
                    case 5:
                        foreach (var mother in bl.GetAllNanny())
                        {
                            Console.WriteLine(mother.ToString());
                        }
                        break;
                }
        }
        private static void updateNanny()
        {
            try
            {
                Console.WriteLine("enter the ID of nanny");
                int id = Convert.ToInt32(Console.ReadLine());
                Nanny temp = new Nanny();
                Console.WriteLine("enter first name");
                temp.FirstName = Console.ReadLine();
                Console.WriteLine("enter last name");
                temp.LastName = Console.ReadLine();
                Console.WriteLine("enter the phone number");
                temp.Phone = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the address");
                temp.Adress = Console.ReadLine();
                Console.WriteLine("what is you are scheculde ?");
                workDays();
                temp.WorkDays = work;
                temp.WorkHours = add;
                Console.WriteLine("enter the oldes child in your responsiblty");
                temp.MaxAgeOfChild = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the youngest child in your responsiblty");
                temp.MinAgeOfChild = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("are you paid per houer? ");
                char flag = Convert.ToChar(Console.ReadLine());
                if (flag == 'y')
                {
                    temp.HourlyRate = true;
                    Console.WriteLine("how much you get per hour?");
                    temp.PricePerHour = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    temp.HourlyRate = false;
                    Console.WriteLine("how much you get per month?");
                    temp.PricePerMonth = Convert.ToInt32(Console.ReadLine());
                }
                temp.StateDaysOff = false;
                bl.deleteNanny(bl.getNanny(id));
                bl.addNanny(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



        private static void updateMother()
        {
            //   bl.update_Mother();
        }
        static void add_nanny()
        {
            try
            {
                Console.WriteLine("enter the ID of nanny");
                int id = Convert.ToInt32(Console.ReadLine());
                Nanny temp = new Nanny();
                Console.WriteLine("enter first name");
                temp.FirstName = Console.ReadLine();
                Console.WriteLine("enter last name");
                temp.LastName = Console.ReadLine();
                Console.WriteLine("enter the phone number");
                temp.Phone = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the address");
                temp.Adress = Console.ReadLine();
                Console.WriteLine("what is you are scheculde ?");
                workDays();
                temp.WorkDays = work;
                temp.WorkHours = add;
                Console.WriteLine("enter the oldes child in your responsiblty");
                temp.MaxAgeOfChild = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the youngest child in your responsiblty");
                temp.MinAgeOfChild = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("are you paid per houer? ");
                char flag = Convert.ToChar(Console.ReadLine());
                if (flag == 'y')
                {
                    temp.HourlyRate = true;
                    Console.WriteLine("how much you get per hour?");
                    temp.PricePerHour = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    temp.HourlyRate = false;
                    Console.WriteLine("how much you get per month?");
                    temp.PricePerMonth = Convert.ToInt32(Console.ReadLine());
                }
                temp.StateDaysOff = false;
                bl.addNanny(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        static void child()
        {

        }

        static void Main(string[] args)
        {

            start:
            Console.WriteLine("test program\n" + "Main Menu\n" +
                              "0: exit\n" +
                              "1: mother operations\n" +
                              "2: nanny operations\n" +
                              "3: child operations\n" +
                              "4: contract operations\n");
            int select = Convert.ToInt32(Console.ReadLine());
            try
            {
                while (select != 0)
                {
                    switch (select)
                    {
                        case 1:
                            mother();
                            break;
                        case 2:
                            nanny();
                            break;
                    }

                    Console.WriteLine("retorned to the main menu");
                    select = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto start;

            }
        }

    }
}