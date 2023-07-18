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
    public partial class Expenses : Form
    {
        DataSet ds;
        string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-NI8K4TL";
        

        public Expenses()
        {
            InitializeComponent();
        }
        void loadAndBind(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();

                string query = "SELECT item_id,item_name, Ammount, ExpenseDate, Category FROM expenses";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                // Clear existing rows in the dataGridView1
                dataGridView1.Rows.Clear();

                while (reader.Read())
                {
                    // Retrieve the data from the reader
                    int item_id = Convert.ToInt32(reader["item_id"]);
                    string itemName = reader["item_name"].ToString();
                    int ammount = Convert.ToInt32(reader["Ammount"]);
                    DateTime expenseDate = Convert.ToDateTime(reader["ExpenseDate"]);
                    string category = reader["Category"].ToString();

                    // Add a new row to the dataGridView1 with the retrieved data
                    dataGridView1.Rows.Add(item_id,itemName, ammount, expenseDate, category);
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        void filter(int userId, string cat)
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();

                string query = "SELECT item_id, item_name, Ammount, ExpenseDate, Category FROM expenses WHERE Category = @cat";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@cat", cat); // Add the category parameter

                SqlDataReader reader = cmd.ExecuteReader();

                // Clear existing rows in the dataGridView1
                dataGridView1.Rows.Clear();

                while (reader.Read())
                {
                    // Retrieve the data from the reader
                    int item_id = Convert.ToInt32(reader["item_id"]);
                    string itemName = reader["item_name"].ToString();
                    int ammount = Convert.ToInt32(reader["Ammount"]);
                    DateTime expenseDate = Convert.ToDateTime(reader["ExpenseDate"]);
                    string category = reader["Category"].ToString();

                    // Add a new row to the dataGridView1 with the retrieved data
                    dataGridView1.Rows.Add(item_id, itemName, ammount, expenseDate, category);
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void DeleteItem(int itemId)
{
    try
    {
        SqlConnection con = new SqlConnection(strCon);
        con.Open();

        string query = "DELETE FROM expenses WHERE item_id = @itemId";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@itemId", itemId);

        cmd.ExecuteNonQuery();

        con.Close();
    }
    catch (Exception ee)
    {
        MessageBox.Show(ee.Message);
    }
}




        private void Expenses_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns.Count - 1 && e.RowIndex >= 0)
            {
                // Get the item_id from the clicked row
                int itemId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Itemid"].Value);

                // Show a confirmation dialog before deleting the item
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Delete the item from the database
                    DeleteItem(itemId);

                    // Remove the row from the dataGridView1
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int loggedInUserId = 1;
            loadAndBind(loggedInUserId);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int loggedInUserId = 1;
            string cat = comboBox1.SelectedItem.ToString();
            filter(loggedInUserId,cat);
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void panel3_MouseClicked(object sender, MouseEventArgs e)
        {

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            Add_Expense ae = new Add_Expense();
            ae.Show();
            this.Hide();
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            Add_Expense ae = new Add_Expense();
            ae.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
