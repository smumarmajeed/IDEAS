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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRecord(textBox1.Text);
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        static void AddRecord(string studentInfo)
        {
            string filePath = "test.csv";
            string record = studentInfo;

            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(record);
                    MessageBox.Show("Record added successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding record: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
