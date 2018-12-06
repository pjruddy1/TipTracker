using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TipTrackerController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Wages> dailyWages = new List<Wages>();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tb_dateOfIncome_TextChanged(object sender, EventArgs e, List<Wages> dailyWages)
        {
            DataBindings.Add("Text",
                               dateOfIncome                                
                                DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
