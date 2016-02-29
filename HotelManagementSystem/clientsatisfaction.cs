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
    public partial class clientsatisfaction : Form
    {
        public clientsatisfaction()
        {
            InitializeComponent();
            showTable();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HotelManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);


        private void showTable()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM satisfactionsurvey", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
