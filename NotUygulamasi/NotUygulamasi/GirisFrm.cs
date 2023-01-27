using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotUygulamasi
{
    public partial class GirisFrm : Form
    {
        public GirisFrm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(maskedTextBox1.Text == "1111")
            {
                MessageBox.Show("Hatali Giris !");
                Close();
            }

            
            OgrenciDetayForm frm = new OgrenciDetayForm();
            frm.numara = maskedTextBox1.Text;
            frm.Show();
            

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
          
        }

       
        private void maskedTextBox1_TextChanged_1(object sender, EventArgs e)
        {

            if(maskedTextBox1.Text == "1111")
            {
                OgretmenDetayForm frm = new OgretmenDetayForm();
                frm.Show();
            
            }
          
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }

        private void maskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(maskedTextBox2.Text == "1111")
            {
             OgretmenDetayForm Ogrtmform = new OgretmenDetayForm();  
            Ogrtmform.Show();
            }
            else
            {
                MessageBox.Show("Hatali Giris ! ");
            }

            
        }

        private void button1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
