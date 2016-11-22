using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLogIn
{
    public partial class Form1 : Form
    {
        LoginModel _context;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _context = new LoginModel();

            // Call the Load method to get the data for the given DbSet 
            // from the database. 
            // The data is materialized as entities. The entities are managed by 
            // the DbContext instance. 
            //_context.Users.Load();
            //_context.Passwords.Load();
            //_context.ContactInformations.Load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResigterForm nextform = new ResigterForm();
            nextform.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inputusername = UserName.Text;
            var inputpassword = Password.Text;
            if (string.IsNullOrWhiteSpace(inputusername) || string.IsNullOrWhiteSpace(inputpassword))
            {
                MessageBox.Show("Username and Password cannot be empty!");
            }
            else
            {
                var testuser = _context.Users.Where(u => u.UserName == inputusername).FirstOrDefault();
                if (testuser == null)
                {
                    MessageBox.Show("Username does not exist!");
                }
                else
                {
                    var testpassword = _context.Passwords.Where(p => p.UserId == testuser.Id && p.Password1 == inputpassword).FirstOrDefault();
                    if (testpassword == null)
                    {
                        MessageBox.Show("Password not correct");
                    }
                    else
                    {
                        ProfileForm profileform = new ProfileForm();
                        profileform.Show();
                        this.Hide();
                    }
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this._context.Dispose();
        }
    }
}
