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
            
            for (int i = 0; i < int.Parse(serversText.Text); i++)
            {
                Form form = new Form();
                form.Height = 250;
                form.Width = 450;

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

                //Setting Height & Width of table
                table.Height = 200;
                table.Width = 440;

                //Add to the "tables" List
                tables.Add(table);

                // Initialize the form.
                form.Controls.Add(table);
                form.AutoSize = true;
                form.Text = "Server " + (i+1).ToString();

                form.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
