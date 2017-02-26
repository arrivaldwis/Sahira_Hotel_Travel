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

namespace Sahira_Hotel_Travel.User_Control
{
    public partial class pnMaster : UserControl
    {
        public sahira_hotel_travelEntities data = new sahira_hotel_travelEntities();
        public Validation validation = new Validation();
        public Helpers helpers = new Helpers();
        public frmMasterBase frmMaster = new frmMasterBase();
        public frmMasterBase ParentForm { get; set; }
        public string dataId;
        public string ID
        {
            set { dataId = value; }
        }
        
        public pnMaster()
        {
            InitializeComponent();
        }
    }
}
