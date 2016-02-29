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
    public partial class ClientPayment : Form
    {
        public ClientPayment()
        {
            InitializeComponent();
            fillCombo();
            showTable();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HotelManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);


        private void fillCombo()
        {
            string quary = "SELECT * FROM managereservation";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // string dname = reader["Column1"].ToString();
                    comboBox1.Items.Add(reader[0].ToString());
                }

                con.Close();
            }
            catch { }
        }

        private void save()
        {


            string insertCommand = "INSERT INTO clientpayment(ClientID,ClientName,ReservationID,RoomType,RoomNum,RoomRent,FoodCharge,Utility,Discount,Netbill) " +
                                    "VALUES(@ClientID,@ClientName,@ReservationID,@RoomType,@RoomNum,@RoomRent,@FoodCharge,@Utility,@Discount,@Netbill)";
                                   
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@ClientID", comboBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p9 = new SqlParameter("@ClientName", textBox1.Text);
            command.Parameters.Add(p9);
            SqlParameter p2 = new SqlParameter("@ReservationID", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@RoomType", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@RoomNum", textBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@FoodCharge", textBox6.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@Utility", textBox7.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@Discount", textBox8.Text);
            command.Parameters.Add(p7);
            SqlParameter p8 = new SqlParameter("@Netbill", textBox9.Text);
            command.Parameters.Add(p8);
            SqlParameter p10 = new SqlParameter("@RoomRent", textBox5.Text);
            command.Parameters.Add(p10);



            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string quary = "SELECT * FROM managereservation WHERE ClientID='" + comboBox1.Text + "'";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    textBox1.Text = reader[1].ToString();
                    textBox2.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();
                    textBox4.Text = reader[4].ToString();

                }

                con.Close();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculate();
            save();
        }

        private void calculate() {
            try
            {
                int roomrent = int.Parse(textBox5.Text);
                int foodcharge = int.Parse(textBox6.Text);
                int utility = int.Parse(textBox7.Text);
                int discount = int.Parse(textBox8.Text);

                int total;

                total = roomrent + foodcharge + utility - discount;

                textBox9.Text = total.ToString();
            }
            catch { MessageBox.Show("Invalid Input !!"); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            calculate();
        }

        private void showTable()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM clientpayment", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void delete()
        {
            string deleteCommand = "DELETE FROM clientpayment WHERE ClientID=@ClientID";
            SqlCommand command = new SqlCommand(deleteCommand, con);

            SqlParameter p1 = new SqlParameter("@ClientID", textBox10.Text);
            command.Parameters.Add(p1);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Delete Successfull !!");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void search()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM clientpayment WHERE ClientID LIKE ('" + textBox10.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
