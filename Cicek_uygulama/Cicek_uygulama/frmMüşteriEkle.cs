using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cicek_uygulama
{
    public partial class frmMüşteriEkle : Form
    {
        
        public frmMüşteriEkle()
        {
            InitializeComponent();
            
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=stok_takip;Uid=root;Pwd='';");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMüşteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("insert into müşteri(tc,adsoyad,telefon,adres,email) values (@tc,@adsoyad,@telefon,@adres,@email)", baglanti);
            komut.Parameters.AddWithValue("@tc",txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Kaydı Eklendi.");
            foreach (Control İtem in this.Controls)
            {
                if (İtem is TextBox)
                {
                    İtem.Text = "";
                }
            }
        }
        private void frmMüşteriEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
