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

namespace HotelManagementSystem
{
    public partial class ManageClient : Form
    {
        public ManageClient()
        {
            InitializeComponent();
            showTable();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HotelManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);


        private void save()
        {


            string insertCommand = "INSERT INTO manageclient(ClientID,FirstName,LastName,MobileNo,Country) " +
                                    "VALUES(@ClientID,@FirstName,@LastName,@MobileNo,@Country)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@ClientID", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@FirstName", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@LastName", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@MobileNo", textBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@Country", textBox5.Text);
            command.Parameters.Add(p5);
            
            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }

        private void update()
        {


            string updateCommand = "UPDATE manageclient SET ClientID=@ClientID,FirstName=@FirstName,LastName=@LastName,MobileNo=@MobileNo,Country=@Country " +
                                      "WHERE ClientID=@ClientID";
            SqlCommand command = new SqlCommand(updateCommand, con);

            SqlParameter p1 = new SqlParameter("@ClientID", textBox10.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@FirstName", textBox6.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@LastName", textBox7.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@MobileNo", textBox8.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@Country", textBox9.Text);
            command.Parameters.Add(p5);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("update Successfull !!");
            con.Close();

        }

        private void showTable()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM manageclient", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void search()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM manageclient WHERE ClientID LIKE ('" + textBox11.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            search();
        }

        private void delete()
        {
            string deleteCommand = "DELETE FROM manageclient WHERE ClientID=@ClientID";
            SqlCommand command = new SqlCommand(deleteCommand, con);

            SqlParameter p1 = new SqlParameter("@ClientID", textBox11.Text);
            command.Parameters.Add(p1);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Delete Successfull !!");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            //ClientID,FirstName,LastName,MobileNo,Country

            textBox10.Text = row.Cells["ClientID"].Value.ToString();
            textBox6.Text = row.Cells["FirstName"].Value.ToString();
            textBox7.Text = row.Cells["LastName"].Value.ToString();
            textBox8.Text = row.Cells["MobileNo"].Value.ToString();
            textBox9.Text = row.Cells["Country"].Value.ToString();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
