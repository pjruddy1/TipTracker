using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }

        static void DisplayDailyIncomeInfo(List<Wages> dailyWages)
        {
            DateTime dateToView;
            bool validResponse = false;
            DisplayHeader("View Total Daily Income");

            //
            //Display a List Of Income Dates
            //
            foreach (Wages wage in dailyWages)
            {
                Console.WriteLine(wage.DateOfIncome);
            }
            //
            // Get Name From User
            //
            Console.WriteLine();
            Console.Write("Enter the Date of Income you would like to View(YYYY-MM-DD): ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out dateToView);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please enter a valid Date & Time: ");
                validResponse = DateTime.TryParse(Console.ReadLine(), out dateToView);
            }

            //
            // get Date from list
            //
            Console.Clear();
            bool dateFound = false;
            DisplayHeader($"Tips & Daily Wages Earned for {dateToView}");
            Console.WriteLine("Type of Income".PadRight(25) + "Amount".PadLeft(10));
            Console.WriteLine("-----------------".PadRight(25) + "--------".PadLeft(10));
            foreach (Wages wage in dailyWages)
            {
                if (wage.DateOfIncome == dateToView)
                {
                    Console.WriteLine("Hours Worked:".PadRight(25) + wage.HoursWorked.ToString().PadLeft(10));
                    Console.WriteLine("Hourly Wage:".PadRight(25) + wage.HourlyWage.ToString("C2").PadLeft(10));
                    Console.WriteLine("------------".PadLeft(35));
                    Console.WriteLine("Hourly Wage Earned".PadRight(25) + wage.HourlyIncome.ToString("C2").PadLeft(10));
                    Console.WriteLine("Tips Earned:".PadRight(25) + wage.TipAmount.ToString("C2").PadLeft(10));
                    double totalIncome = wage.TipAmount + wage.HourlyIncome;
                    Console.WriteLine("------------".PadLeft(35));
                    Console.WriteLine("Total Wages:".PadRight(25) + totalIncome.ToString("C2").PadLeft(10));
                    Console.WriteLine();
                    Console.WriteLine("Press any Key to Change Values");
                    dateFound = true;
                    break;
                }
            }

            //
            // Date not found
            //
            if (!dateFound)
            {
                Console.WriteLine("\t\tUnable to find Date");
            }

            DisplayContinuePrompt();
        }

                static void DisplayUpdateTotalDailyIncome(List<Wages> dailyWages)
        {
            DateTime dateToChange;
            bool validResponse = false;
            DisplayHeader("Update Total Daily Income");

            //
            //Display a List Of Income Dates
            //
            foreach (Wages wage in dailyWages)
            {
                Console.WriteLine(wage.DateOfIncome);
            }
            //
            // Get Name From User
            //
            Console.WriteLine();
            Console.Write("Enter the Date of Income you would like to Change(YYYY-MM-DD): ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out dateToChange);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please enter a valid Date & Time: ");
                validResponse = DateTime.TryParse(Console.ReadLine(), out dateToChange);
            }

            //
            // get Date from list
            //
            Console.Clear();
            bool dateFound = false;
            DisplayHeader($"Tips & Daily Wages Earned for {dateToChange}");
            Console.WriteLine("Type of Income".PadRight(25) + "Amount".PadLeft(10));
            Console.WriteLine("-----------------".PadRight(25) + "--------".PadLeft(10));
            foreach (Wages wage in dailyWages)
            {
                if (wage.DateOfIncome == dateToChange)
                {                    
                    Console.WriteLine("Hours Worked:".PadRight(25) + wage.HoursWorked.ToString().PadLeft(10));
                    Console.WriteLine("Hourly Wage:".PadRight(25) + wage.HourlyWage.ToString("C2").PadLeft(10));
                    Console.WriteLine("------------".PadLeft(35));
                    Console.WriteLine("Hourly Wage Earned".PadRight(25) + wage.HourlyIncome.ToString("C2").PadLeft(10));
                    Console.WriteLine("Tips Earned:".PadRight(25) + wage.TipAmount.ToString("C2").PadLeft(10));
                    double totalIncome = wage.TipAmount + wage.HourlyIncome;
                    Console.WriteLine("------------".PadLeft(35));
                    Console.WriteLine("Total Wages:".PadRight(25) + totalIncome.ToString("C2").PadLeft(10));
                    Console.WriteLine();
                    Console.WriteLine("Press any Key to Change Values");

                    //
                    // Update Income info
                    //
                    Console.WriteLine("Enter the Correct Date the Wages were Earned (YYYY-MM-DD): ");
                    validResponse = DateTime.TryParse(Console.ReadLine(), out DateTime date);
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please enter a valid Date: ");
                        validResponse = DateTime.TryParse(Console.ReadLine(), out date);
                    }
                    wage.DateOfIncome = date;


                    Console.Write("Enter the Correct Tips Earned: ");
                    validResponse = double.TryParse(Console.ReadLine(), out double tips);
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please Enter a correct amount!");
                        validResponse = double.TryParse(Console.ReadLine(), out tips);
                    }
                    wage.TipAmount = tips;

                    Console.Write("Enter your Correct Hours Worked: ");
                    validResponse = double.TryParse(Console.ReadLine(), out double hoursWorked);
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please Enter a correct amount!");
                        validResponse = double.TryParse(Console.ReadLine(), out hoursWorked);
                    }
                    wage.HoursWorked = hoursWorked;

                    Console.Write("Enter your Correct Hourly Wage: ");
                    validResponse = double.TryParse(Console.ReadLine(), out double wagePerHour);
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please Enter a correct amount!");
                        validResponse = double.TryParse(Console.ReadLine(), out wagePerHour);
                    }
                    wage.HourlyWage = wagePerHour;

                    wage.DisplayHourlyIncome();

                    dateFound = true;
                    break;
                }
            }

            //
            // Date not found
            //
            if (!dateFound)
            {
                Console.WriteLine("\t\tUnable to find Date");
            }

            DisplayContinuePrompt();
        }

        static void DisplayGetTotalDailyIncome(List<Wages> dailyWages)
        {
            //
            // instantiate a Daily Income
            //
            bool validResponse = false;
            Wages newWage = new Wages();
            DisplayHeader("Enter Total Daily Wages");

            //
            //Assign Wage Properties

            Console.WriteLine("Enter the Date the Wages were Earned (YYYY-MM-DD): ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out DateTime date);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please enter a valid Date: ");
                validResponse = DateTime.TryParse(Console.ReadLine(), out date);
            }
            newWage.DateOfIncome = date;
            

            Console.Write("Enter your Tips Earned: ");
            validResponse = double.TryParse(Console.ReadLine(), out double tips);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount!");
                validResponse = double.TryParse(Console.ReadLine(), out tips);
            }
            newWage.TipAmount = tips;

            Console.Write("Enter your Hours Worked: ");
            validResponse = double.TryParse(Console.ReadLine(), out double hoursWorked);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount!");
                validResponse = double.TryParse(Console.ReadLine(), out hoursWorked);
            }
            newWage.HoursWorked = hoursWorked;

            Console.Write("Enter your Hourly Wage: ");
            validResponse = double.TryParse(Console.ReadLine(), out double wagePerHour);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount!");
                validResponse = double.TryParse(Console.ReadLine(), out wagePerHour);
            }
            newWage.HourlyWage = wagePerHour;

            newWage.DisplayHourlyIncome();

            //
            //Add Wage to list
            //
            dailyWages.Add(newWage);

            DisplayContinuePrompt();
        }

        static void DisplayMenu()
        {
            List<Wages> dailyWages = new List<Wages>();
            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\tA) Add Daily Tips & Wage");
                Console.WriteLine("\tB) Update Daily Tips & Wage");
                Console.WriteLine("\tC) Display Income");
                Console.WriteLine("\tD) Save Earned Incomes to File");
                Console.WriteLine("\t4) Retrieve Earned Incomes from a File");
                Console.WriteLine("\tE) Exit");

                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "A":
                    case "a":
                        break;
                        DisplayGetTotalDailyIncome(dailyWages);
                    case "B":
                        break;
                        DisplayUpdateTotalDailyIncome(dailyWages);
                    case "C":
                        break;
                        DisplayDailyIncomeInfo(dailyWages);
                    case "D":
                        break;

                    case "5":
                        break;

                    case "E":
                    case "e":
                        exiting = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice please choose again.");
                        break;
                }
            }
        }

        /// <summary>
                /// display opening screen
                /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tTip Tracker Plus");
            Console.WriteLine("\t\tRecord your tips and wages daily");
            Console.WriteLine();
            Console.WriteLine("\t\tPeej llc.");

            DisplayContinuePrompt();
        }

        /// <summary>
                /// display closing screen
                /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Tip Tracker Plus.");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display header
        /// </summary>
        static void DisplayHeader(string headerTitle)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerTitle);
            Console.WriteLine();
        }
    }


}
