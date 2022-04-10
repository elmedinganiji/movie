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

namespace Movies
{
    public partial class insert : Form
    {
        public insert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=ELMEDIN-PC;Initial Catalog=movies;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO infos(name,category,actor1,actor2,producer)  VALUES('" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("The movie was succesfully inserted");
            conn.Close();
            SqlDataAdapter daf = new SqlDataAdapter("SELECT * from infos ", conn);
            DataSet ds = new DataSet();
            daf.Fill(ds, "infos");
            this.dataGridView1.DataSource = ds.Tables[0];
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            
        }
    }
}
