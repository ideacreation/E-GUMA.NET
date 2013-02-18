using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_GUMA.Example
{
    public partial class ActivateDepotVoucherForm : Form
    {
        public ActivateDepotVoucherForm()
        {
            InitializeComponent();
        }

        private void OnButton(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxCode.Text += ((Button) sender).Text;
        }
    }
}
