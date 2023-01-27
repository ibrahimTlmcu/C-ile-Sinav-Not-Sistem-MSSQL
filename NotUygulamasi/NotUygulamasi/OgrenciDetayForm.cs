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

namespace NotUygulamasi
{
    public partial class OgrenciDetayForm : Form
    {
        public OgrenciDetayForm()
        {
            InitializeComponent();
        }

        public string numara; 
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RU7O3J5;Initial Catalog=NotKayitDB;Integrated Security=True");

        private void OgrenciDetayForm_Load(object sender, EventArgs e)
        {
            label9.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBL_Ders where OGRNUMARA =@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr  = komut.ExecuteReader();

            while (dr.Read())
            {
                adsoyad.Text = dr[2].ToString() + " " +  dr[3].ToString();
                sinav1.Text = dr[4].ToString();
                sinav2.Text = dr[5].ToString();
                sinav3.Text = dr[6].ToString();
                Ortalama.Text = dr[7].ToString();
                Durum.Text = dr[8].ToString();
                

            }
            baglanti.Close();

        }
    }
}
