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

namespace SqlOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Öğrenciler;Integrated Security=True");//bağlantı oluşturuldu.
        private void VerilerimiGoster()
        {
            baglan.Open();//liste açıldı.
            SqlCommand komut = new SqlCommand("select *from Bilgiler",baglan);//listeleme işlemi sql komutu
            SqlDataReader oku = komut.ExecuteReader();//okuma işlemi

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem(); //listeye ekleme işlemi
                ekle.Text = oku["Ad Soyad"].ToString();
                ekle.SubItems.Add(oku["Şehir"].ToString());
                ekle.SubItems.Add(oku["Okul"].ToString());
                ekle.SubItems.Add(oku["Kulup"].ToString());
                listView1.Items.Add(ekle); //ekrana verilmesi
            }
            baglan.Close();//açılan listenin kapatılması.
        }
        private void button1_Click(object sender, EventArgs e)
        {
            VerilerimiGoster();//butona tıklandığında verilerimiGoster fonksiyonu açıldı.
        }
    }
}
