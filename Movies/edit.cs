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
    public partial class edit : Form
    {
        public edit()
        {
            InitializeComponent();
        }

        private void edit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moviesDataSet.infos' table. You can move, or remove it, as needed.
            this.infosTableAdapter.Fill(this.moviesDataSet.infos);

            comboBox3.SelectedItem = null;
            comboBox3.SelectedText = "name"; 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
           
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ELMEDIN-PC;Initial Catalog=movies;Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("UPDATE infos SET name='" + textBox2.Text + "',category='" + comboBox1.Text + "',actor1='" + textBox3.Text + "',actor2='" + textBox4.Text + "',producer='" + textBox5.Text + "' WHERE id='" + textBox1.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "infos");
            this.dataGridView1.DataSource = ds.Tables["infos"];
            MessageBox.Show("Data changed");
            con.Close();
            SqlDataAdapter daF = new SqlDataAdapter("SELECT * FROM infos", con);
            daF.Fill(ds, "infos");
            this.dataGridView1.DataSource = ds.Tables[0];
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ELMEDIN-PC;Initial Catalog=movies;Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM infos WHERE id='" + textBox1.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "infos");
            this.dataGridView1.DataSource = ds.Tables["infos"];
            MessageBox.Show("Movie  " + textBox2.Text + "  was deleted");
            con.Close();
            SqlDataAdapter daf = new SqlDataAdapter("SELECT * FROM infos", con);
            daf.Fill(ds, "infos");
            this.dataGridView1.DataSource = ds.Tables[0];
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connn = new SqlConnection("Data Source=ELMEDIN-PC;Initial Catalog=movies;Integrated Security=True");
            connn.Open();
            
                SqlDataAdapter daf = new SqlDataAdapter("SELECT * FROM infos WHERE " + comboBox3.Text + " LIKE'%" + textBox6.Text + "%'", connn);
                DataSet ds = new DataSet();
                daf.Fill(ds, "infos");
                this.dataGridView1.DataSource = ds.Tables[0];
                connn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                comboBox1.Text = "";

            }
        

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
