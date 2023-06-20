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
//hamza mutlu kodladı
namespace YazılımYapımı
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;


        public Form1()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-K55SVSC\\SQLEXPRESS;Initial Catalog=VeriTabanı;Integrated Security=True";
        SqlConnection connect = new SqlConnection(constring);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = "insert into Table_1  (Ad,Soyad,Kullanıcı_Adı,Şifre,TC_Kimlik_NU,Telefon_NU,E_Mail,Adres)" +
                    "values(@Ad,@Soyad,@Kullanıcı_Adı,@Şifre,@TC_Kimlik_NU,@Telefon_NU,@E_Mail,@Adres)";
                SqlCommand komut = new SqlCommand(kayit, connect);
                
                komut.Parameters.AddWithValue("@Ad", textBox1.Text );
                komut.Parameters.AddWithValue("@Soyad", textBox2.Text);
                komut.Parameters.AddWithValue("@Kullanıcı_Adı", textBox3.Text);
                komut.Parameters.AddWithValue("@Şifre", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@TC_Kimlik_NU", maskedTextBox2.Text);
                komut.Parameters.AddWithValue("@Telefon_NU", maskedTextBox3.Text);
                komut.Parameters.AddWithValue("@E_Mail", textBox4.Text);
                komut.Parameters.AddWithValue("@Adres", richTextBox1.Text);
                komut.ExecuteNonQuery();

                if ((textBox1.Text.Equals("")) || (textBox2.Text.Equals("")) || (textBox3.Text.Equals("")) || (maskedTextBox1.Text.Equals("")) ||
                (maskedTextBox2.Text.Equals("")) || (maskedTextBox3.Text.Equals("")) || (textBox4.Text.Equals("")) || (richTextBox1.Text.Equals("")) || (radioButton1.Text.Equals("")))
                {
                    MessageBox.Show("Hata meydana Geldi.");

                    
                }
                else
                {
                   
                    
                    MessageBox.Show("Kayıt Başarıyla Oluşturuldu.");
                    connect.Close();
                }
                
               
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Meydana Geldi" + hata.Message);
            }
            if (textBox1.Text.Equals(""))
            {
                label17.Visible = true;

            }
            else
            {
                label17.Visible = false;
            }
            if (textBox2.Text.Equals(""))
            {
                label18.Visible = true;

            }
            else
            {
                label18.Visible = false;
            }
            if (textBox3.Text.Equals(""))
            {
                label19.Visible = true;

            }
            else
            {
                label19.Visible = false;
            }
            if (textBox4.Text.Equals(""))
            {
                label21.Visible = true;

            }
            else
            {
                label21.Visible = false;
            }
            if (richTextBox1.Text.Equals(""))
            {
                label25.Visible = true;

            }
            else
            {
                label25.Visible = false;
            }
            if (maskedTextBox1.Text.Equals(""))
            {
                label20.Visible = true;

            }
            else
            {
                label20.Visible = false;
            }
            if (maskedTextBox2.Text.Equals(""))
            {
                label24.Visible = true;

            }
            else
            {
                label24.Visible = false;
            }
            if (maskedTextBox3.Text.Equals(""))
            {
                label22.Visible = true;

            }
            else
            {
                label22.Visible = false;
            }
            if (radioButton1.Text.Equals(""))
            {
                label23.Visible = true;

            }
            else
            {
                label23.Visible = false;
            }
            if ((textBox1.Text.Equals("")) || (textBox2.Text.Equals("")) || (textBox3.Text.Equals("")) || (maskedTextBox1.Text.Equals("")) ||
                (maskedTextBox2.Text.Equals("")) || (maskedTextBox3.Text.Equals("")) || (textBox4.Text.Equals("")) || (richTextBox1.Text.Equals("")) || (radioButton1.Text.Equals("")))  { 
            label11.Visible = false;
        }
            else
            {
                label11.Visible = true;
                if (label11.Visible = true)
                {
                    button2.Visible = true;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            groupBox2.Visible = true;
            button2.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
            
        {
            string user = textBox5.Text;
            string password = maskedTextBox4.Text;
            con = new SqlConnection("Data Source=DESKTOP-K55SVSC\\SQLEXPRESS;Initial Catalog=VeriTabanı;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select *From Table_1 where Kullanıcı_Adı = '"+textBox5.Text  +"'And Şifre = '"+maskedTextBox4.Text+"'";
            dr= com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler Giriş Başarılı");

                label15.Visible = true;
                label16.Visible = false;
                textBox5.Clear();
                maskedTextBox4.Clear();
                Form3 gecis = new Form3();
                gecis.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı yada Şifre");

                label15.Visible = false;
                label16.Visible = true;
            }
            con.Close();
           
            
           
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
