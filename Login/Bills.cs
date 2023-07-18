using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login
{
    public partial class Bills : Form
    {
        DataSet ds;
        string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-NI8K4TL";

        public Bills()
        {
            InitializeComponent();
        }

        private void deduct()
        {
            int waterBill = int.Parse(textBox1.Text);
            int gasBill = int.Parse(textBox2.Text);
            int electricityBill = int.Parse(textBox3.Text);
            int internetBill = int.Parse(textBox4.Text);
            int schoolFee = int.Parse(textBox5.Text);

            int total = waterBill + gasBill + electricityBill + internetBill + schoolFee;

            try
            {
                using (SqlConnection connection = new SqlConnection(strCon))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SQL command to insert the data into the "bills" table
                    string sqlQuery = "Update Balance set bal=bal-@total";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Add parameters to the SQL command
                        command.Parameters.AddWithValue("@total", total);


                        // Execute the SQL command
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the payment: " + ex.Message);
            }
        }
        

        

        private void Bills_Load(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            deduct();
            int waterBill = int.Parse(textBox1.Text);
            int gasBill = int.Parse(textBox2.Text);
            int electricityBill = int.Parse(textBox3.Text);
            int internetBill = int.Parse(textBox4.Text);
            int schoolFee = int.Parse(textBox5.Text);

            try
            {
                using (SqlConnection connection = new SqlConnection(strCon))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SQL command to insert the data into the "bills" table
                    string sqlQuery = "INSERT INTO bills (Water, Gas, Elec, Interne,Fee) " +
                                      "VALUES (@waterBill, @gasBill, @electricityBill, @internetBill, @schoolFee)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Add parameters to the SQL command
                        command.Parameters.AddWithValue("@waterBill", waterBill);
                        command.Parameters.AddWithValue("@gasBill", gasBill);
                        command.Parameters.AddWithValue("@electricityBill", electricityBill);
                        command.Parameters.AddWithValue("@internetBill", internetBill);
                        command.Parameters.AddWithValue("@schoolFee", schoolFee);

                        // Execute the SQL command
                        command.ExecuteNonQuery();

                        MessageBox.Show("Payment recorded successfully!");
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the payment: " + ex.Message);
            }
        }

        private void label10_MouseClick(object sender, MouseEventArgs e)
        {
            
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
            Expenses em = new Expenses();
            em.Show();
            this.Hide();
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            Expenses em = new Expenses();
            em.Show();
            this.Hide();
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            Add_Expense ad = new Add_Expense();
            ad.Show();
            this.Hide();
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            Add_Expense ad = new Add_Expense();
            ad.Show();
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
    }
}
