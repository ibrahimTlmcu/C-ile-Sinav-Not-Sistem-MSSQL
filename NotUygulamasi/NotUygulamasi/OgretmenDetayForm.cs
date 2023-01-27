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
    public partial class OgretmenDetayForm : Form
    {
        public OgretmenDetayForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RU7O3J5;Initial Catalog=NotKayitDB;Integrated Security=True");
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void OgretmenDetayForm_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'notKayitDBDataSet.TBL_DERS' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBL_DERSTableAdapter.Fill(this.notKayitDBDataSet.TBL_DERS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_DERS (OGRNUMARA,OGRAD,OGRSOYAD) " +
            "values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", OgrNumara.Text);
            komut.Parameters.AddWithValue("@p2", OgrAd.Text);
            komut.Parameters.AddWithValue("@p3", OgrSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ogrenci Sisteme Eklendi ! ");
            this.tBL_DERSTableAdapter.Fill(this.notKayitDBDataSet.TBL_DERS);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(TxtSinav1.Text);
            s2 = Convert.ToDouble(TxtSinav2.Text);
            s3 = Convert.ToDouble(TxtSinav3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            LblOrtalama.Text = ortalama.ToString();
           


            if (ortalama >= 50)
            {
                durum = "True";

            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBL_DERS set OGRSINAV1 = @p1 , OGRSINAV2 = @p2 ,OGRSINAV3 =@p3,ORT =@p4,DURUM =@p5 WHERE  OGRNUMARA =@p6",baglanti);
            komut.Parameters.AddWithValue("@p1", TxtSinav1.Text);
            komut.Parameters.AddWithValue("@p2", TxtSinav2.Text) ;
            komut.Parameters.AddWithValue("@p3", TxtSinav3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(LblOrtalama.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", OgrNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            
            MessageBox.Show("Ogrenci Notlari Guncellendi !!");
            this.tBL_DERSTableAdapter.Fill(this.notKayitDBDataSet.TBL_DERS);


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            OgrNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            OgrAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            OgrSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
     
        }
    }
}
