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
        public enum TypeOfWage
        {
            NONE,
            TIP,
            HOURLY,
            HOURS,
            TOTAL
        }

        public enum Condition
        {
            NONE,
            EQUAL,
            GREATER,
            LESS
        }

        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }

        static void DisplaySearchByHours(List<Wages> dailyWages)
        {
            bool validResponse = false;
            bool enumResponse = false;
            Condition conditionSearch = new Condition();
            double hours;

            Console.Write("Enter the amount of Hours to search: ");
            validResponse = double.TryParse(Console.ReadLine(), out hours);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount: ");
                validResponse = double.TryParse(Console.ReadLine(), out hours);
            }

            while (!enumResponse)
            {
                Console.Write("Would you like to Search(GREATER, LESS OR EQUAL) to the Amount:  ");
                Enum.TryParse<Condition>(Console.ReadLine().ToUpper(), out conditionSearch);
                switch (conditionSearch)
                {

                    case Condition.GREATER:
                    case Condition.LESS:
                    case Condition.EQUAL:
                        validResponse = true;
                        break;
                    case Condition.NONE:
                        validResponse = false;
                        break;
                }
            }

            switch (conditionSearch)
            {
                case Condition.NONE:
                    break;
                case Condition.EQUAL:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.HoursWorked == hours)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                case Condition.GREATER:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.HoursWorked >= hours)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                case Condition.LESS:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.HoursWorked <= hours)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                default:
                    break;
            }
            DisplayContinuePrompt();

        }

        static void DisplaySearchByTotalIncome(List<Wages> dailyWages)
        {
            bool validResponse = false;
            bool enumResponse = false;
            Condition conditionSearch = new Condition();
            double totalIncome;

            Console.Write("Enter the amount of Total Daily Income to search: ");
            validResponse = double.TryParse(Console.ReadLine(), out totalIncome);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount: ");
                validResponse = double.TryParse(Console.ReadLine(), out totalIncome);
            }

            while (!enumResponse)
            {
                Console.Write("Would you like to Search(GREATER, LESS OR EQUAL) to the Amount:  ");
                Enum.TryParse<Condition>(Console.ReadLine().ToUpper(), out conditionSearch);
                switch (conditionSearch)
                {

                    case Condition.GREATER:
                    case Condition.LESS:
                    case Condition.EQUAL:
                        enumResponse = true;
                        break;
                    case Condition.NONE:
                        enumResponse = false;
                        break;
                }
            }

            switch (conditionSearch)
            {
                case Condition.NONE:
                    break;
                case Condition.EQUAL:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.DailyTotalIncome == totalIncome)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                case Condition.GREATER:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.DailyTotalIncome >= totalIncome)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                case Condition.LESS:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.DailyTotalIncome <= totalIncome)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                default:
                    break;
            }
            DisplayContinuePrompt();

        }

        static void DisplaySearchByHourly(List<Wages> dailyWages)
        {
            bool validResponse = false;
            bool enumResponse = false;
            Condition conditionSearch = new Condition();
            double hours;

            Console.Write("Enter the amount of Hours to search: ");
            validResponse = double.TryParse(Console.ReadLine(), out hours);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount: ");
                validResponse = double.TryParse(Console.ReadLine(), out hours);
            }

            while (!enumResponse)
            {
                Console.Write("Would you like to Search(GREATER, LESS OR EQUAL) to the Amount:  ");
                Enum.TryParse<Condition>(Console.ReadLine().ToUpper(), out conditionSearch);
                switch (conditionSearch)
                {

                    case Condition.GREATER:
                    case Condition.LESS:
                    case Condition.EQUAL:
                        enumResponse = true;
                        break;
                    case Condition.NONE:
                        enumResponse = false;
                        break;
                }
            }

            switch (conditionSearch)
            {
                case Condition.NONE:
                    break;
                case Condition.EQUAL:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.HoursWorked == hours)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                case Condition.GREATER:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.HoursWorked >= hours)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                case Condition.LESS:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.HoursWorked <= hours)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                default:
                    break;
            }
            DisplayContinuePrompt();

        }

        static void DisplaySearchByTip(List<Wages> dailyWages)
        {
            bool validResponse = false;
            bool enumResponse = false;
            Condition conditionSearch = new Condition();
            double tipAmount;

            Console.Write("Enter the amount of Tips to search: ");
            validResponse = double.TryParse(Console.ReadLine(), out tipAmount);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please Enter a correct amount: ");
                validResponse = double.TryParse(Console.ReadLine(), out tipAmount);
            }

            while (!enumResponse)
            {
                Console.Write("Would you like to Search(GREATER, LESS OR EQUAL) to the Amount:  ");
                Enum.TryParse<Condition>(Console.ReadLine().ToUpper(), out conditionSearch);
                switch (conditionSearch)
                {

                    case Condition.GREATER:
                    case Condition.LESS:
                    case Condition.EQUAL:
                        enumResponse = true;
                        break;
                    case Condition.NONE:
                        enumResponse = false;
                        break;
                }
            }

            switch (conditionSearch)
            {
                case Condition.NONE:                   
                    break;
                case Condition.EQUAL:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.TipAmount == tipAmount)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                case Condition.GREATER:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.TipAmount >= tipAmount)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                case Condition.LESS:
                    Console.WriteLine("--------------------".PadRight(20));
                    foreach (Wages wage in dailyWages)
                    {
                        if (wage.TipAmount <= tipAmount)
                        {
                            Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
                        }
                    }
                    Console.WriteLine("--------------------".PadRight(20));
                    break;
                default:
                    break;
            }
            DisplayContinuePrompt();

        }

        static void DisplaySearchIncomesNotByDate(List<Wages> dailyWages)
        {
            
            bool validResponse = false;
            TypeOfWage TypeOfSearch = new TypeOfWage();
            DisplayHeader("Other Ways to Search For Income Dates");
            //
            // Ask user how they would like to search for date
            //
            while (!validResponse)
            {
                Console.Write("Enter how you would like to search for the date of income(Tip, Hourly, Hours, Total):  ");
                Enum.TryParse<TypeOfWage>(Console.ReadLine().ToUpper(), out TypeOfSearch);
                switch (TypeOfSearch)
                {

                    case TypeOfWage.TIP:
                    case TypeOfWage.HOURLY:
                    case TypeOfWage.HOURS:
                    case TypeOfWage.TOTAL:
                        validResponse = true;
                        break;
                    case TypeOfWage.NONE:
                        validResponse = false;
                        break;
                }
            }

            switch (TypeOfSearch)
            {
                case TypeOfWage.NONE:
                    break;
                case TypeOfWage.TIP:
                    DisplaySearchByTip(dailyWages);
                    break;
                case TypeOfWage.HOURLY:
                    DisplaySearchByHourly(dailyWages);
                    break;
                case TypeOfWage.HOURS:
                    DisplaySearchByHours(dailyWages);
                    break;
                case TypeOfWage.TOTAL:
                    DisplaySearchByTotalIncome(dailyWages);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
                /// Delete Specific Date in List
                /// </summary>
        static void DisplayDeleteDailyIncomeFromList(List<Wages> dailyWages)
        {
            bool validResponse;
            DateTime date1;

            DisplayHeader("Delete Income From List");
            //
            // Display a list of dates to choose from
            //
            Console.WriteLine("--------------------".PadRight(20));
            foreach (Wages wage in dailyWages)
            {
                Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
            }
            Console.WriteLine("--------------------".PadRight(20));
            //
            // Choose Dates to Delete
            //
            Console.Write("Enter the Date you would like Deleted: ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out date1);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please enter a valid Date & Time: ");
                validResponse = DateTime.TryParse(Console.ReadLine(), out date1);
            }
            Console.WriteLine();
            Console.WriteLine("Press any Key to Delete Date of Income From List");
            Console.ReadKey();

            foreach (Wages wage in dailyWages)
            {
                if (wage.DateOfIncome == date1)
                {
                    dailyWages.Remove(wage);
                    break;
                }
            }
            DisplayContinuePrompt();
        }

        /// <summary>
                /// Delete Specific Dates In SQL Database
                /// </summary>
        static void DisplayDeleteWageFromDatabase(List<Wages> dailyWages)
        {
            bool validResponse;
            DateTime date1;
            DateTime date2;
            DisplayHeader("Delete Income From Database");
            //
            // Display a list of dates to choose from
            //
            Console.WriteLine("--------------------".PadRight(20));
            foreach (Wages wage in dailyWages)
            {
                Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
            }
            Console.WriteLine("--------------------".PadRight(20));
            //
            // Choose Dates to Delete and validate
            //
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
            Console.ReadKey();
            //@"Data Source = (DESKTOP-ULLV9GE)\(SQLEXPRESS);Initial Catalog=(TipTrackers);Intergrated Security=true;
            
            foreach (Wages wage in dailyWages)
            {
                if (wage.DateOfIncome >= date1 || wage.DateOfIncome <= date2)
                {
                    // build out SQL command
                    // and create conneciton
                    //
                    var sb = new StringBuilder($"DELETE FROM DailyIncome WHERE");
                    sb.Append($"[DateOfIncome] BETWEEN '{date1}' AND '{date2}'");
                    SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-ULLV9GE\SQLEXPRESS;Initial Catalog=TipTrackers;Integrated Security=True");
                    sqlConn.Open();
                    string sqlCommandString = sb.ToString();
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConn);

                    using (sqlConn)
                    {
                        try
                        {
                            sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConn);
                            sqlAdapter.DeleteCommand.ExecuteNonQuery();
                        }
                        catch (SqlException sqlEx)
                        {
                            Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                            Console.WriteLine(sqlCommandString);
                        }
                    }
                     sqlConn.Close();
                }               
               
            }
            
        }

        /// <summary>
                /// Update Specific Dates In SQL Database
                /// </summary>
        static void DisplayUpdateDataToSQL(List<Wages> dailyWages)
        {
            bool validResponse;
            DateTime  date1;
            DisplayHeader("Update Income To File");
            //
            // Display The List Of Wages
            //
            Console.WriteLine("--------------------".PadRight(20));
            foreach (Wages wage in dailyWages)
            {
                Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
            }
            Console.WriteLine("--------------------".PadRight(20));
            Console.WriteLine();
            Console.Write("Enter the Date you would like Updated: ");
            validResponse = DateTime.TryParse(Console.ReadLine(), out date1);
            while (!validResponse)
            {
                Console.WriteLine();
                Console.Write("Please enter a valid Date & Time: ");
                validResponse = DateTime.TryParse(Console.ReadLine(), out date1);
            }
            Console.WriteLine();
            
            Console.WriteLine("Press any Key to Update Date of Income in Database");
            Console.ReadKey();
            //@"Data Source = (DESKTOP-ULLV9GE)\(SQLEXPRESS);Initial Catalog=(TipTrackers);Intergrated Security=true;            
           
            foreach (Wages wage in dailyWages)
            {
                // build out SQL command
                if (wage.DateOfIncome == date1)
                {
                    var sb = new StringBuilder($"UPDATE DailyIncome SET");
                    sb.Append("[HourlyWage] = '").Append(wage.HourlyWage).Append("', ");
                    sb.Append("[HoursWorked] = '").Append(wage.HoursWorked).Append("', ");
                    sb.Append("[HourlyIncome] = '").Append(wage.HourlyIncome).Append("', ");
                    sb.Append("[TipAmount] = '").Append(wage.TipAmount).Append("' ");
                    sb.Append("WHERE ");
                    sb.Append("[DateOfIncome] = '").Append(wage.DateOfIncome).Append("'");
                    SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-ULLV9GE\SQLEXPRESS;Initial Catalog=TipTrackers;Integrated Security=True");
                    sqlConn.Open();
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
                    sqlConn.Close();
                    break;
                }
            }           
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

            // add all rows to an array of dailyIncome
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
            DateTime date1;
            DateTime date2;
            bool validResponse;
            DisplayHeader("Add New Income To Database");
            //
            // Display a list of dates to choose from
            //
            Console.WriteLine("--------------------".PadRight(20));
            foreach (Wages wage in dailyWages)
            {
                Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
            }
            Console.WriteLine("--------------------".PadRight(20));
            //
            // Choose Dates to Delete
            //
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
            Console.WriteLine("Press any Key to Add New Income");
            Console.ReadKey();
            //@"Data Source=DESKTOP-ULLV9GE\SQLEXPRESS;Initial Catalog=TipTrackers;Integrated Security=True"
            // Open Connection to DB
            
            foreach (Wages wage in dailyWages)
            {
                if (wage.DateOfIncome >= date1 && wage.DateOfIncome <= date2)
                {
                    // build out SQL command
                    // to Fill Database
                    SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-ULLV9GE\SQLEXPRESS;Initial Catalog=TipTrackers;Integrated Security=True");
                    sqlConn.Open();
                    var sb = new StringBuilder("INSERT INTO DailyIncome");
                    sb.Append(" ([DateOfIncome],[HourlyWage],[HoursWorked],[HourlyIncome],[TipAmount],[TotalDailyIncome])");
                    sb.Append(" Values (");
                    sb.Append("'").Append(wage.DateOfIncome).Append("',");
                    sb.Append("'").Append(wage.HourlyWage).Append("',");
                    sb.Append("'").Append(wage.HoursWorked).Append("',");
                    sb.Append("'").Append(wage.HourlyIncome).Append("',");
                    sb.Append("'").Append(wage.TipAmount).Append("',");
                    sb.Append("'").Append(wage.TipAmount).Append("')");

                    string sqlCommandString = sb.ToString();
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    //
                    // Connecting and inserting data into table
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
                    sqlConn.Close();
                }
                
            }
            
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
            Console.WriteLine("--------------------".PadRight(20));
            foreach (Wages wage in dailyWages)
            {
                Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
            }
            Console.WriteLine("--------------------".PadRight(20));
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
            Console.WriteLine("--------------------".PadRight(20));
            foreach (Wages wage in dailyWages)
            {
                Console.Write("| "); Console.WriteLine((wage.DateOfIncome).ToShortDateString().PadRight(20) + "|");
            }
            Console.WriteLine("--------------------".PadRight(20));
            //
            // Get Date From User
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
                    Console.WriteLine("------------".PadLeft(35) + "|");
                    Console.WriteLine("| Total Wages:".PadRight(25) + wage.DailyTotalIncome.ToString("C2").PadLeft(10) + "|");
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
                    //
                    // Total Daily Income
                    //
                    wage.DailyTotalIncome = wage.HourlyIncome + wage.TipAmount;

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
            //
            // Calculate Hourly Income
            //
            newWage.HourlyIncome = wagePerHour * hoursWorked;
            //
            // Calculate Total Income
            //
            newWage.DailyTotalIncome = newWage.HourlyIncome + newWage.TipAmount;

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
                Console.WriteLine("| 1) Add Daily Income to Local List           |");
                Console.WriteLine("| 2) Update Daily Income in Local List        |"); 
                Console.WriteLine("| 3) Delete Daily Income From Local List      |");
                Console.WriteLine("| 4) Display A Daily Income From Local List   |");
                Console.WriteLine("| 5) Display A Daily Income From Local List   |");
                Console.WriteLine("| 6) Save Earned Incomes to Database          |"); 
                Console.WriteLine("| 7) Retrieve Earned Incomes from a Database  |"); 
                Console.WriteLine("| 8) Update Earned Incomes to Database        |"); 
                Console.WriteLine("| 9) Delete Earned Incomes From Database      |"); 
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
                        DisplayDeleteDailyIncomeFromList(dailyWages);
                        break;
                    case "4":
                        DisplayDailyIncomeInfo(dailyWages);
                        break;
                    case "5":
                        DisplaySearchIncomesNotByDate(dailyWages);                        
                        break;
                    case "6":
                        DisplaySendDataToSQL(dailyWages);
                        break;
                    case "7":
                        dailyWages = DisplayReadDataFromSQL();
                        break;
                    case "8":
                        DisplayUpdateDataToSQL(dailyWages);
                        break;
                    case "9":
                        DisplayDeleteWageFromDatabase(dailyWages);
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
