using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Data.Sql;
//osman gümüş kodladı
namespace YazılımYapımı
{
    public partial class Form2 : Form
    {
        //Baglantı oluşturma
        static String connectString = "Data Source=DESKTOP-K55SVSC\\SQLEXPRESS;Initial Catalog=VeriTabanı;Integrated Security=True";
       //Sql server kullanarak veritabanı oluşturma
        public Form2()
        {
            InitializeComponent();
           
        }
        
       

        private void Form2_Load(object sender, EventArgs e)
        {
            //texte yazanın sıralaması
            textBox1.Text = UserControlDays.static_day + "/" +Form3.static_month + "/" + Form3.static_year;
            
        }
        
       

        private void button1_Click(object sender, EventArgs e)
        {
            //veri tabanı bağlantısı
            try
            {
                SqlConnection conn = new SqlConnection(connectString);
                if (conn.State == ConnectionState.Closed)
                    //veri tabanı açma
                    conn.Open();
                String sql = "insert into Table_2(Tarih,Açıklama)" + "values(@Tarih,@Açıklama)";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Tarih", textBox1.Text);
                cmd.Parameters.AddWithValue("@Açıklama", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kaydedildi");
                cmd.Dispose();
                //veri tabanı kapatma
                conn.Close();
                
            }
            //try cath kullanarak hatalı veya başarılı mesajını alma
            catch (Exception hata)
            {
                MessageBox.Show("Hata Meydana Geldi" + hata.Message);
            }
        }
    }
}
