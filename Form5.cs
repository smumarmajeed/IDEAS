using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDEAS
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public int Counter = 1;
        public string[] attandance = new string[File.ReadAllLines("test.csv").Length - 1];

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("test.csv");
            if(Counter == lines.Length - 1)
            {
                label1.Text = "Attendance Complete";
                attandance[Counter - 1] = textBox1.Text;
                textBox1.Enabled = false;
                textBox1.Text = "";
                CreateAttendance(attandance);
            }
            else
            {
                attandance[Counter - 1] = textBox1.Text;
                Counter++;
                label1.Text = lines[Counter];
                textBox1.Text = "";
                
            }
            

        }


        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Cre_Click(object sender, EventArgs e)
        {

        }

        static void CreateAttendance(string[] attandance)
        {
            try
            {
                // Read lines from CSV file
                string[] lines = File.ReadAllLines("test.csv");
                string updatedData = "";

                // Update data line by line based on user input
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == 0)
                    {
                        updatedData = lines[i] + ",attendence";

                    }
                    else
                    {
                        updatedData = lines[i] + "," + attandance[i-1];
                    }


                    // Update the data in the array
                    lines[i] = updatedData;
                }

                // Write the updated data back to the CSV file
                File.WriteAllLines("today.csv", lines);

                MessageBox.Show("Attandence updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating CSV file: " + ex.Message);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("test.csv");
            label1.Text = lines[Counter];
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
