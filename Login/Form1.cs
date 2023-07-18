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
    public partial class frmRegister : Form
    {
        DataSet ds;
        string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-NI8K4TL";
        public frmRegister()
        {
            InitializeComponent();
        }
        private bool ValidateRegistrationInput(string username, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                return false;
            }

            if (password != confirmPassword)
            {
                return false;
            }

            // Add any additional validation logic for username and password here

            return true;
        }

        private bool SaveUserToDatabase(string username, string password)
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();

                string query = "INSERT INTO Users (uname, upassword) VALUES (@username, @password)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtpassword.Text;
            string compassword = txtComPassword.Text;

            // Validate input
            if (ValidateRegistrationInput(username, password,compassword))
            {
                // Save data to the database
                if (SaveUserToDatabase(username, password))
                {
                    MessageBox.Show("Registration successful!");
                }
                else
                {
                    MessageBox.Show("Failed to save user data.");
                }
                
            }
          
            else
            {
                MessageBox.Show("Please enter a valid username and password.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtpassword.Clear();
            txtComPassword.Clear();
            txtUsername.Focus();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FrmLogin fl = new FrmLogin();
            fl.Show();
            this.Hide();
        }

        private void txtComPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
