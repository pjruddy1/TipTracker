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

        /// <summary>
                /// Delete Specific Dates In SQL Database and List
                /// </summary>
        static void DisplayDeleteWageFromListAndDB(List<Wages> dailyWages)
        {
            bool validResponse;
            DateTime date1;
            DateTime date2;
            DisplayHeader("Delete Income From List and Database");

            Console.Write("Enter the Oldest Date you would like Deleted: ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out date1);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please enter a valid Date & Time: ");
                validResponse = DateTime.TryParse(Console.ReadLine(), out date1);
            }
            Console.WriteLine();
            Console.Write("Enter the Most Recent Date you would like Deleted: ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out date2);
            if (!validResponse)
            {
                date2 = date1;
            }
            Console.WriteLine("Press any Key to Delete Date of Income From Database");
            //@"Data Source = (DESKTOP-ULLV9GE)\(SQLEXPRESS);Initial Catalog=(TipTrackers);Intergrated Security=true;
            SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-ULLV9GE\SQLEXPRESS;Initial Catalog=TipTrackers;Integrated Security=True");
            sqlConn.Open();
            foreach (Wages wage in dailyWages)
            {
                // build out SQL command

                var sb = new StringBuilder($"DELETE FROM DailyIncome WHERE");
                sb.Append($"[DateOfIncome] BETWEEN '{date1}' AND '{date2}'");

                string sqlCommandString = sb.ToString();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConn);

                //using (sqlConn)
                //{
                //    try
                //    {
                //        sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConn);
                //        sqlAdapter.DeleteCommand.ExecuteNonQuery();
                //    }
                //    catch (SqlException sqlEx)
                //    {
                //        Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                //        Console.WriteLine(sqlCommandString);
                //    }
                //}
                Console.WriteLine();
                Console.WriteLine("Press any Key to Delete Date of Income From the List");
                if(wage.DateOfIncome >= date1 && wage.DateOfIncome <= date2)
                {
                    dailyWages.Remove(wage);
                }
               
            }
            sqlConn.Close();
            DisplayContinuePrompt();
        }

        /// <summary>
                /// Update Specific Dates In SQL Database
                /// </summary>
        static void DisplayUpdateDataToSQL(List<Wages> dailyWages)
        {
            bool validResponse;
            DateTime  date1;
            DateTime  date2;
            DisplayHeader("Update Income To File");

            Console.Write("Enter the Oldest Date you would like Updated: ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out date1);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please enter a valid Date & Time: ");
                validResponse = DateTime.TryParse(Console.ReadLine(), out date1);
            }
            Console.WriteLine();
            Console.Write("Enter the Most Recent Date you would like Updated: ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out date2);
            if (!validResponse)
            {
                date2 = date1;
            }
            Console.WriteLine("Press any Key to Update Date of Income in Database");
            //@"Data Source = (DESKTOP-ULLV9GE)\(SQLEXPRESS);Initial Catalog=(TipTrackers);Intergrated Security=true;
            SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-ULLV9GE\SQLEXPRESS;Initial Catalog=TipTrackers;Integrated Security=True");
            sqlConn.Open();
            foreach (Wages wage in dailyWages)
            {
                // build out SQL command

                var sb = new StringBuilder($"UPDATE DailyIncome SET");
                sb.Append("[HourlyWage] = '").Append(wage.HourlyWage).Append("', ");
                sb.Append("[HoursWorked] = '").Append(wage.HoursWorked).Append("', ");
                sb.Append("[HourlyIncome] = '").Append(wage.HourlyIncome).Append("', ");
                sb.Append("[TipAmount] = '").Append(wage.TipAmount).Append("' ");
                sb.Append("WHERE ");
                sb.Append($"[DateOfIncome] BETWEEN '{date1}' AND '{date2}'");

                string sqlCommandString = sb.ToString();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                using (sqlConn)
                {
                    try
                    {                        
                        sqlAdapter.UpdateCommand = new SqlCommand(sqlCommandString, sqlConn);
                        sqlAdapter.UpdateCommand.ExecuteNonQuery();
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

        /// <summary>
                /// Pull Dataset and turn into List
                /// </summary>
        static List<Wages> DisplayReadDataFromSQL()
        {
            List<Wages> dailyWages = new List<Wages>();
            DataSet dailyIncome_ds = new DataSet();
            DataTable dailyIncome_dt = new DataTable();

            // load in DataSet and DataTable
            dailyIncome_ds = GetDataSet();

            // add all matching ski runs to an array of dailyIncome
            DataRow[] dailyIncomeRows = dailyIncome_ds.Tables["dailyIncome"].Select();

            // add all DataRow info to the list of dailyIncome
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

        /// <summary>
                /// Turn Database into a Data set
                /// and passes back to List dailyWages
                /// </summary>
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

        /// <summary>
                /// Send Complete List To Database
                /// </summary>
        static void DisplaySendDataToSQL(List<Wages> dailyWages)
        {
            DisplayHeader("Add New Income To Database");

            Console.WriteLine("Press any Key to Add New Income");
            Console.ReadKey();
            //@"Data Source=DESKTOP-ULLV9GE\SQLEXPRESS;Initial Catalog=TipTrackers;Integrated Security=True"
            // Open Connection to DB
            SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-ULLV9GE\SQLEXPRESS;Initial Catalog=TipTrackers;Integrated Security=True");
            sqlConn.Open();
            foreach (Wages wage in dailyWages)
            {
                // build out SQL command
                // to Fill Database
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

                //
                // works with a single Row but kicks unhandled exception when more then 1
                //
                using (sqlConn)
                {
                    try
                    {
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

        /// <summary>
                /// display single dailyWage Info
                /// </summary>
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
            double totalIncome = 0;
            bool dateFound = false;
            DisplayHeader($"Tips & Daily Wages Earned for {dateToView}");
            Console.WriteLine("Type of Income".PadRight(25) + "Amount".PadLeft(10));
            Console.WriteLine("-------------------------".PadRight(25) + "----------".PadLeft(10));
            //
            // Display Income Incfo
            //
            foreach (Wages wage in dailyWages)
            {
                if (wage.DateOfIncome == dateToView)
                {
                    Console.WriteLine("| Hours Worked:".PadRight(25) + wage.HoursWorked.ToString().PadLeft(10) +"|");
                    Console.WriteLine("| Hourly Wage:".PadRight(25) + wage.HourlyWage.ToString("C2").PadLeft(10) + "|");
                    Console.WriteLine("------------".PadLeft(35) + "|");
                    Console.WriteLine("| Hourly Wage Earned".PadRight(25) + wage.HourlyIncome.ToString("C2").PadLeft(10) + "|");
                    Console.WriteLine("| Tips Earned:".PadRight(25) + wage.TipAmount.ToString("C2").PadLeft(10) + "|");
                    totalIncome = wage.HourlyIncome + wage.TipAmount;
                    Console.WriteLine("------------".PadLeft(35) + "|");
                    Console.WriteLine("| Total Wages:".PadRight(25) + totalIncome.ToString("C2").PadLeft(10) + "|");
                    Console.WriteLine("-------------------------".PadRight(25) + "----------".PadLeft(10));
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

        /// <summary>
                /// Updating a dailyIncome
                /// </summary>
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
            Console.WriteLine("-------------------------".PadRight(25) + "----------".PadLeft(10));
            foreach (Wages wage in dailyWages)
            {
                if (wage.DateOfIncome == dateToChange)
                {
                    //
                    // Display Income Info To BE Changed
                    //
                    Console.WriteLine("| Hours Worked:".PadRight(25) + wage.HoursWorked.ToString().PadLeft(10) + "|");
                    Console.WriteLine("| Hourly Wage:".PadRight(25) + wage.HourlyWage.ToString("C2").PadLeft(10) + "|");
                    Console.WriteLine("------------".PadLeft(35) + "|");
                    Console.WriteLine("| Hourly Wage Earned".PadRight(25) + wage.HourlyIncome.ToString("C2").PadLeft(10) + "|");
                    Console.WriteLine("| Tips Earned:".PadRight(25) + wage.TipAmount.ToString("C2").PadLeft(10) + "|");
                    totalIncome = wage.HourlyIncome + wage.TipAmount;
                    Console.WriteLine("------------".PadLeft(35) + "|");
                    Console.WriteLine("| Total Wages:".PadRight(25) + totalIncome.ToString("C2").PadLeft(10) + "|");
                    Console.WriteLine("-------------------------".PadRight(25) + "----------".PadLeft(10));
                    Console.WriteLine();
                    Console.WriteLine("Press any Key to Change Values");

                    //
                    // Update Income info
                    //Enter Correct Date
                    // WIth Validation
                    Console.WriteLine("Enter the Correct Date the Wages were Earned (YYYY-MM-DD): ");
                    validResponse = DateTime.TryParse(Console.ReadLine(), out DateTime date);
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please enter a valid Date: ");
                        validResponse = DateTime.TryParse(Console.ReadLine(), out date);
                    }
                    wage.DateOfIncome = date;
                    //
                    // Update Tips Earned
                    // With Validation
                    Console.Write("Enter the Correct Tips Earned: ");
                    validResponse = double.TryParse(Console.ReadLine(), out double tips);
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please Enter a correct amount!");
                        validResponse = double.TryParse(Console.ReadLine(), out tips);
                    }
                    wage.TipAmount = tips;
                    //
                    // Enter Correct Hours Worked
                    // With Validation
                    Console.Write("Enter your Correct Hours Worked: ");
                    validResponse = double.TryParse(Console.ReadLine(), out double hoursWorked);
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please Enter a correct amount!");
                        validResponse = double.TryParse(Console.ReadLine(), out hoursWorked);
                    }
                    wage.HoursWorked = hoursWorked;
                    //
                    // Enter Correct Hourly Wage
                    // WIth Validation
                    Console.Write("Enter your Correct Hourly Wage: ");
                    validResponse = double.TryParse(Console.ReadLine(), out double wagePerHour);
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.Write("Please Enter a correct amount!");
                        validResponse = double.TryParse(Console.ReadLine(), out wagePerHour);
                    }
                    wage.HourlyWage = wagePerHour;
                    //
                    // Total Hourly Income
                    //
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

        /// <summary>
                /// Building a List dailyWages
                /// </summary>
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
            //Date of income
            // With Validation
            Console.WriteLine("Enter the Date the Wages were Earned (YYYY-MM-DD): ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out DateTime date);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please enter a valid Date: ");
                validResponse = DateTime.TryParse(Console.ReadLine(), out date);
            }
            newWage.DateOfIncome = date;            
            //
            // Tips Earned
            // With Validation
            Console.Write("Enter your Tips Earned: ");
            validResponse = double.TryParse(Console.ReadLine(), out double tips);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount: ");
                validResponse = double.TryParse(Console.ReadLine(), out tips);
            }
            newWage.TipAmount = tips;
            //
            // Eneter Hours Worked
            // With Validation
            Console.Write("Enter your Hours Worked: ");
            validResponse = double.TryParse(Console.ReadLine(), out double hoursWorked);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount: ");
                validResponse = double.TryParse(Console.ReadLine(), out hoursWorked);
            }
            newWage.HoursWorked = hoursWorked;
            //
            // Enter Hourly Wage
            // With Validation
            Console.Write("Enter your Hourly Wage: ");
            validResponse = double.TryParse(Console.ReadLine(), out double wagePerHour);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount: ");
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

        /// <summary>
                /// Main Menu
                /// </summary>
        static void DisplayMenu()
        {
            List<Wages> dailyWages = new List<Wages>();
            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");
                Console.Write("-------------------------".PadRight(25)); Console.WriteLine("---------------".PadLeft(15));
                Console.WriteLine("| 1) Add Daily Tips & Wage to List            |");
                Console.WriteLine("| 2) Update Daily Tips & Wage in List         |"); 
                Console.WriteLine("| 3) Display A Daily Income From List         |"); 
                Console.WriteLine("| 4) Save Earned Incomes to File              |"); 
                Console.WriteLine("| 5) Retrieve Earned Incomes from a File      |"); 
                Console.WriteLine("| 6) Update Earned Incomes to File            |"); 
                Console.WriteLine("| 7) Delete Earned Incomes From File and List |"); 
                Console.WriteLine("| E) Exit                                     |");
                Console.Write("-------------------------".PadRight(25)); Console.WriteLine("---------------".PadLeft(15));

                Console.Write("Enter Choice: ");
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
                    case "6":
                        DisplayUpdateDataToSQL(dailyWages);
                        break;
                    case "7":
                        DisplayDeleteWageFromListAndDB(dailyWages);
                        break;
                    case "E":
                    case "e":
                        exiting = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice please choose again.");
                        Console.WriteLine("-----------------------------------");
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
            Console.WriteLine("\t-----------------------------------");
            Console.WriteLine();
        }
    }


}
