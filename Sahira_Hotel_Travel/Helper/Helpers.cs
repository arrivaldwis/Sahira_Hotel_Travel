using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahira_Hotel_Travel.Helper
{
    public class Helpers
    {
        public void showError(string pesan)
        {
            MessageBox.Show(pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void showInfo(string pesan)
        {
            MessageBox.Show(pesan, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void showExclamation(string pesan)
        {
            MessageBox.Show(pesan, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
