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
    public partial class Home : Form
    {
        DataSet ds;
        string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-NI8K4TL";

        public Home()
        {
            InitializeComponent();
        }
        void loadAndBind(int userid)
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();

                string query = "SELECT bal FROM balance where uid=@userid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userid", userid);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Retrieve the data from the reader
                    decimal balance = Convert.ToDecimal(reader["bal"]);

                    // Update the label with the retrieved data
                    label7.Text = $"Your Balance: {balance}";
                }
                else
                {
                    // No data found, clear the label
                    label7.Text = "0.0000";
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private bool SaveToDatabase(int bal)
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();

                string query = "UPDATE balance SET bal =@bal where uid = 1";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@bal", bal);

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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelButton2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            Expenses ex = new Expenses();
            ex.Show();
            this.Hide();
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            Expenses ex = new Expenses();
            ex.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            int loggedInUserId = 1;
            loadAndBind(loggedInUserId);
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            Add_Expense ae = new Add_Expense();
            ae.Show();
            this.Hide();
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            Add_Expense ae = new Add_Expense();
            ae.Show();
            this.Hide();
        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            Expense_Report er = new Expense_Report();
            er.Show();
            this.Hide();
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            Expense_Report er = new Expense_Report();
            er.Show();
            this.Hide();
        }

        private void label8_MouseClick(object sender, MouseEventArgs e)
        {
            Bills b = new Bills();
            b.Show();
            this.Hide();
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            Bills b = new Bills();
            b.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bal = int.Parse(textBox1.Text);
            SaveToDatabase(bal);

        }
    }
}
