using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sahira_Hotel_Travel.Helper;
using System.Data.SqlClient;

namespace Sahira_Hotel_Travel.User_Control
{
    public partial class pnPackageList : pnMaster, IViewMethod
    {
        public pnPackageList()
        {
            InitializeComponent();
            loadData();
        }

        private string getHotelId(string name)
        {
            string hotelId = data.Hotels.Where(x => x.name.Equals(name)).Select(x => x.id_hotel).FirstOrDefault();
            return hotelId;
        }

        private int getRoomTypeId(string hotelId)
        {
            int typeId = data.RoomTypes.Where(x => x.id_hotel.Equals(hotelId)).Select(x => x.id_roomType).FirstOrDefault();
            return typeId;
        }

        private double getRoomPrice(string hotelId)
        {
            double roomPrice = data.RoomTypes.Where(x => x.id_hotel.Equals(hotelId) && x.name.Equals(comboBox3.Text)).Select(x => x.packagePrice).FirstOrDefault();
            return roomPrice*int.Parse(textBox5.Text);
        }

        private double sumOfLocalPrice()
        {
            double sum = getRoomPrice(getHotelId(comboBox1.Text));
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sum += double.Parse(row.Cells[3].Value.ToString());
            }
            return sum;
        }

        private double sumOfInternationalPrice()
        {
            double sum = getRoomPrice(getHotelId(comboBox1.Text));
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sum += double.Parse(row.Cells[4].Value.ToString());
            }
            return sum;
        }

        public void add()
        {
            if (validateAll())
            {
                TripPackage package = new TripPackage();
                package.id_package = textBox1.Text;
                package.name = textBox2.Text;
                package.description = textBox3.Text;
                package.id_hotel = getHotelId(comboBox1.Text);
                package.id_roomType = getRoomTypeId(comboBox3.Text);
                package.totalPrice_local = sumOfLocalPrice();
                package.totalPrice_international = sumOfInternationalPrice();
                package.dayOfTrip = int.Parse(textBox5.Text);

                /*helpers.showInfo(textBox1.Text + "\n " + textBox2.Text + "\n " + textBox3.Text + "\n " + getHotelId(comboBox1.Text) + "\n " + getRoomTypeId(comboBox3.Text) + "\n " + sumOfLocalPrice() + "\n " + sumOfInternationalPrice());*/

                try
                {
                    data.TripPackages.Add(package);
                    data.SaveChanges();

                    foreach (DataGridViewRow room in dataGridView1.Rows)
                    {
                        TripPackageDetail roomType = new TripPackageDetail();
                        roomType.id_package = textBox1.Text;
                        roomType.id_trip = room.Cells[0].Value.ToString();

                        try
                        {
                            data.TripPackageDetails.Add(roomType);
                            data.SaveChanges();
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                helpers.showError("Sorry, can't add duplicate package data!");
                            }
                            else
                            {
                                helpers.showError(ex.Message);
                            }
                        }
                    }

                    helpers.showInfo("New package has been added!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        helpers.showError("Sorry, can't add duplicate package data!");
                    }
                    else
                    {
                        helpers.showError(ex.Message);
                    }
                }
            }
        }

        public void edit(string id)
        {
            if (validateAll())
            {
                var package = data.TripPackages.Find(id);
                package.name = textBox2.Text;
                package.description = textBox3.Text;
                package.id_hotel = getHotelId(comboBox1.Text);
                package.id_roomType = getRoomTypeId(comboBox3.Text);
                package.totalPrice_local = sumOfLocalPrice();
                package.totalPrice_international = sumOfInternationalPrice();
                package.dayOfTrip = int.Parse(textBox5.Text);

                try
                {
                    data.SaveChanges();

                    var PackageDetails = data.TripPackageDetails.Where(x => x.id_package.Equals(id));
                    foreach (var type in PackageDetails)
                    {
                        try
                        {
                            data.TripPackageDetails.Remove(type);
                            data.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            helpers.showError(ex.Message);
                        }
                    }

                    foreach (DataGridViewRow room in dataGridView1.Rows)
                    {
                        TripPackageDetail roomType = new TripPackageDetail();
                        roomType.id_package = textBox1.Text;
                        roomType.id_trip = room.Cells[0].Value.ToString();

                        try
                        {
                            data.TripPackageDetails.Add(roomType);
                            data.SaveChanges();
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                helpers.showError("Sorry, can't add duplicate package room data!");
                            }
                            else
                            {
                                helpers.showError(ex.Message);
                            }
                        }
                    }

                    helpers.showInfo("Package has been updated!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        helpers.showError("Sorry, can't add duplicate package data!");
                    }
                    else
                    {
                        helpers.showError(ex.Message);
                    }
                }
            }
        }

        public void delete(string id)
        {
            var PackageDetails = data.TripPackageDetails.Where(x => x.id_package.Equals(id));
            foreach (var type in PackageDetails)
            {
                try
                {
                    data.TripPackageDetails.Remove(type);
                    data.SaveChanges();
                }
                catch (Exception ex)
                {
                    helpers.showError(ex.Message);
                }
            }

            var Package = data.TripPackages.Find(id);

            try
            {
                data.TripPackages.Remove(Package);
                data.SaveChanges();
                helpers.showInfo("Data has been removed!");
            }
            catch (Exception ex)
            {
                helpers.showError(ex.Message);
            }
        }

        public bool isFieldStillEmpty()
        {
            bool yes = false;
            foreach (var text in this.Controls.OfType<TextBox>().Where(x => x.Text == "")) yes = true;
            return yes;
        }

        public void loadData()
        {
            foreach(var hotel in data.Hotels)
            {
                comboBox1.Items.Add(hotel.name);
            }

            foreach (var dest in data.TripDestinations)
            {
                comboBox2.Items.Add(dest.id_trip+" - "+dest.name);
            }

            DataGridViewTextBoxColumn kode = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn nama = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn kawasan = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn harga_lokal = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn harga_inter = new DataGridViewTextBoxColumn();
            kode.HeaderText = "Kode";
            nama.HeaderText = "Nama";
            kawasan.HeaderText = "Kawasan";
            harga_lokal.HeaderText = "Harga Lokal";
            harga_inter.HeaderText = "Harga Internasional";
            dataGridView1.Columns.Add(kode);
            dataGridView1.Columns.Add(nama);
            dataGridView1.Columns.Add(kawasan);
            dataGridView1.Columns.Add(harga_lokal);
            dataGridView1.Columns.Add(harga_inter);

            textBox1.Text = validation.generateCustomerCode("P");

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private bool validateAll()
        {
            bool validAll = true;

            if (!validation.isNameLengthGreaterEqualThan3(textBox2.Text))
            {
                helpers.showExclamation("Name minimum 3 character");
                validAll = false;
            }

            if (!validation.isAddressLenghtGreaterEqualThan6(textBox3.Text))
            {
                helpers.showExclamation("Descriptions minimum 6 character");
                validAll = false;
            }

            if (textBox5.Text.Any(x => char.IsLetter(x) || char.IsSymbol(x)))
            {
                helpers.showExclamation("Duration only number!");
                validAll = false;
            }

            if (!validation.isDurationValid(textBox5.Text))
            {
                helpers.showExclamation("Duration length should be 3-5 digit");
                validAll = false;
            }

            if (dataGridView1.Rows.Count <= 0)
            {
                helpers.showExclamation("Please add at least 1 Destinations");
                validAll = false;
            }

            return validAll;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var roomType in data.RoomTypes.Where(x=>x.Hotel.name.Equals(comboBox1.Text)))
            {
                comboBox3.Items.Add(roomType.name);
            }

            comboBox3.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addTripDestinations();
        }

        private void addTripDestinations()
        {
            string destId = comboBox2.Text.Split('-')[0].Trim();
            if (!comboBox2.Text.Equals(""))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(destId))
                    {
                        helpers.showExclamation("Sorry, this destinations already in database. You can edit by click the type in the list below");
                        return;
                    }
                }

                var detail_dest = data.TripDestinations.Find(destId);
                dataGridView1.Rows.Add(detail_dest.id_trip, detail_dest.name, detail_dest.Region.name, detail_dest.localPrice, detail_dest.internationalPrice);
            }
            else
            {
                helpers.showExclamation("Please complete the form!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                dataGridView1.Rows.Remove(selectedRow);
            }
            else
            {
                helpers.showExclamation("Choose the data first!");
            }
        }

        int rowIndex;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            populateTripDestinations();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            add();
            loadParentDataGrid();
        }

        private void loadParentDataGrid()
        {
            ParentForm.refreshData("package_list");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            edit(dataId);
            loadParentDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delete(dataId);
            loadParentDataGrid();
        }

        public void populateForm()
        {
            var package = data.TripPackages.Find(dataId);
            textBox1.Text = package.id_package;
            textBox2.Text = package.name;
            textBox3.Text = package.description;
            textBox5.Text = package.dayOfTrip.ToString();
            comboBox1.Text = package.Hotel.name;
            comboBox3.Text = package.RoomType.name;

            dataGridView1.Rows.Clear();
            var room = data.TripPackageDetails.Where(x => x.id_package.Equals(dataId));
            foreach (var trip in room)
            {
                dataGridView1.Rows.Add(trip.TripDestination.id_trip, trip.TripDestination.name, trip.TripDestination.Region.name, trip.TripDestination.localPrice, trip.TripDestination.internationalPrice);
            }
        }

        private void populateTripDestinations()
        {
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString() + " - " + dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
        }
    }
}
