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
    public partial class pnAreaWisata : pnMaster, IViewMethod
    {
        public pnAreaWisata()
        {
            InitializeComponent();
            loadData();
        }

        private int getRegionId(string name)
        {
            int regionId = data.Regions.Where(x => x.name.Equals(name)).Select(x=>x.id_region).FirstOrDefault();
            return regionId;
        }

        public void add()
        {
            if (validateAll())
            {
                TripDestination dest = new TripDestination();
                dest.id_trip = textBox1.Text;
                dest.name = textBox2.Text;
                dest.id_region = getRegionId(comboBox1.Text);
                dest.address = textBox3.Text;
                dest.description = textBox6.Text;
                dest.localPrice = double.Parse(textBox5.Text);
                dest.internationalPrice = double.Parse(textBox8.Text);

                try
                {
                    data.TripDestinations.Add(dest);
                    data.SaveChanges();

                    Gallery photo = new Gallery();
                    photo.id_trip = textBox1.Text;
                    photo.photo = textBox4.Text;

                    try
                    {
                        data.Galleries.Add(photo);
                        data.SaveChanges();
                        helpers.showInfo("New destinations has been added!");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            helpers.showError("Sorry, can't add duplicate destinations data!");
                        }
                        else
                        {
                            helpers.showError(ex.Message);
                        }
                    }

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        helpers.showError("Sorry, can't add duplicate destinations data!");
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
                var dest = data.TripDestinations.Find(id);
                dest.id_trip = textBox1.Text;
                dest.name = textBox2.Text;
                dest.id_region = getRegionId(comboBox1.Text);
                dest.address = textBox3.Text;
                dest.description = textBox6.Text;
                dest.localPrice = double.Parse(textBox5.Text);
                dest.internationalPrice = double.Parse(textBox8.Text);

                try
                {
                    data.SaveChanges();

                    var photo = data.Galleries.Where(x => x.id_trip.Equals(textBox1.Text)).FirstOrDefault();
                    photo.photo = textBox4.Text;

                    try
                    {
                        data.SaveChanges();
                        helpers.showInfo("Destinations has been updated!");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            helpers.showError("Sorry, can't add duplicate destinations data!");
                        }
                        else
                        {
                            helpers.showError(ex.Message);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        helpers.showError("Sorry, can't add duplicate destinations data!");
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
            try
            {
                var destPackage = data.TripPackageDetails.Where(x => x.id_trip.Equals(id));
                foreach (var desti in destPackage)
                {
                    data.TripPackageDetails.Remove(desti);
                    data.SaveChanges();
                }
            }
            catch (Exception ex) { }

            var photo = data.Galleries.Where(x => x.id_trip.Equals(id));
            foreach (var img in photo)
            {
                data.Galleries.Remove(img);
                data.SaveChanges();
            }

            var dest = data.TripDestinations.Find(id);

            try
            {
                data.TripDestinations.Remove(dest);
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
            foreach (var region in data.Regions)
            {
                comboBox1.Items.Add(region.name);
            }
            textBox1.Text = validation.generateCustomerCode("W");
            comboBox1.SelectedIndex = 0;
        }

        bool isPhotoSelected = false;
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
                helpers.showExclamation("Price only number!");
                validAll = false;
            }

            if (textBox8.Text.Any(x => char.IsLetter(x) || char.IsSymbol(x)))
            {
                helpers.showExclamation("Price only number!");
                validAll = false;
            }

            if (!validation.isAddressLenghtGreaterEqualThan6(textBox6.Text))
            {
                helpers.showExclamation("Descriptions minimum 6 character");
                validAll = false;
            }

            if (!isPhotoSelected)
            {
                helpers.showExclamation("Please choose the photo first!");
                validAll = false;
            }

            return validAll;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != null)
            {
                textBox4.Text = openFileDialog1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            add();
            loadParentDataGrid();
        }

        private void loadParentDataGrid()
        {
            ParentForm.refreshData("destination");
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
            var dest = data.TripDestinations.Find(dataId);
            textBox1.Text = dest.id_trip;
            textBox2.Text = dest.name;
            textBox3.Text = dest.address;
            textBox5.Text = dest.localPrice.ToString();
            textBox6.Text = dest.description;
            textBox4.Text = dest.Galleries.Where(x=>x.id_trip.Equals(dataId)).Select(x=>x.photo).FirstOrDefault();
            textBox8.Text = dest.internationalPrice.ToString();
            comboBox1.Text = dest.Region.name;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = textBox4.Text;
            isPhotoSelected = true;
        }
    }
}
