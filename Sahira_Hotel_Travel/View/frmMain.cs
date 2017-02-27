using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sahira_Hotel_Travel.View;
using Sahira_Hotel_Travel.User_Control;

namespace Sahira_Hotel_Travel
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnCustomer customer = new pnCustomer();
            frmMasterBase m = new frmMasterBase("customer", customer);
            //DisposeAllButThis(m);
            m.MdiParent = this;
            m.WindowState = FormWindowState.Maximized;
            m.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnAdmin admin = new pnAdmin();
            frmMasterBase m = new frmMasterBase("admin", admin);
            //DisposeAllButThis(m);
            m.MdiParent = this;
            m.WindowState = FormWindowState.Maximized;
            m.Show();
        }

        public void DisposeAllButThis(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == form.GetType()
                    && frm != form)
                {
                    frm.Dispose();
                    frm.Close();
                }
            }
        }

        private void hotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnHotel hotel = new pnHotel();
            frmMasterBase m = new frmMasterBase("hotel", hotel);
            //DisposeAllButThis(m);
            m.MdiParent = this;
            m.WindowState = FormWindowState.Maximized;
            m.Show();
        }

        private void areaWisataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnAreaWisata dest = new pnAreaWisata();
            frmMasterBase m = new frmMasterBase("destination", dest);
            //DisposeAllButThis(m);
            m.MdiParent = this;
            m.WindowState = FormWindowState.Maximized;
            m.Show();
        }
    }
}
