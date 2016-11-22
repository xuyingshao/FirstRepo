using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLogIn
{
    public partial class ProfileForm : Form
    {
        private Form1 form = null;
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form = new Form1();
            form.Show();
            this.Close();
        }
    }
}
