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


namespace secim_istatistik_projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Connection_String_Name");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT into TBLILCE (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) values (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
            komut.Parameters.AddWithValue("@P1", textBox1.Text);
            komut.Parameters.AddWithValue("@P2", textBox2.Text);
            komut.Parameters.AddWithValue("@P3", textBox3.Text);
            komut.Parameters.AddWithValue("@P4", textBox4.Text);
            komut.Parameters.AddWithValue("@P5", textBox5.Text);
            komut.Parameters.AddWithValue("@P6", textBox6.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy girişi database yapıldı.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm1 = new FrmGrafikler();
            frm1.Show();
            this.Hide();
        }
    }
}
