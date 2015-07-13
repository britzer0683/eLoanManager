using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLoan.BL;

namespace eLoanSystem
{
    public partial class eLogin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public eLogin()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        private void eLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.ConnectionString = "Server=vm-sqlsvr;Database=MEISIN;Uid=sa;Pwd=nidaros;";

            UserManager oManager = new UserManager();
            UserUnit oUnit = new UserUnit();

            oUnit.UserID = txtUID.Text;
            oUnit.UserPassword = txtPassword.Text;

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            bool isAuthenticated = oManager.Authenticate(oUnit);

            if (isAuthenticated)
            {
                eLoanMainMenu oForm = new eLoanMainMenu();
                oForm.ConnectionString = this.ConnectionString;
                oForm.ActiveUserID = txtUID.Text.ToUpper();
                this.Visible = false;
                oForm.Show();
            }
            else
            {
                MessageBox.Show("User name and password is invalid!!! Please try again!!!", "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
    }
}
