using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


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

        static List<Wages> DisplayReadDataFromSQL()
        {
            List<Wages> dailyWages = new List<Wages>();
            DataSet dailyIncome_ds = new DataSet();
            DataTable dailyIncome_dt = new DataTable();

            // load in DataSet and DataTable
            dailyIncome_ds = GetDataSet();

            // add all matching ski runs to an array of DataRow
            DataRow[] dailyIncomeRows = dailyIncome_ds.Tables["dailyIncome"].Select();



            // add all DataRow info to the list of ski runs

            foreach (DataRow Income in dailyIncomeRows)

            {

                dailyWages.Add(new Wages

                {

                    DateOfIncome = DateTime.Parse(Income["DateOfIncome"].ToString()),
                    HourlyWage = double.Parse(Income["HourlyWage"].ToString()),
                    HoursWorked = double.Parse(Income["HoursWorked"].ToString()),
                    HourlyIncome = double.Parse(Income["HourlyIncome"].ToString()),
                    TipAmount = double.Parse(Income["TipAmount"].ToString())

                });
            }
            DisplayContinuePrompt();
            return dailyWages;
            
            
        }

        static DataSet GetDataSet()
        {
            DataSet dailyIncome_ds = new DataSet();
             DisplayHeader("Read Income From File");
            
            
            SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-ULLV9GE\SQLEXPRESS;Initial Catalog=TipTrackers;Integrated Security=True");
            string sqlCommandString = $"SELECT * FROM DailyIncome";

            SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConn);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);

            sqlAdapter.Fill(dailyIncome_ds, "DailyIncome");

            //var tables = dailyIncome_ds.Tables
            //var table = tables[0];

            //using (sqlConn)
            //{
            //    using (sqlCommand)
            //    {
            //        using (SqlDataReader reader = sqlCommand.ExecuteReader())
            //        {
            //            try
            //            {
            //                sqlConn.Open();
            //                sqlAdapter.Fill(dailyIncome_ds, "DailyIncome");
            //            }
            //            catch (SqlException sqlEx)
            //            {
            //                Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
            //            }
            //        }
            //    }
            //}
            sqlConn.Close();
            return dailyIncome_ds;
        }

        static void DisplaySendDataToSQL(List<Wages> dailyWages)
        {
            DisplayHeader("Add Income To File");

            Console.WriteLine("Press any Key to Add Income");
            //@"Data Source = (DESKTOP-ULLV9GE)\(SQLEXPRESS);Initial Catalog=(TipTrackers);Intergrated Security=true;
            SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-ULLV9GE\SQLEXPRESS;Initial Catalog=TipTrackers;Integrated Security=True");
            sqlConn.Open();
            foreach (Wages wage in dailyWages)
            {
                // build out SQL command

                var sb = new StringBuilder("INSERT INTO DailyIncome");

                sb.Append(" ([DateOfIncome],[HourlyWage],[HoursWorked],[HourlyIncome],[TipAmount])");
                sb.Append(" Values (");
                sb.Append("'").Append(wage.DateOfIncome).Append("',");
                sb.Append("'").Append(wage.HourlyWage).Append("',");
                sb.Append("'").Append(wage.HoursWorked).Append("',");
                sb.Append("'").Append(wage.HourlyIncome).Append("',");
                sb.Append("'").Append(wage.TipAmount).Append("')");

                string sqlCommandString = sb.ToString();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                using (sqlConn)
                {
                    try
                    {
                        sqlConn.Open();
                        sqlAdapter.InsertCommand = new SqlCommand(sqlCommandString, sqlConn);
                        sqlAdapter.InsertCommand.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                        Console.WriteLine(sqlCommandString);
                    }                    
                }                
            }
            sqlConn.Close();
            DisplayContinuePrompt();
        }

        static void DisplayDailyIncomeInfo(List<Wages> dailyWages)
        {
            DateTime dateToView;
            bool validResponse = false;
            DisplayHeader("View Total Daily Income");

            List<Wages> selectedWages = dailyWages.Where(w => w.DateOfIncome <= DateTime.Parse("2018-01-04")).ToList();

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
            double totalIncome = 0;
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
                    totalIncome = wage.HourlyIncome + wage.TipAmount;
                    Console.WriteLine("------------".PadLeft(35));
                    Console.WriteLine("Total Wages:".PadRight(25) + totalIncome.ToString("C2").PadLeft(10));
                   
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
            double totalIncome = 0;
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
                    totalIncome = wage.TipAmount + wage.HourlyIncome;
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

                    wage.HourlyIncome = wagePerHour * hoursWorked;

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

            newWage.HourlyIncome = wagePerHour * hoursWorked;

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

                Console.WriteLine("\t1) Add Daily Tips & Wage");
                Console.WriteLine("\t2) Update Daily Tips & Wage");
                Console.WriteLine("\t3) Display Income");
                Console.WriteLine("\t4) Save Earned Incomes to File");
                Console.WriteLine("\t5) Retrieve Earned Incomes from a File");
                Console.WriteLine("\tE) Exit");

                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        DisplayGetTotalDailyIncome(dailyWages);
                        break;
                    case "2":
                        DisplayUpdateTotalDailyIncome(dailyWages);
                        break;
                    case "3":
                        DisplayDailyIncomeInfo(dailyWages);
                        break;
                    case "4":
                        DisplaySendDataToSQL(dailyWages);
                        break;

                    case "5":
                        dailyWages = DisplayReadDataFromSQL();
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
