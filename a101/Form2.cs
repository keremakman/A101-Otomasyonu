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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        static string constring = ("Data Source=KEREM-BEY;Initial Catalog=magaza;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);
        SqlCommand komut = new SqlCommand();


        public void kayitlari_getir2()
        {
            baglan.Open();
            string getir = "select * from personel ";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

            baglan.Close();


        }





        public void verisil(int id)
        {

            string sil = "delete from personel where personel_id = @id";

            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("@id", id);

            komut.ExecuteNonQuery();
            baglan.Close();
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string kayitguncelle2 = "update personel set personel_isim = @personel_isim,personel_telefon = @personel_telefon,personel_adres = @personel_adres,personel_maas = @personel_maas, personel_gorev = @personel_gorev where personel_id=@id";
            SqlCommand komut = new SqlCommand(kayitguncelle2, baglan);

            baglan.Open();
            komut.Parameters.AddWithValue("@oersonel_isim", textBox1.Text);
            komut.Parameters.AddWithValue("@personel_telefon", textBox2.Text);
            komut.Parameters.AddWithValue("@personel_adres", textBox3.Text);
            komut.Parameters.AddWithValue("@personel_maas", textBox4.Text);
            komut.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[0].Value);
            komut.Parameters.AddWithValue("@personel_gorev", textBox5.Text);



            komut.ExecuteNonQuery();
            baglan.Close();
            kayitlari_getir2();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;

            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayit = "insert into personel(personel_isim,personel_telefon,personel_adres,personel_maas,personel_gorev) VALUES (@personel_isim,@personel_telefon,@personel_adres,@personel_maas,@personel_gorev)";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@personel_isim", textBox1.Text);
            komut.Parameters.AddWithValue("@personel_telefon", textBox2.Text);
            komut.Parameters.AddWithValue("@personel_adres", textBox3.Text);
            komut.Parameters.AddWithValue("@personel_maas", textBox5.Text);
            komut.Parameters.AddWithValue("@personel_gorev", textBox4.Text);


            komut.ExecuteNonQuery();
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kayitlari_getir2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil(id);
                kayitlari_getir2();
            }
        }
        int i = 0;
    }
}
