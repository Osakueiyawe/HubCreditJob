using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryAdvanceNew
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ProcessReversal collection = new ProcessReversal();
            int delayATM = Convert.ToInt16 (ConfigurationManager.AppSettings["DelayATM"]);

            try
            {
                //List<Task> tasks = new List<Task>();
                //tasks.Add(Task.Factory.StartNew(() => collection.RetrieveCBNReference()));
                //tasks.Add(Task.Factory.StartNew(() => collection.RetrieveCBNReferenceForHubAdvance()));

                //tasks.Add(Task.Factory.StartNew(() => collection.ProcessExpiry()));
                //if (delayATM == 1)
                //{
                //    tasks.Add(Task.Factory.StartNew(() => collection.ProcessExpiryATM()));

                //}
                //Task.WaitAll(tasks.ToArray());

                collection.RetrieveCBNReferenceForHubAdvance();
                collection.ProcessSMEHubAdvance();
                //collection.StopStandingInstruction();

                 timer1.Enabled = true;
         
         
            }
            catch (Exception ex)
            {
                ErrHandler.LogError(string.Format("Error on form: " + ex.Message + "Stack trace: => " + ex.StackTrace));
                if (ex.InnerException != null)
                {
                    ErrHandler.LogError("Inner Exception: => " + ex.InnerException.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            //check if the machine is authorized to run the payment engine.
            // Get the hostname 
            string myHost = Dns.GetHostName();
            // Get the IP from the host name

            //string myIP = Dns.GetHostEntry(myHost).AddressList[0].ToString(); //Live
            string myIP = Dns.GetHostByName(myHost).AddressList[0].ToString();  //Test

            string authIP = ConfigurationManager.AppSettings["MachineIP"].ToString().Trim();
            if (myIP.Trim().CompareTo(authIP.Trim()) == 0)
            {
                //check if process is already running
                if (Process.GetProcessesByName("SalaryAdvanceNew").Length > 1)
                {
                    MessageBox.Show("Another instance of SalaryAdvanceJob is already running.\n\nMultiple instances not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                ////Live
                //numericUpDown1.Value = 2;
                //tTimer.Interval = (60 * 1000) * int.Parse(numericUpDown1.Value.ToString());

                //Test
                //numericUpDown1.Value = 1;
                //timer1.Interval = (1 * 1000) * int.Parse(numericUpDown1.Value.ToString());

                timer1.Enabled = true;
                //mStart.Enabled = false;
                //mEnd.Enabled = true;
            }
            else
            {
                //MessageBox.Show("Sorry, the SalaryAdvanceJob  Engine is not allowed to run on this machine.\n\nUnauthorized installation not allowed. Please uninstall the application from this machine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
