using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//osman gümüş kodladı
namespace YazılımYapımı
{
    public partial class UserControlDays : UserControl
    {
        //Veri tabanı bağlantısı
         String connectString = "Data Source=DESKTOP-K55SVSC\\SQLEXPRESS;Initial Catalog=VeriTabanı;Integrated Security=True";
        public static string static_day;
        public UserControlDays()
        {
            InitializeComponent();
        }
        
        private void UserControlDays_Load(object sender, EventArgs e)
        {
           

        }
        public void days(int numday)
        {
            lbDays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbDays.Text;
            timer1.Start();
            Form2 eventForm = new Form2();
            eventForm.Show();
        }
        //Açıklamayı label üzerinde görüntülemek
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }
        //Yeni olay için zamanlayıcı
        private void displayEvent()
        {
            //verileri yazdırmak
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            String sql = "SELECT * FROM Table_2 where Tarih = @Tarih";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@Tarih", Form3.static_year + "/" + Form3.static_month + "/" + lbDays.Text);

            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                
                label3.Text = reader["@Açıklama"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();

        }

    }
}
