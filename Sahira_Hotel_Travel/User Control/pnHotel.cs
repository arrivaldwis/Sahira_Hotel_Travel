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
    public partial class pnHotel : pnMaster, IViewMethod
    {
        public pnHotel()
        {
            InitializeComponent();
            loadData();
        }

        public void add()
        {
            if (validateAll())
            {
                Hotel hotel = new Hotel();
                hotel.id_hotel = textBox1.Text;
                hotel.name = textBox2.Text;
                hotel.phone = long.Parse(textBox5.Text);
                hotel.address = textBox3.Text;
                hotel.star = int.Parse(comboBox1.Text);

                try
                {
                    data.Hotels.Add(hotel);
                    data.SaveChanges();

                    foreach (DataGridViewRow room in dataGridView1.Rows)
                    {
                        RoomType roomType = new RoomType();
                        roomType.id_hotel = textBox1.Text;
                        roomType.name = room.Cells[0].Value.ToString();
                        roomType.numOfRoom = int.Parse(room.Cells[3].Value.ToString());
                        roomType.normalPrice = double.Parse(room.Cells[1].Value.ToString());
                        roomType.packagePrice = double.Parse(room.Cells[2].Value.ToString());

                        try
                        {
                            data.RoomTypes.Add(roomType);
                            data.SaveChanges();
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                helpers.showError("Sorry, can't add duplicate hotel room data!");
                            }
                            else
                            {
                                helpers.showError(ex.Message);
                            }
                        }
                    }

                    helpers.showInfo("New hotel has been added!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        helpers.showError("Sorry, can't add duplicate hotel data!");
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
                var hotel = data.Hotels.Find(id);
                hotel.id_hotel = textBox1.Text;
                hotel.name = textBox2.Text;
                hotel.phone = long.Parse(textBox5.Text);
                hotel.address = textBox3.Text;
                hotel.star = int.Parse(comboBox1.Text);

                try
                {
                    data.SaveChanges();

                    var HotelRoom = data.RoomTypes.Where(x => x.id_hotel.Equals(id));
                    foreach (var type in HotelRoom)
                    {
                        try
                        {
                            data.RoomTypes.Remove(type);
                            data.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            helpers.showError(ex.Message);
                        }
                    }

                    foreach (DataGridViewRow room in dataGridView1.Rows)
                    {
                        RoomType roomType = new RoomType();
                        roomType.id_hotel = textBox1.Text;
                        roomType.name = room.Cells[0].Value.ToString();
                        roomType.numOfRoom = int.Parse(room.Cells[3].Value.ToString());
                        roomType.normalPrice = double.Parse(room.Cells[1].Value.ToString());
                        roomType.packagePrice = double.Parse(room.Cells[2].Value.ToString());

                        try
                        {
                            data.RoomTypes.Add(roomType);
                            data.SaveChanges();
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                helpers.showError("Sorry, can't add duplicate hotel room data!");
                            }
                            else
                            {
                                helpers.showError(ex.Message);
                            }
                        }
                    }

                    helpers.showInfo("Hotel has been updated!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        helpers.showError("Sorry, can't add duplicate hotel data!");
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
            var HotelRoom = data.RoomTypes.Where(x => x.id_hotel.Equals(id));
            foreach (var type in HotelRoom)
            {
                try
                {
                    data.RoomTypes.Remove(type);
                    data.SaveChanges();
                }
                catch (Exception ex)
                {
                    helpers.showError(ex.Message);
                }
            }

            var Hotel = data.Hotels.Find(id);

            try
            {
                data.Hotels.Remove(Hotel);
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
            for (int i = 0; i < 6; i++ )
            {
                comboBox1.Items.Add(i.ToString());
            }

            comboBox2.Items.Add("Single");
            comboBox2.Items.Add("Double");
            comboBox2.Items.Add("Family Suite");

            DataGridViewTextBoxColumn tipe = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn harga = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn paket = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn jumlah = new DataGridViewTextBoxColumn();
            tipe.HeaderText = "Tipe Kamar";
            harga.HeaderText = "Harga";
            paket.HeaderText = "Harga Paket";
            jumlah.HeaderText = "Jumlah";
            dataGridView1.Columns.Add(tipe);
            dataGridView1.Columns.Add(harga);
            dataGridView1.Columns.Add(paket);
            dataGridView1.Columns.Add(jumlah);

            textBox1.Text = validation.generateCustomerCode("H");

            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
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
                helpers.showExclamation("Address minimum 6 character");
                validAll = false;
            }

            if (textBox5.Text.Any(x => char.IsLetter(x) || char.IsSymbol(x)))
            {
                helpers.showExclamation("Phone only number!");
                validAll = false;
            }

            if (!validation.isPhoneLenghtValid(textBox5.Text))
            {
                helpers.showExclamation("Phone length should be 10-13 digit");
                validAll = false;
            }

            if (dataGridView1.Rows.Count <= 0)
            {
                helpers.showExclamation("Please add at least 1 Room Type");
                validAll = false;
            }

            return validAll;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            add();
            loadParentDataGrid();
        }

        private void loadParentDataGrid()
        {
            ParentForm.refreshData("hotel");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delete(dataId);
            loadParentDataGrid();
        }

        public void populateForm()
        {
            var hotel = data.Hotels.Find(dataId);
            textBox1.Text = hotel.id_hotel;
            textBox2.Text = hotel.name;
            textBox3.Text = hotel.address;
            textBox5.Text = hotel.phone.ToString();
            comboBox1.Text = hotel.star.ToString();

            dataGridView1.Rows.Clear();
            var room = data.RoomTypes.Where(x => x.id_hotel.Equals(dataId));
            foreach (var rooms in room)
            {
                dataGridView1.Rows.Add(rooms.name, rooms.normalPrice, rooms.packagePrice, rooms.numOfRoom);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addRoomType();
        }

        private void addRoomType()
        {
            if (!textBox4.Text.Equals("") && !textBox6.Text.Equals("") && !textBox7.Text.Equals(""))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(comboBox2.Text))
                    {
                        helpers.showExclamation("Sorry, this room type already in database. You can edit by click the type in the list below");
                        return;
                    }
                }

                dataGridView1.Rows.Add(comboBox2.Text, textBox6.Text, textBox7.Text, textBox4.Text);
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            populateRoomType();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            edit(dataId);
            loadParentDataGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            populateRoomType();
        }

        private void populateRoomType()
        {
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
        }
    }
}
