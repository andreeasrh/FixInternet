using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace FixInternet
{
    public partial class Form1 : Form
    {
        public  bool btn1c = false;

        public void cmd(string command)
        {
             string currentstatus;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            Process myprocess = new Process();
            try
            {
                startInfo.FileName = "cmd"; //
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false; //'required to redirect
                startInfo.CreateNoWindow = true; // '<---- creates no window, obviously
                myprocess.StartInfo = startInfo; //
                myprocess.Start(); //
                System.IO.StreamReader SR;
                System.IO.StreamWriter SW;
                SR = myprocess.StandardOutput;
                SW = myprocess.StandardInput;
                SW.WriteLine(command); // 'the command you wish to run.....
                SW.WriteLine("exit"); // 'exits command prompt window
                currentstatus = SR.ReadToEnd();
                SW.Close();
                SR.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error");
            }

        }


        public Form1()
        {
            InitializeComponent();
        }

        public void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                
                cmd("netsh interface set interface \u0022Wi-Fi\u0022 DISABLED");
                cmd("netsh interface set interface \u0022Ethernet\u0022 DISABLED");
                MessageBox.Show("Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                
            }
        }

        public void progressBar1_Click(object sender, EventArgs e)
        {
         
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                cmd("netsh interface set interface \u0022Wi-Fi\u0022 ENABLED");
                cmd("netsh interface set interface \u0022Ethernet\u0022 ENABLED");
                MessageBox.Show("Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                cmd("netsh winsock reset");
                cmd("netsh int ip reset");
                
                MessageBox.Show("Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                cmd("ipconfig /release");
                
                MessageBox.Show("Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd("ipconfig /flushdns");
                
                MessageBox.Show("Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Atentie! Computerul se va restarta!Sunteti de acord?", "RESTART",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);


            if (dr == DialogResult.Yes)
            { cmd("shutdown /r"); }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tools for InternetFix. Press AutoFix for autofix the Internet connection.", "HELP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                cmd("ipconfig /renew");
                
                
                MessageBox.Show("Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            

            
            DialogResult dr = MessageBox.Show("AutoFIX Process will start. Are you sure?", "AutoFix", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dr == DialogResult.Yes)
            {


                try
                {
                    progressBar1.PerformStep();

                    cmd("netsh interface set interface \u0022Wi-Fi\u0022 DISABLED");
                    Thread.Sleep(1000);
                    cmd("netsh interface set interface \u0022Ethernet\u0022 DISABLED");
                    MessageBox.Show("1 Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                }

                Thread.Sleep(600);

                try
                {
                    progressBar1.PerformStep();
                    cmd("netsh interface set interface \u0022Wi-Fi\u0022 DISABLED");
                    Thread.Sleep(1000);
                    cmd("netsh interface set interface \u0022Ethernet\u0022 DISABLED");
                    MessageBox.Show("2 Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    
                }

                Thread.Sleep(600);

                try
                {
                    progressBar1.PerformStep();
                    cmd("netsh winsock reset");
                    Thread.Sleep(1000);
                    cmd("netsh int ip reset");

                    MessageBox.Show("3 Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                }

                Thread.Sleep(600);

                try
                {
                    progressBar1.PerformStep();
                    cmd("ipconfig /release");
                    Thread.Sleep(1000);
                    MessageBox.Show("4 Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                }
                Thread.Sleep(600);


                try
                {
                    progressBar1.PerformStep();
                    cmd("ipconfig /flushdns");
                    Thread.Sleep(1000);
                    MessageBox.Show("5 Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                }

                Thread.Sleep(600);


                try
                {
                    progressBar1.PerformStep();
                    cmd("ipconfig /renew");


                    MessageBox.Show("6 Succesfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                }

                Thread.Sleep(600);


                progressBar1.PerformStep();


                Thread.Sleep(1000);


                cmd("shutdown /r"); 



            }
        }
    }
}
