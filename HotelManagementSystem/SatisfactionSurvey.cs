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
    public partial class SatisfactionSurvey : Form
    {
        public SatisfactionSurvey()
        {
            InitializeComponent();
            fillCombo();
        }

                static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HotelManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        private void fillCombo()
        {
            string quary = "SELECT * FROM manageclient";
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

        private void SatisfactionSurvey_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void save()
        {


            string insertCommand = "INSERT INTO SatisfactionSurvey(ClientID,ClientName,RoomService,FoodService) " +
                                    "VALUES(@ClientID,@ClientName,@RoomService,@RoomService)";

            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@ClientID", comboBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p9 = new SqlParameter("@ClientName", textBox1.Text);
            command.Parameters.Add(p9);
            SqlParameter p2 = new SqlParameter("@RoomService", comboBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@FoodService", comboBox3.Text);
            command.Parameters.Add(p3);
           



            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string quary = "SELECT * FROM manageclient WHERE ClientID='" + comboBox1.Text + "'";
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
    }
}
