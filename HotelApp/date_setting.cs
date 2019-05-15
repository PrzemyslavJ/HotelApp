using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApp
{
    public partial class date_setting : Form
    {
        public date_setting()
        {
            InitializeComponent();
        }
        int p = 0;
        public string dateset1,dateset2;
        
        private void date_setting_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.MinDate = monthCalendar1.TodayDate;
            textBox1.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
            textBox2.Text = monthCalendar1.SelectionRange.End.ToShortDateString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p == 1)
            {
                dateset1 = monthCalendar1.SelectionRange.Start.ToShortDateString();
                dateset2 = monthCalendar1.SelectionRange.End.ToShortDateString();
                Close();
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            p = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            p = 1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
