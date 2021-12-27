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
using System.IO;

namespace MultiQueueSimulation
{
    public partial class Form2 : Form
    {
        SimulationSystem SS = new SimulationSystem();
        public Form2(SimulationSystem SS)
        {
            InitializeComponent();
            this.SS = SS;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            chart1.Series["Busy Time"].Points.Clear();;
            int ServerID = int.Parse(comboBox1.SelectedItem.ToString());
            int time = SS.Servers[ServerID - 1].FinishTime;
            for (int i = 0; i < time; i++)
                for (int j = 0; j < SS.SimulationTable.Count; j++)
                    if (SS.SimulationTable[j].AssignedServer.ID == ServerID)
                        for (int r = SS.SimulationTable[j].StartTime; r < SS.SimulationTable[j].EndTime; r++)
                            chart1.Series["Busy Time"].Points.AddXY(r, 1);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < SS.NumberOfServers; i++)
                comboBox1.Items.Add(i + 1);
        }
    }
}
