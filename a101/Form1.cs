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


namespace a101
{
    public partial class Form1 : Form
    {
        //KEREM AKMAN 2020507045 A-101 OTOMASYON KODLARI
        public Form1()
        {
            InitializeComponent();
        }
        static string constring = ("Data Source=KEREM-BEY;Initial Catalog=magaza;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);
        SqlCommand komut = new SqlCommand();

        //LİSTELE BUTTON
        public void kayitlari_getir()
        {
            baglan.Open();
            string getir = "SELECT urun_id,urun_isim,urun_marka,urun_fiyat,kg,skt,kategori FROM urunler ";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

            baglan.Close();


        }

        //SİL BUTTON
        public void verisil(int id)
        {

            string sil = "delete from urunler where urun_id = @id";

            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("@id", id);

            komut.ExecuteNonQuery();
            baglan.Close();
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        //COMBOBOX BUTTON KATEGORİLER SECENEGİ
        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            SqlDataReader oku;
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "select * from kategori";
                oku = komut.ExecuteReader();
            while(oku.Read())
            {
                comboBox1.Items.Add(oku[1].ToString());
            }

            baglan.Close();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //EKLEME BUTONU
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayit = "insert into urunler(urun_isim,urun_marka,urun_fiyat,kg,skt,kategori) VALUES (@urun_isim,@urun_marka,@urun_fiyat,@kg,@skt,@kategori)";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@urun_isim", textBox1.Text);
            komut.Parameters.AddWithValue("@urun_marka", textBox2.Text);
            komut.Parameters.AddWithValue("@urun_fiyat", textBox3.Text);
            komut.Parameters.AddWithValue("@kg", textBox5.Text);
            komut.Parameters.AddWithValue("@skt", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@kategori", comboBox1.Text);


            komut.ExecuteNonQuery();
            baglan.Close();
            kayitlari_getir();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            kayitlari_getir();
        }


       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           foreach(DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil(id);
                kayitlari_getir();
            }
        }
        int i = 0;
        //GÜNCELLEME BUTONU
        private void button3_Click(object sender, EventArgs e)
        {
            string kayitguncelle = "update urunler set urun_isim = @urun_isim,urun_marka = @urun_marka,urun_fiyat = @urun_fiyat,skt = @skt where urun_id=@id, kategori=@kategori";
            SqlCommand komut = new SqlCommand(kayitguncelle, baglan);

            baglan.Open();
            komut.Parameters.AddWithValue("@urun_isim", textBox1.Text);
            komut.Parameters.AddWithValue("@urun_marka", textBox2.Text);
            komut.Parameters.AddWithValue("@urun_fiyat", textBox3.Text);
            komut.Parameters.AddWithValue("@skt", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[0].Value);
            komut.Parameters.AddWithValue("@kategori", textBox8.Text);



            komut.ExecuteNonQuery();
            baglan.Close();
            kayitlari_getir();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //ARAMA BUTONU
        private void button5_Click(object sender, EventArgs e)
        {
            string kayit = "Select * from urunler where urun_isim=@urun_isim";
            SqlCommand komut = new SqlCommand(kayit, baglan);

            komut.Parameters.AddWithValue("@urun_isim", textBox7.Text);

            SqlDataAdapter da = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.ShowDialog();
        }
    }
}
