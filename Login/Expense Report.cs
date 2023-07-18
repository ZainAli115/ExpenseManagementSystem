using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using System.Data.SqlClient;
using LiveCharts.Wpf;

namespace Login
{
    public partial class Expense_Report : Form
    {
        DataSet ds;
        string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-NI8K4TL";

        public Expense_Report()
        {
            InitializeComponent();
        }
        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Expense_Report_Load(object sender, EventArgs e)
        {
            int loggedInUserId = 1;
            loadAndBind(loggedInUserId);
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                // Open the database connection
                connection.Open();

                // Create a SQL command to retrieve the data from the "expenses" table
                string sqlQuery = "SELECT Category, Ammount FROM expenses";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Create a SeriesCollection to hold the pie chart series
                    SeriesCollection pieSeries = new SeriesCollection();

                    // Create a SeriesCollection to hold the column chart series
                    SeriesCollection columnSeries = new SeriesCollection();

                    // Execute the SQL command and get the data reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Iterate over the records and create the pie and column chart series
                        while (reader.Read())
                        {
                            // Get the values from the current record
                            string category = reader.GetString(0);
                            int ammount = reader.GetInt32(1);

                            // Create a new PieSeries and add it to the pie series collection
                            pieSeries.Add(new PieSeries()
                            {
                                Title = category,
                                Values = new ChartValues<int> { ammount },
                                DataLabels = true,
                                LabelPoint = labelPoint
                            });

                            // Create a new ColumnSeries and add it to the column series collection
                            columnSeries.Add(new ColumnSeries()
                            {
                                Title = category,
                                Values = new ChartValues<int> { ammount }
                            });
                        }
                    }

                    // Set the series collections to the respective chart controls
                    pieChart1.Series = pieSeries;
                    cartesianChart1.Series = columnSeries;
                }
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
