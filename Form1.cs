using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDEAS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewAllRecords();
        }

        static void ViewAllRecords()
        {
            string filePath = "test.csv";
            try
            {
                List<string> records = File.ReadAllLines(filePath).ToList();
                string allrecords = "\n";
                foreach (string record in records)
                {
                    allrecords += record + "\n";
                }
                MessageBox.Show(allrecords,"Student Details",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing records: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewAttendance();
        }
        static void ViewAttendance()
        {
            string filePath2 = "today.csv";
            try
            {
                List<string> records = File.ReadAllLines(filePath2).ToList();
                string allrecords = "\n";
                foreach (string record in records)
                {
                    allrecords += record + "\n";
                }
                MessageBox.Show(allrecords, "Attandence Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing records: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            this.Hide();
            f6.Show();
        }
    }
}
