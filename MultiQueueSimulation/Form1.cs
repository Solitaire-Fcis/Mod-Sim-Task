using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {

        List<DataGridView> tables = new List<DataGridView>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            
            const int x = 0;

            int grid_y = 20;
            int label_y = 5;


            for (int i = 0; i < int.Parse(serversText.Text); i++)
            {
                Label label = new Label();
                DataGridView table = new DataGridView();

                table.ColumnCount = 4;
                table.Columns[0].HeaderText = "Service Time";
                table.Columns[1].HeaderText = "Probability";
                table.Columns[2].HeaderText = "Cumulative Probability";
                table.Columns[3].HeaderText = "Range";

                table.Columns[0].Name = "serviceTime";
                table.Columns[1].Name = "probability";
                table.Columns[2].Name = "cumulativeProbability";
                table.Columns[3].Name = "range";

                label.Text = "Server " + (i + 1).ToString();

                //Setting Height & Width of table
                table.Height = 300;
                table.Width = 443;


                //Add to the "tables" List
                tables.Add(table);

                if (i > 0)
                {
                    grid_y += table.Size.Height + label.Size.Height;
                    label_y += table.Size.Height + label.Size.Height;
                }

                table.Location = new Point(x, grid_y);
                label.Location = new Point(0, label_y);

                // Initialize the form.
                form.Controls.Add(table);
                form.Controls.Add(label);
            }

            Button button = new Button();

            button.Text = "Simulate";
            
            button.Width = 85;
            button.Height = 60;

            form.Width = tables[0].Width + 37;
            form.Height = tables[0].Height + 50;

            button.Location = new Point(tables[0].Width / 2, grid_y + 300);

            button.Click += new EventHandler(this.button_Clicked);

            form.Controls.Add(button);

            //form.AutoSize = true;
            form.Text = "Servers";
            form.AutoScroll = true;

            form.Show();
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            //Button triggeredButton = (Button)sender;
            Form form = new Form();

            DataGridView table = new DataGridView();

            table.ColumnCount = 10;

            table.Columns[0].Name = "Customer No.";
            table.Columns[1].Name = "Random Digits for Arrival";
            table.Columns[2].Name = "Time between Arrivals";
            table.Columns[3].Name = "Clock Time of Arrival";
            table.Columns[4].Name = "Random Digits for Service";
            table.Columns[5].Name = "Time Service Begins";
            table.Columns[6].Name = "Service";
            table.Columns[7].Name = "Time Service Ends";
            table.Columns[8].Name = "Service Index";
            table.Columns[9].Name = "Time in Queue";

            for(int i=1; i<=int.Parse(stoppingNum.Text); i++)
            {
                table.Rows.Add(i, "", "", "", "", "", "", "", "", "");
            }

            table.Width = 1065;
            table.Height = 700;

            form.Controls.Add(table);

            form.Text = "Simulation";
            form.AutoSize = true;

            form.Show();
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
