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
using Sahira_Hotel_Travel.View;
using System.Data.SqlClient;

namespace Sahira_Hotel_Travel.User_Control
{
    public partial class pnCustomer : pnMaster, IViewMethod
    {
        public pnCustomer()
        {
            InitializeComponent();
            loadData();
        }

        public void add()
        {
            if (validateAll())
            {
                Customer user = new Customer();
                user.id_customer = textBox1.Text;
                user.name = textBox2.Text;
                user.address = textBox3.Text;
                user.email = textBox4.Text;
                user.phone = textBox5.Text;
                user.dob = dateTimePicker1.Value;
                user.nationality = radioButton1.Checked == true ? "WNI" : "Non-WNI";
                user.id_customerType = getTypeId(comboBox1.Text);

                try
                {
                    data.Customers.Add(user);
                    data.SaveChanges();
                    helpers.showInfo("New customer has been added!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        helpers.showError("Sorry, can't add duplicate customer data!");
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
                var cust = data.Customers.Find(id);
                cust.name = textBox2.Text;
                cust.address = textBox3.Text;
                cust.email = textBox4.Text;
                cust.phone = textBox5.Text;
                cust.dob = dateTimePicker1.Value;
                cust.nationality = radioButton1.Checked == true ? "WNI" : "Non-WNI";
                cust.id_customerType = getTypeId(comboBox1.Text);

                try
                {
                    data.SaveChanges();
                    helpers.showInfo("New customer has been updated!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        helpers.showError("Sorry, can't add duplicate customer data!");
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
            var Customer = data.Customers.Find(id);

            try
            {
                data.Customers.Remove(Customer);
                data.SaveChanges();
                helpers.showInfo("Customer has been removed!");
            }
            catch (Exception ex)
            {
                helpers.showError(ex.Message);
            }
        }

        public void populateForm()
        {
            var cust = data.Customers.Find(dataId);
            textBox1.Text = cust.id_customer;
            textBox2.Text = cust.name;
            textBox3.Text = cust.address;
            textBox4.Text = cust.email;
            textBox5.Text = cust.phone.ToString();
            comboBox1.Text = getTypeName(cust.id_customerType);
            dateTimePicker1.Value = cust.dob;
            if (cust.nationality == "WNI") radioButton1.Checked = true; 
            else radioButton2.Checked = true;
        }

        private bool validateAll()
        {
            bool validAll = true;
            if (textBox1.Text.Equals(""))
            {
                helpers.showExclamation("Please complete the form first!");
                validAll = false;
            }

            if (!validation.isNameLengthGreaterEqualThan3(textBox2.Text))
            {
                helpers.showExclamation("Name minimum 3 character");
                validAll = false;
            }

            if (!validation.isEmailValid(textBox4.Text))
            {
                helpers.showExclamation("Email not valid!");
                validAll = false;
            }

            if (!validation.isAddressLenghtGreaterEqualThan6(textBox3.Text))
            {
                helpers.showExclamation("Address minimum 6 character");
                validAll = false;
            }

            if (!validation.isPhoneValid(textBox5.Text))
            {
                helpers.showExclamation("Phone only contain number");
                validAll = false;
            }
            return validAll;
        }

        public bool isFieldStillEmpty()
        {
            bool yes = false;
            foreach (var text in this.Controls.OfType<TextBox>().Where(x => x.Text == "")) yes = true;
            return yes;
        }

        public void loadData()
        {
            textBox1.Text = validation.generateCustomerCode("M");
            foreach (var custType in this.data.CustomerTypes)
            {
                comboBox1.Items.Add(custType.type);
            }
            comboBox1.SelectedIndex = 0;
        }

        private int getTypeId(string typeName)
        {
            int typeId = 0;
            typeId = data.CustomerTypes.Where(x => x.type.Equals(typeName)).Select(x => x.id_customerType).FirstOrDefault();
            return typeId;
        }

        private string getTypeName(int typeId)
        {
            string typeName = "";
            typeName = data.CustomerTypes.Find(typeId).type;
            return typeName;
        }

        private void loadParentDataGrid()
        {
            ParentForm.refreshData("customer");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            add();
            loadParentDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            edit(dataId.ToString());
            loadParentDataGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delete(dataId.ToString());
            loadParentDataGrid();
        }
    }
}
