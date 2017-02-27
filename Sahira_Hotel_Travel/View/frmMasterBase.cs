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
            checkMenu(menu);
        }

        private void checkMenu(string menu)
        {
            DataGridViewTextBoxColumn t1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn t2 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn t3 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn t4 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn t5 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn t6 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn t7 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn t8 = new DataGridViewTextBoxColumn();

            if (menu.Equals("admin"))
            {
                this.Text = "User";
                t1.HeaderText = "ID";
                t2.HeaderText = "Username";
                t3.HeaderText = "Nama";
                t4.HeaderText = "Tipe";

                dataGridView1.Columns.Add(t1);
                dataGridView1.Columns.Add(t2);
                dataGridView1.Columns.Add(t3);
                dataGridView1.Columns.Add(t4);

                getAdminData();
            }

            if (menu.Equals("customer"))
            {
                this.Text = "Customer";
                t1.HeaderText = "Kode";
                t2.HeaderText = "Nama";
                t3.HeaderText = "Tipe";
                t4.HeaderText = "Email";
                t5.HeaderText = "Alamat";
                t6.HeaderText = "No Telp";
                t7.HeaderText = "Tanggal Lahir";
                t8.HeaderText = "Warga Negara";

                dataGridView1.Columns.Add(t1);
                dataGridView1.Columns.Add(t2);
                dataGridView1.Columns.Add(t3);
                dataGridView1.Columns.Add(t4);
                dataGridView1.Columns.Add(t5);
                dataGridView1.Columns.Add(t6);
                dataGridView1.Columns.Add(t7);
                dataGridView1.Columns.Add(t8);

                getCustomerData();
            }

            if (menu.Equals("hotel"))
            {
                this.Text = "Hotel";
                t1.HeaderText = "Kode";
                t2.HeaderText = "Nama";
                t3.HeaderText = "Star";
                t4.HeaderText = "No Telp";
                t5.HeaderText = "Alamat";

                dataGridView1.Columns.Add(t1);
                dataGridView1.Columns.Add(t2);
                dataGridView1.Columns.Add(t3);
                dataGridView1.Columns.Add(t4);
                dataGridView1.Columns.Add(t5);

                getHotelData();
            }

            if (menu.Equals("destination"))
            {
                this.Text = "Trip Destination";
                t1.HeaderText = "Kode";
                t2.HeaderText = "Nama";
                t3.HeaderText = "Star";
                t4.HeaderText = "No Telp";
                t5.HeaderText = "Alamat";

                dataGridView1.Columns.Add(t1);
                dataGridView1.Columns.Add(t2);
                dataGridView1.Columns.Add(t3);
                dataGridView1.Columns.Add(t4);
                dataGridView1.Columns.Add(t5);

                getTripDestination();
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
            checkMenu(menu);
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

        private void getHotelData()
        {
            var user = data.Hotels.Select(x => new
            {
                Kode = x.id_hotel,
                Nama = x.name,
                Star = x.star,
                Telp = x.phone,
                Alamat = x.address
            });

            foreach (var d in user)
            {
                dataGridView1.Rows.Add(d.Kode, d.Nama, d.Star, d.Telp, d.Alamat);
            }
        }

        private void getTripDestination()
        {
            var user = data.TripDestinations.Select(x => new
            {
                Kode = x.id_trip,
                Nama = x.name,
                Kawasan = x.Region.name,
                HargaLokal = x.localPrice,
                HargaInter = x.internationalPrice
            });

            foreach (var d in user)
            {
                dataGridView1.Rows.Add(d.Kode, d.Nama, d.Kawasan, d.HargaLokal, d.HargaInter);
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

            if (MENU.Equals("hotel"))
            {
                (PANEL as pnHotel).populateForm();
            }

            if (MENU.Equals("destination"))
            {
                (PANEL as pnAreaWisata).populateForm();
            }
        }
    }
}
