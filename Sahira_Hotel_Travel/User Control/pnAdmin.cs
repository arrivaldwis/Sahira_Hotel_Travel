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
    public partial class pnAdmin : pnMaster, IViewMethod
    {
        public pnAdmin()
        {
            InitializeComponent();
            loadData();
        }

        public void add()
        {
            if (validateAll())
            {
                User user = new User();
                user.username = textBox1.Text;
                user.password = textBox2.Text;
                user.name = textBox4.Text;
                user.id_userType = getTypeId(comboBox1.Text);

                try
                {
                    data.Users.Add(user);
                    data.SaveChanges();
                    helpers.showInfo("New user has been added!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        helpers.showError("Sorry, can't add duplicate user data!");
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
                var user = data.Users.Find(int.Parse(id));
                user.password = textBox2.Text;
                user.name = textBox4.Text;
                user.id_userType = getTypeId(comboBox1.Text);

                try
                {
                    data.SaveChanges();
                    helpers.showInfo("user has been updated!");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        helpers.showError("Sorry, can't add duplicate user data!");
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
            var User = data.Users.Find(int.Parse(id));

            try
            {
                data.Users.Remove(User);
                data.SaveChanges();
                helpers.showInfo("Data has been removed!");
            }
            catch (Exception ex)
            {
                helpers.showError(ex.Message);
            }
        }

        private bool validateAll()
        {
            bool validAll = true;
            if (textBox1.Text.Equals(""))
            {
                helpers.showExclamation("Please complete the form first!");
                validAll = false;
            }

            if (!validation.isPasswordLenghtGreaterEqualThan6(textBox2.Text))
            {
                helpers.showExclamation("Password minimum 6 character");
                validAll = false;
            }

            if (!validation.isNameLengthGreaterEqualThan3(textBox4.Text))
            {
                helpers.showExclamation("Name minimum 3 character");
                validAll = false;
            }

            if (!validation.isValidPassword(textBox2.Text))
            {
                helpers.showExclamation("Password should be contain number and letter");
                validAll = false;
            }

            if (!validation.isPasswordMatch(textBox2.Text, textBox3.Text))
            {
                helpers.showExclamation("Password not match!");
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
            foreach (var userType in this.data.UserTypes)
            {
                comboBox1.Items.Add(userType.name);
            }
            comboBox1.SelectedIndex = 0;
        }

        public void populateForm()
        {
            var user = data.Users.Find(int.Parse(dataId));
            textBox1.Text = user.username;
            textBox2.Text = user.password;
            textBox3.Text = user.password;
            textBox4.Text = user.name;
            comboBox1.Text = getTypeName(user.id_userType);
        }

        private int getTypeId(string typeName)
        {
            int typeId = 0;
            typeId = data.UserTypes.Where(x => x.name.Equals(typeName)).Select(x => x.id_userType).FirstOrDefault();
            return typeId;
        }

        private string getTypeName(int typeId)
        {
            string typeName = "";
            typeName = data.UserTypes.Find(typeId).name;
            return typeName;
        }

        private void loadParentDataGrid()
        {
            ParentForm.refreshData("admin");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add();
            loadParentDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
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
