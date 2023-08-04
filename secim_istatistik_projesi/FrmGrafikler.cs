using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace secim_istatistik_projesi
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Connection_String_Name");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //ComcoBox içerisine İlçe Adlarını getirme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT ILCEAD FROM TBLILCE", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            //Grafiğe Toplam Sonuçları Getirme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM TBLILCE", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİ", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİ", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİ", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİ", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİ", dr2[4]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLILCE WHERE ILCEAD=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr3 = komut.ExecuteReader();
            while (dr3.Read())
            {
                progressBar1.Value = Convert.ToInt32(dr3[2].ToString());
                progressBar2.Value = Convert.ToInt32(dr3[3].ToString());
                progressBar3.Value = Convert.ToInt32(dr3[4].ToString());
                progressBar4.Value = Convert.ToInt32(dr3[5].ToString());
                progressBar5.Value = Convert.ToInt32(dr3[6].ToString());

                label7.Text = dr3[2].ToString();
                label8.Text = dr3[3].ToString();
                label9.Text = dr3[4].ToString();
                label10.Text = dr3[5].ToString();
                label11.Text = dr3[6].ToString();
            }
            baglanti.Close();
        }
    }
}
