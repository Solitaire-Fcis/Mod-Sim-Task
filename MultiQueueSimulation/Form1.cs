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
    public class ServerMeasures
    {
        public decimal ID, TotalIdleTime, TotalWorkingTime, TotalNumCustomers;
        public ServerMeasures()
        {
            ID = TotalIdleTime = TotalWorkingTime = TotalNumCustomers = 0;
        }
    }
    public partial class Form1 : Form
    { 
        // Global Variables Init. 
        string[] lines = File.ReadAllLines(@"TestCase1.txt");
        SimulationSystem SS = new SimulationSystem();
        List<ServerMeasures> SMList = new List<ServerMeasures>();
        decimal sumprop = 0, TotalQ = 0, CustomersWaited = 0;
        int minr = 1,index, customerCounter = 0, maxQ = 0, CustsInQ = 0, arrivalTime = 0, queue_time = 0, stoppingCounter = 0, ServerID = 1, minFinishTime = 1000, ServSum = 0;

        public Form1()
        {
            InitializeComponent();
            // Reading TestCases
            int ServerNumber = 1;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i]== "NumberOfServers")
                {
                    SS.NumberOfServers = int.Parse(lines[i + 1]);
                    serversText.Text = lines[i + 1];
                }
                else if (lines[i] == "StoppingNumber")
                {
                    SS.StoppingNumber = int.Parse(lines[i + 1]);
                    stoppingNum.Text = lines[i + 1];
                }
                else if(lines[i] == "StoppingCriteria")
                {
                    if (int.Parse(lines[i + 1]) == 1)
                        SS.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
                    else if (int.Parse(lines[i + 1]) == 2)
                        SS.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
                    criteriaText.Text = lines[i + 1];
                }
                else if(lines[i] == "SelectionMethod")
                {
                    if (int.Parse(lines[i + 1]) == 1)
                        SS.SelectionMethod = Enums.SelectionMethod.HighestPriority;
                    else if (int.Parse(lines[i + 1]) == 2)
                        SS.SelectionMethod = Enums.SelectionMethod.Random;
                    else if(int.Parse(lines[i + 1]) == 3)
                        SS.SelectionMethod = Enums.SelectionMethod.LeastUtilization;
                    methodText.Text = lines[i + 1];

                }
                else if(lines[i] == "InterarrivalDistribution")
                {
                    i++;
                    while (lines[i]!="")
                    {
                        TimeDistribution T = new TimeDistribution();
                        string[] num = lines[i].Split(',');
                        T.Time = int.Parse(num[0]);
                        T.Probability = decimal.Parse(num[1]);
                        sumprop+=decimal.Parse(num[1]);
                        T.CummProbability=sumprop;
                        T.MinRange = minr;
                        T.MaxRange = Convert.ToInt32((sumprop*100));
                        SS.InterarrivalDistribution.Add(T);
                        minr = T.MaxRange+1;
                        i++;
                    }
                    index = i;
                    sumprop = 0;
                    minr = 1;
                }
                else if (lines[i] == $"ServiceDistribution_Server{ServerNumber}")
                {
                    i++;
                    ServerMeasures SM = new ServerMeasures();
                    Server S = new Server();
                    while (i != lines.Length && lines[i] != "")
                    {
                        TimeDistribution T = new TimeDistribution();
                        string[] num = lines[i].Split(',');
                        T.Time = int.Parse(num[0]);
                        T.Probability = decimal.Parse(num[1]);
                        sumprop += decimal.Parse(num[1]);
                        T.CummProbability = sumprop;
                        T.MinRange = minr;
                        T.MaxRange = Convert.ToInt32((sumprop * 100));
                        S.TimeDistribution.Add(T);
                        minr = T.MaxRange + 1;
                        i++;
                    }
                    index = i;
                    sumprop = 0;
                    minr = 1;
                    S.ID = ServerNumber;
                    SM.ID = ServerNumber;
                    SMList.Add(SM);
                    SS.Servers.Add(S);
                    ServerNumber++;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Full Control On Simulation/Grid Creation/Performance Measurement/Testing Manager
        private void button1_Click(object sender, EventArgs e)
        {
            if (SS.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
                SimulateSystem(false);
            else if (SS.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime)
                SimulateSystem(true);
            CreateTable();
            PerformanceMeasures PM = PerformanceMeasures();
            SS.PerformanceMeasures = PM;
            string testingResult = TestingManager.Test(SS, Constants.FileNames.TestCase1);
            MessageBox.Show(testingResult);
        }

        private void button_Clicked(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Method For Simulation System Control
        public void SimulateSystem(Boolean stoppingCritireaFlag)
        {
            while (true)
            {
                SimulationCase SC = new SimulationCase();
                queue_time = 0;
                // Whether Stopping Critirea Is Customer Number Or Simulation Time To Break
                if (stoppingCritireaFlag && stoppingCounter >= SS.StoppingNumber)
                    break;
                else if (!stoppingCritireaFlag && customerCounter >= SS.StoppingNumber)
                    break;

                //Computing InterArrival Time and Arrival Time
                int arrival_rand = this.RandomNumber(1, 100), InterarrivalTime = 0;
                if (customerCounter == 0)
                    arrivalTime = 0;
                else
                {
                    foreach (var item in SS.InterarrivalDistribution)
                    {
                        if (arrival_rand >= item.MinRange && arrival_rand <= item.MaxRange)
                        {
                            InterarrivalTime = item.Time;
                            arrivalTime += InterarrivalTime;
                            break;
                        }
                    }
                }

                // Depending On Selection Method; Calling Whether Highest Priority Or Random
                if (SS.SelectionMethod == Enums.SelectionMethod.HighestPriority)
                    HighestPriority();
                else if (SS.SelectionMethod == Enums.SelectionMethod.Random)
                    RandomMethod();

                //Computing Service Time And Finish Time
                int service_rand = this.RandomNumber(1, 100);
                int serverTime = 0;
                foreach (var item in SS.Servers[ServerID].TimeDistribution)
                {
                    if (service_rand >= item.MinRange && service_rand <= item.MaxRange)
                    {
                        serverTime = item.Time;
                        SS.Servers[ServerID].FinishTime = arrivalTime + queue_time + serverTime;
                        break;
                    }
                }

                // Simulation Case Gathering
                SC.ArrivalTime = arrivalTime;
                SC.AssignedServer = SS.Servers[ServerID];
                SC.CustomerNumber = customerCounter + 1;
                SC.RandomInterArrival = arrival_rand;
                SC.InterArrival = InterarrivalTime;
                SC.RandomService = service_rand;
                SC.ServiceTime = serverTime;
                SC.TimeInQueue = queue_time;
                SC.EndTime = SS.Servers[ServerID].FinishTime;
                SC.StartTime = arrivalTime + queue_time;

                SS.SimulationTable.Add(SC);
                customerCounter++;
                if (stoppingCritireaFlag)
                    stoppingCounter = arrivalTime + queue_time + serverTime;
            }
        }

        // Highest Priority Algorithm
        public void HighestPriority()
        {
            bool serverFound = false;
            foreach (var server in SS.Servers)
            {
                //check if any server is an idle
                if (arrivalTime >= server.FinishTime)
                {
                    CustsInQ = 0;
                    serverFound = true;
                    ServerID = server.ID - 1;
                    break;
                }
            }
            if (!serverFound)
            {
                CustomersWaited++;
                foreach (var server in SS.Servers)
                    if (server.FinishTime <= minFinishTime)
                        minFinishTime = server.FinishTime;
                foreach (var server in SS.Servers)
                {
                    if (server.FinishTime == minFinishTime)
                    {
                        CustsInQ++;
                        TotalQ += queue_time = server.FinishTime - arrivalTime;
                        ServerID = server.ID - 1;
                        break;
                    }
                }
                minFinishTime = 1000;
            }
        }

        // Random Algorithm
        public void RandomMethod()
        {
            //check if any server is an idle
            List<int> ServersBusy = new List<int>();
            bool serverFound = false;
            while(true)
            {
                if (SS.Servers.Count == ServersBusy.Count)
                    break;
                int randServer = this.RandomNumber(0, SS.Servers.Count-1);
                if (arrivalTime >= SS.Servers[randServer].FinishTime)
                {
                    CustsInQ = 0;
                    serverFound = true;
                    ServerID = SS.Servers[randServer].ID - 1;
                    break;
                }
                else if(!ServersBusy.Contains(randServer))
                    ServersBusy.Add(randServer);
            }
            if (!serverFound)
            {
                CustomersWaited++;
                foreach (var server in SS.Servers)
                    if (server.FinishTime <= minFinishTime)
                        minFinishTime = server.FinishTime;
                foreach (var server in SS.Servers)
                {
                    if (server.FinishTime == minFinishTime)
                    {
                        CustsInQ++;
                        TotalQ += queue_time = server.FinishTime - arrivalTime;
                        ServerID = server.ID - 1;
                        break;
                    }
                }
                minFinishTime = 1000;
            }
        }

        // Performance Measurement
        public PerformanceMeasures PerformanceMeasures()
        {
            Dictionary<int, int> QConsecPerServer = new Dictionary<int, int>();
            int maxSimTime = int.MinValue, QCounter = 0, maxQ = int.MinValue, index = 0, tmpStartTime = int.MaxValue;
            // Performance Measurement: Total Number of Customers/Working Time/Simulation Time 
            foreach (var serv in SS.Servers)
            {
                maxSimTime = Math.Max(maxSimTime, serv.FinishTime);
                for (int i = 0; i < SS.SimulationTable.Count; i++)
                {
                    if (SS.SimulationTable[i].AssignedServer.ID == serv.ID)
                    {
                        SMList[serv.ID - 1].TotalNumCustomers += 1;
                        SMList[serv.ID - 1].TotalWorkingTime += SS.SimulationTable[i].ServiceTime;
                    }
                }
            }
            // Performance Measurement: Maximum Queue in Simulation
            for (int i = 0; i < SS.SimulationTable.Count; i++)
            {
                if (SS.SimulationTable[i].TimeInQueue != 0)
                {
                    if (QCounter == 0)
                    {
                        QCounter++;
                        index = i;
                        tmpStartTime = SS.SimulationTable[i].StartTime;
                    }
                    if (SS.SimulationTable[i].ArrivalTime < tmpStartTime)
                        QCounter++;
                    else
                    {
                        index++;
                        tmpStartTime = SS.SimulationTable[index].StartTime;
                    }
                }
                else
                    QCounter = 0;
                maxQ = Math.Max(maxQ, QCounter);
            }

            // Performance Measurement: Rest
            for (int i = 0; i < SS.NumberOfServers; i++)
            {
                if (SMList[i].TotalNumCustomers == 0)
                {
                    SS.Servers[i].AverageServiceTime = 0;
                    SS.Servers[i].IdleProbability = 1;
                    SS.Servers[i].Utilization = (SMList[i].TotalWorkingTime / SS.SimulationTable[customerCounter - 1].EndTime);
                }
                else
                {
                    SS.Servers[i].AverageServiceTime = (SMList[i].TotalWorkingTime / SMList[i].TotalNumCustomers);
                    SS.Servers[i].IdleProbability = (maxSimTime - SMList[i].TotalWorkingTime) / maxSimTime;
                    SS.Servers[i].Utilization = (SMList[i].TotalWorkingTime / maxSimTime);
                }
            }
            PerformanceMeasures PM = new PerformanceMeasures();
            PM.AverageWaitingTime = TotalQ / customerCounter;
            PM.WaitingProbability = CustomersWaited / customerCounter;
            PM.MaxQueueLength = --maxQ;
            if (maxQ == -1)
                PM.MaxQueueLength = 0;
            return PM;
        }

        // Grid View Creation And Fill
        public void CreateTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Customer No.");
            table.Columns.Add("Random Digits for Arrival");
            table.Columns.Add("Time between Arrivals");
            table.Columns.Add("Clock Time of Arrival");
            table.Columns.Add("Random Digits for Service");
            table.Columns.Add("Time Service Begins");
            table.Columns.Add("Service");
            table.Columns.Add("Time Service Ends");
            table.Columns.Add("Service Index");
            table.Columns.Add("Time in Queue");
            foreach (var Case in SS.SimulationTable)
            {
                if(Case.CustomerNumber == 1)
                    table.Rows.Add(Case.CustomerNumber, '-', '-', Case.ArrivalTime,
                        Case.RandomService, Case.StartTime, Case.ServiceTime, Case.EndTime, Case.AssignedServer.ID, Case.TimeInQueue);
                else
                    table.Rows.Add(Case.CustomerNumber, Case.RandomInterArrival, Case.InterArrival, Case.ArrivalTime,
                        Case.RandomService, Case.StartTime, Case.ServiceTime, Case.EndTime, Case.AssignedServer.ID, Case.TimeInQueue);
            }
            dataGridView1.DataSource = table;
        }

        // For Generating Random Numbers
        private readonly Random _random = new Random();
        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
