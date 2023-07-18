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
    public partial class Add_Expense : Form
    {
        DataSet ds;
        string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-NI8K4TL";
        public Add_Expense()
        {
            InitializeComponent();
        }

        private void Add_Expense_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string itemName = textBox1.Text;
            int amount = Convert.ToInt32(textBox2.Text);
            string category = txtCategory.Text;
            DateTime expenseDate = dateTimePicker1.Value;

            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();

                string query = "INSERT INTO expenses (item_name, Ammount, ExpenseDate, Category) VALUES (@itemName, @amount, @expenseDate, @category)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@expenseDate", expenseDate);
                cmd.Parameters.AddWithValue("@category", category);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Expense data saved successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to save expense data.");
                }

                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
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
    }
}
