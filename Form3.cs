using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//furkan salduz kodladı
namespace YazılımYapımı
{
    public partial class Form3 : Form
    {
        //ay yıl tanımlama
        int month, year;
        public static int static_year, static_month;
        public Form3()
        {
            InitializeComponent();
        }
       

        private void Form3_Load(object sender, EventArgs e)
        {
            displaDays();
            

        }
        private void displaDays()
        {
            //şimdiki tarihi alma
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            string monthname = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            //tarihleri labela yazdırma
            lbDate.Text = monthname + " " + year;
            static_month = month;
            static_year = year;
            DateTime startofthemonth = new DateTime(year, month,1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"))+1;
            for(int i = 1; i < dayoftheweek; i++) {
                UserControlBlank ucBlank = new UserControlBlank();
                flowLayoutPanel1.Controls.Add(ucBlank);
            }
            //for döngüsüyle günleri kontrol etme
            for (int i = 1;i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                flowLayoutPanel1.Controls.Add(ucdays);
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //paneli temizleme
            flowLayoutPanel1.Controls.Clear();
            month--;
            //butonda bir önceki aya geçme
            static_month = month;
            static_year = year;

            string monthname = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dayoftheweek; i++)
                //for dongusuyle haftanın günlerini kontrol etme
            {
                UserControlBlank ucBlank = new UserControlBlank();
                flowLayoutPanel1.Controls.Add(ucBlank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                flowLayoutPanel1.Controls.Add(ucdays);
            }
            if (lbDate.Text.Equals("Kasım 2023"))
            {
                button1.Enabled = true;
            }
            if(lbDate.Text.Equals("Ocak 2023"))
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            flowLayoutPanel1.Controls.Clear();
            month++;
            //Bir sonraki aya geçme
            static_month = month;
            static_year = year;
            string monthname = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = monthname + " " + year;
           //labela ay ismini yazdırma
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                flowLayoutPanel1.Controls.Add(ucBlank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                flowLayoutPanel1.Controls.Add(ucdays);
            }
            if (lbDate.Text.Equals("Aralık 2023"))
            {
                button1.Enabled = false;
            }
            if (lbDate.Text.Equals("Şubat 2023"))
            {
                button2.Enabled = true;
            }
        }
    }
}
