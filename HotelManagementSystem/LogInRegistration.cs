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
    public partial class LogInRegistration : Form
    {
        public LogInRegistration()
        {
            InitializeComponent();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HotelManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            login log = new login();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertcommand = "INSERT INTO login(username, password) " +
                                                   "VALUES(@username,@password)";
            SqlCommand command = new SqlCommand(insertcommand, con);

            SqlParameter p1 = new SqlParameter("@username", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@password", textBox2.Text);
            command.Parameters.Add(p2);

            if (textBox2.Text == textBox3.Text)
            {
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully Registered !!", "Success");
                    con.Close();
                }
                catch { MessageBox.Show("This User Name is Already Exists", "Error"); }

            }
            else
            {
                MessageBox.Show("Password does not match !!", "Error");
            }
        }
    }
}
