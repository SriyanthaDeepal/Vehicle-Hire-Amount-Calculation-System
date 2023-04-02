using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_Drive_Calculation_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void frm1_serviceCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string service = frm1_serviceCmbBox.SelectedItem.ToString();

            if (service == "Add a New Vehicle")
            {
               Form2 f2 = new Form2();
                this.Hide();
                f2.Show();
            }

            else if(service == "Rent a Vehicle")
            {
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }

            else if (service == "Hire a Vehicle")
            {
                Form4 f4 = new Form4();
                this.Hide();
                f4.Show();
            }
        }

        private void frm_BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
