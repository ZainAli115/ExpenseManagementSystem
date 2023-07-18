using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class FrmLogin : Form
    {
        DataSet ds;
        string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-NI8K4TL";

        public FrmLogin()
        {
            InitializeComponent();
        }

        private bool ValidateLoginInput(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Add any additional validation logic for username and password here

            return true;
        }

        private bool CheckCredentials(string username, string password)
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE uname = @username AND upassword = @password";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = (int)cmd.ExecuteScalar();

                con.Close();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            string username = txtUsername.Text;
            string password = txtpassword.Text;

            // Validate input
            if (ValidateLoginInput(username, password))
            {
                // Check credentials against the database
                if (CheckCredentials(username, password))
                {
                    MessageBox.Show("Login successful!");
                    h.Show();
                    this.Hide();
                    // Perform actions after successful login, such as opening a new form or navigating to a different page
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid username and password.");
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';
                
            }
            else
            {
                txtpassword.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtpassword.Clear();
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmRegister fr = new frmRegister();
            fr.Show();
            this.Hide();
        }
        
    }
}
