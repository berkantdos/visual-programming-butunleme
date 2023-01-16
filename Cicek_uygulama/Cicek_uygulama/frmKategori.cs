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
    public partial class frmKategori : Form
    {

        public frmKategori()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=stok_takip;Uid=root;Pwd='';");
        bool durum;

        private void kategorikontrol()
        {
            durum = true;
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select *from kategoribilgileri",baglanti);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if(textBox1.Text == read["kategori"].ToString() || textBox1.Text =="")
                {
                    durum=false;
                }
            }
            baglanti.Close();
            
        }
        private void frmKategori_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategorikontrol();
            if (durum==true)
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("insert into kategoribilgileri(kategori) values ('" + textBox1.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kategori Eklendi");
            }
            else
            {
                MessageBox.Show("Böyle Bir Kategori Var","Uyarı");
            }
            textBox1.Text = "";
        }
    }
}
