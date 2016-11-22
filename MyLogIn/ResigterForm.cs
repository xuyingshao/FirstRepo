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
    public partial class ResigterForm : Form
    {
        LoginModel _context;

        public ResigterForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _context = new LoginModel();
        }

        private void gobackbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            var rgusername = newusernametxt.Text;
            var rgpassword = pwentertxt.Text;
            var rgpasswordcf = pwconfirmtxt.Text;
            var rgstreet = streetlinetxt.Text;
            var rgaptnb = aptnumbertxt.Text;
            var rgcity = citytxt.Text;
            var rgstate = statetxt.Text;
            var rgzipcode = zipcodetxt.Text;
            var rgphone = phonetxt.Text;
            var rgemail = emailtxt.Text;
            List<string> emptystring = new List<string>();
            if (string.IsNullOrWhiteSpace(rgusername)) emptystring.Add("UserName");
            if (string.IsNullOrWhiteSpace(rgpassword)) emptystring.Add("Password");
            if (string.IsNullOrWhiteSpace(rgpasswordcf)) emptystring.Add("Confirm Password");
            if (string.IsNullOrWhiteSpace(rgstreet)) emptystring.Add("Street");
            if (string.IsNullOrWhiteSpace(rgcity)) emptystring.Add("City");
            if (string.IsNullOrWhiteSpace(rgstate)) emptystring.Add("State");
            if (string.IsNullOrWhiteSpace(rgzipcode)) emptystring.Add("Zip Code");
            if (string.IsNullOrWhiteSpace(rgphone)) emptystring.Add("Phone Number");
            if (string.IsNullOrWhiteSpace(rgemail)) emptystring.Add("Email");
            if (emptystring.Count != 0)
            {
                MessageBox.Show("The following fields cannot be empty: " + string.Join(",", emptystring.ToArray()));
            }
            else if (!rgpassword.Equals(rgpasswordcf))
            {
                MessageBox.Show("Password entered does not match the confirm password!");
            }
            else
            {
                var checkdupuser = _context.Users.Where(u => u.UserName == rgusername).FirstOrDefault();
                if (checkdupuser != null)
                {
                    MessageBox.Show("Username already exists! Please try another one.");
                }
                else
                {
                    DateTime now = DateTime.Today;
                    User usermodel = new User
                    {
                        UserName = rgusername,
                        CreateDate = now,
                        IsActive = true
                    };

                    _context.Users.Add(usermodel);
                    _context.SaveChanges();

                    var usercreated = _context.Users.Where(u => u.UserName == rgusername).FirstOrDefault();
                    if (usercreated != null)
                    {
                        Password pwmodel = new Password
                        {
                            UserId = usercreated.Id,
                            Password1 = rgpassword,
                            CreateDate = now,
                            IsActive = true
                        };
                        _context.Passwords.Add(pwmodel);

                        ContactInformation contactmodel = new ContactInformation
                        {
                            UserId = usercreated.Id,
                            Street = rgstreet,
                            UnitNumber = rgaptnb,
                            City = rgcity,
                            StateName = rgstate,
                            ZipCode = rgzipcode,
                            PhoneNumber = rgpassword,
                            EmailAddress = rgemail,
                            CreateDate = now,
                            IsActive = true
                        };
                        _context.ContactInformations.Add(contactmodel);

                        _context.SaveChanges();
                        var result = MessageBox.Show("Save successfully!", "Success",MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            ProfileForm pf = new ProfileForm();
                            pf.Show();
                            this.Close();
                        }
                    }
                }

            }
        }
    }
}
