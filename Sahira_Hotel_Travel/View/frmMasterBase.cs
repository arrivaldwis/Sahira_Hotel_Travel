using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sahira_Hotel_Travel.User_Control;

namespace Sahira_Hotel_Travel.View
{
    public partial class frmMasterBase : Form
    {
        string MENU;
        pnMaster PANEL;
        sahira_hotel_travelEntities data = new sahira_hotel_travelEntities();
        public frmMasterBase(string menu, pnMaster panel)
        {
            InitializeComponent();
            MENU = menu;
            PANEL = panel;
            loadData(MENU, PANEL);
        }

        public frmMasterBase()
        {
            InitializeComponent();
        }

        public void refreshData(string menu)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            if (menu.Equals("admin"))
            {
                this.Text = "User";
                DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Username = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Nama = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Tipe = new DataGridViewTextBoxColumn();
                ID.HeaderText = "ID";
                Username.HeaderText = "Username";
                Nama.HeaderText = "Nama";
                Tipe.HeaderText = "Tipe";

                dataGridView1.Columns.Add(ID);
                dataGridView1.Columns.Add(Username);
                dataGridView1.Columns.Add(Nama);
                dataGridView1.Columns.Add(Tipe);

                getAdminData();
            }

            if (menu.Equals("customer"))
            {
                this.Text = "Customer";
                DataGridViewTextBoxColumn Kode = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Nama = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Tipe = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Email = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Alamat = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Telp = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn DOB = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn WNI = new DataGridViewTextBoxColumn();
                Kode.HeaderText = "Kode";
                Nama.HeaderText = "Nama";
                Tipe.HeaderText = "Tipe";
                Email.HeaderText = "Email";
                Alamat.HeaderText = "Alamat";
                Telp.HeaderText = "No Telp";
                DOB.HeaderText = "Tanggal Lahir";
                WNI.HeaderText = "Warga Negara";

                dataGridView1.Columns.Add(Kode);
                dataGridView1.Columns.Add(Nama);
                dataGridView1.Columns.Add(Tipe);
                dataGridView1.Columns.Add(Email);
                dataGridView1.Columns.Add(Alamat);
                dataGridView1.Columns.Add(Telp);
                dataGridView1.Columns.Add(DOB);
                dataGridView1.Columns.Add(WNI);

                getCustomerData();
            }
        }

        public void loadData(string menu, pnMaster panel)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            panel1.Controls.Clear();
            panel.ParentForm = this;
            panel.Dock = DockStyle.Fill;
            panel1.Controls.Add(panel);

            if (menu.Equals("admin"))
            {
                this.Text = "User";
                DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Username = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Nama = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Tipe = new DataGridViewTextBoxColumn();
                ID.HeaderText = "ID";
                Username.HeaderText = "Username";
                Nama.HeaderText = "Nama";
                Tipe.HeaderText = "Tipe";

                dataGridView1.Columns.Add(ID);
                dataGridView1.Columns.Add(Username);
                dataGridView1.Columns.Add(Nama);
                dataGridView1.Columns.Add(Tipe);

                getAdminData();
            }
            
            if (menu.Equals("customer"))
            {
                this.Text = "Customer";
                DataGridViewTextBoxColumn Kode = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Nama = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Tipe = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Email = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Alamat = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Telp = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn DOB = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn WNI = new DataGridViewTextBoxColumn();
                Kode.HeaderText = "Kode";
                Nama.HeaderText = "Nama";
                Tipe.HeaderText = "Tipe";
                Email.HeaderText = "Email";
                Alamat.HeaderText = "Alamat";
                Telp.HeaderText = "No Telp";
                DOB.HeaderText = "Tanggal Lahir";
                WNI.HeaderText = "Warga Negara";

                dataGridView1.Columns.Add(Kode);
                dataGridView1.Columns.Add(Nama);
                dataGridView1.Columns.Add(Tipe);
                dataGridView1.Columns.Add(Email);
                dataGridView1.Columns.Add(Alamat);
                dataGridView1.Columns.Add(Telp);
                dataGridView1.Columns.Add(DOB);
                dataGridView1.Columns.Add(WNI);

                getCustomerData();
            }
        }

        private void getAdminData()
        {
            var user = data.Users.Select(x => new { 
                ID = x.id_user,
                Username = x.username,
                Nama = x.name,
                Tipe = x.UserType.name
            });

            foreach (var d in user)
            {
                dataGridView1.Rows.Add(d.ID, d.Username, d.Nama, d.Tipe);
            }
        }

        private void getCustomerData()
        {
            var user = data.Customers.Select(x => new
            {
                Kode = x.id_customer,
                Nama = x.name,
                Tipe = x.CustomerType.type,
                Email = x.email,
                Alamat = x.address,
                Telp = x.phone,
                DOB = x.dob,
                Kewarganegaraan = x.nationality
            });

            foreach (var d in user)
            {
                dataGridView1.Rows.Add(d.Kode, d.Nama, d.Tipe, d.Email, d.Alamat, d.Telp, d.DOB, d.Kewarganegaraan);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PANEL.ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (MENU.Equals("admin"))
            {
                (PANEL as pnAdmin).populateForm();
            }

            if (MENU.Equals("customer"))
            {
                (PANEL as pnCustomer).populateForm();
            }
        }
    }
}
