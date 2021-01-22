using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestStudentRegistration
{
    public partial class LogoutBox : Form
    {
        public LogoutBox()
        {
            InitializeComponent();
        }

        private void button_WOC44_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button_WOC45_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Close();
            frmAdmin obj = (frmAdmin)Application.OpenForms["frmAdmin"];
            obj.Hide();
           
        }
    }
}
