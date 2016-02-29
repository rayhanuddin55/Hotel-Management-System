using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class MDIParent : Form
    {
        public MDIParent()
        {
            InitializeComponent();
        }

        private void manageClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClient mc = new ManageClient();
            mc.MdiParent = this;
            mc.Show();
        }

        private void manageReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manageReservation mr = new manageReservation();
            mr.MdiParent = this;
            mr.Show();
        }

        private void clientPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientPayment cp = new ClientPayment();
            cp.MdiParent = this;
            cp.Show();
        }

        private void satisfactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatisfactionSurvey ss = new SatisfactionSurvey();
            ss.MdiParent = this;
            ss.Show();
        }

        private void clientSatisfactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientsatisfaction cf = new clientsatisfaction();
            cf.MdiParent = this;
            cf.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
