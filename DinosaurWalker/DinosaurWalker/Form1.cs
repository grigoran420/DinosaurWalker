using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DinosaurWalker.Scripts;
using System.Runtime.InteropServices;


namespace DinosaurWalker
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int showWindowCommand);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
            if (checkBox1.Checked) { checkBox1.BackColor = Color.LightGreen; }
            else{
                checkBox1.BackColor = Color.Red;}

            if (listBox1.SelectedItem == null)
            {
                listBox1.SelectedIndex = 0;
            }

            if (SelectProcess.SelectedItem == null)
            {
                SelectProcess.SelectedItem = "chrome";
            }

            timer1.Enabled = !timer1.Enabled;
            timer2.Enabled = !timer2.Enabled;
            timer3.Enabled = !timer3.Enabled;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                StartWork start = new StartWork(
                    Int32.Parse(textBox1.Text),
                    label3,
                    Int32.Parse(textBox2.Text),
                    label4,
                    listBox1.SelectedItem.ToString(),
                    panel1,
                    SelectProcess.SelectedItem.ToString(),
                    label10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses(); 
            foreach (System.Diagnostics.Process instance in processes)
            {
                SelectProcess.Items.Add(instance.ProcessName);
            }
            SelectProcess.Sorted = true;
        }

        private void стратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectProcess.SelectedItem == null)
            {
                SelectProcess.SelectedItem = "chrome";
            }

            ///<summary>направляет фокус на окно, разрешает ввод в него с клавиатуры, меняет местоположение</summary>

            Process[] procs = Process.GetProcessesByName(SelectProcess.SelectedItem.ToString());
            foreach (Process p in procs)
            {
                ShowWindow(p.MainWindowHandle, 1);
                SetForegroundWindow(p.MainWindowHandle);
                SetWindowPos(p.MainWindowHandle, 0, 0, 0, 1920, 500, 0x0040);
            }

            checkBox1.Checked = true;
            if (checkBox1.Checked) { checkBox1.BackColor = Color.LightGreen; }
            else
            {
                checkBox1.BackColor = Color.Red;
            }

            if (listBox1.SelectedItem == null)
            {
                listBox1.SelectedIndex = 0;
            }

            

            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            if (checkBox1.Checked) { checkBox1.BackColor = Color.LightGreen; }
            else
            {
                checkBox1.BackColor = Color.Red;
            }

            if (listBox1.SelectedItem == null)
            {
                listBox1.SelectedIndex = 0;
            }

            if (SelectProcess.SelectedItem == null)
            {
                SelectProcess.SelectedItem = "chrome";
            }

            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            StartWork start = new StartWork(
                    Int32.Parse(textBox1.Text),
                    label3,
                    Int32.Parse(textBox2.Text),
                    label4,
                    listBox1.SelectedItem.ToString(),
                    panel1,
                    SelectProcess.SelectedItem.ToString(),
                    label10);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            StartWork start = new StartWork(
                    Int32.Parse(textBox1.Text),
                    label3,
                    Int32.Parse(textBox2.Text),
                    label4,
                    listBox1.SelectedItem.ToString(),
                    panel1,
                    SelectProcess.SelectedItem.ToString(),
                    label10);
        }
    }
}
