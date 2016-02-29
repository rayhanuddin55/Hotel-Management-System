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
    public partial class manageReservation : Form
    {
        public manageReservation()
        {
            InitializeComponent();
            showTable();
            fillCombo();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HotelManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        private void fillCombo()
        {
            string quary = "SELECT * FROM manageClient";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // string dname = reader["Column1"].ToString();
                    comboBox5.Items.Add(reader[0].ToString());
                }

                con.Close();
            }
            catch { }
        }


        private void save()
        {


            string insertCommand = "INSERT INTO ManageReservation(ClientID,ClientName,ReservationID,TypeRoom,NumRoom,DateIn,DateOut) " +
                                    "VALUES(@ClientID,@ClientName,@ReservationID,@TypeRoom,@NumRoom,@DateIn,@DateOut)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@ClientID", comboBox5.Text);
            command.Parameters.Add(p1);
            SqlParameter p9 = new SqlParameter("@ClientName", textBox1.Text);
            command.Parameters.Add(p9);
            SqlParameter p2 = new SqlParameter("@ReservationID", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@TypeRoom", comboBox1.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@NumRoom", comboBox2.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@DateIn", dateTimePicker1.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@DateOut", dateTimePicker2.Text);
            command.Parameters.Add(p6);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            save();
        }
        private void showTable()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM ManageReservation", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void delete()
        {
            string deleteCommand = "DELETE FROM ManageReservation WHERE ClientID=@ClientID";
            SqlCommand command = new SqlCommand(deleteCommand, con);

            SqlParameter p1 = new SqlParameter("@ClientID", textBox5.Text);
            command.Parameters.Add(p1);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Delete Successfull !!");
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void update()
        {


            string updateCommand = "UPDATE ManageReservation SET ClientID=@ClientID,ClientName=@ClientName,ReservationID=@ReservationID,TypeRoom=@TypeRoom,NumRoom=@NumRoom,DateIn=@DateIn,DateOut=@DateOut " +
                                      "WHERE ClientID=@ClientID";
            SqlCommand command = new SqlCommand(updateCommand, con);

            SqlParameter p1 = new SqlParameter("@ClientID", textBox3.Text);
            command.Parameters.Add(p1);
            SqlParameter p9 = new SqlParameter("@ClientName", textBox6.Text);
            command.Parameters.Add(p9);
            SqlParameter p2 = new SqlParameter("@ReservationID", textBox4.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@TypeRoom", comboBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@NumRoom", comboBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@DateIn", dateTimePicker3.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@DateOut", dateTimePicker4.Text);
            command.Parameters.Add(p6);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("update Successfull !!");
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            //ClientID,ReservationID,TypeRoom,NumRoom,DateIn,DateOut

            textBox3.Text = row.Cells["ClientID"].Value.ToString();
            textBox6.Text = row.Cells["clientname"].Value.ToString();
            textBox4.Text = row.Cells["ReservationID"].Value.ToString();
            comboBox3.Text = row.Cells["TypeRoom"].Value.ToString();
            comboBox4.Text = row.Cells["NumRoom"].Value.ToString();
            dateTimePicker3.Text = row.Cells["DateIn"].Value.ToString();
            dateTimePicker4.Text = row.Cells["DateOut"].Value.ToString();
        }
        private void search()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM ManageReservation WHERE ClientID LIKE ('" + textBox5.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            search();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string quary = "SELECT * FROM manageClient WHERE ClientID='" + comboBox5.Text + "'";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    textBox1.Text = reader[1].ToString();
                   
                }

                con.Close();
            }
            catch { }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
