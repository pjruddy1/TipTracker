using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipTracker
{
    class Wages
    {
        

        #region Fields
        private DateTime _dateOfIncome;
        private double _tipAmount;
        private double _hoursWorked;
        private double _hourlyWage;
        private double _hourlyIncome;
        private double _dailyTotalIncome;
        #endregion

        #region Properties

        public double HourlyWage
        {
            get { return _hourlyWage; }
            set { _hourlyWage = value; }
        }

        public double HoursWorked
        {
            get { return _hoursWorked; }
            set { _hoursWorked = value; }
        }

        public double TipAmount
        {
            get { return _tipAmount; }
            set { _tipAmount = value; }
        }

        public DateTime DateOfIncome
        {
            get { return _dateOfIncome; }
            set { _dateOfIncome = value; }
        }

        public double HourlyIncome
        {
            get { return _hourlyIncome; }
            set { _hourlyIncome = value; }
        }

        public double DailyTotalIncome
        {
            get { return _dailyTotalIncome; }
            set { _dailyTotalIncome = value; }
        }

        #endregion

        #region Methods
        public double DisplayHourlyIncome()
        {
            double HourlyIncome = 0;
            HourlyIncome = _hoursWorked * _hourlyWage;
            return HourlyIncome;
        }

    

        #endregion

        #region Constructors
        
       
        public Wages()
        {

        }


        #endregion
    }
}
