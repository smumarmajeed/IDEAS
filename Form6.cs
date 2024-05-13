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
using System.Windows.Forms.DataVisualization.Charting;

namespace IDEAS
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string csvFilePath = "today.csv";
            int male = 0;
            int female = 0;
            int absent = 0;
            int present = 0;

            string[] lines = File.ReadAllLines(csvFilePath);

            // Get the number of columns
            int numColumns = lines[0].Split(',').Length;

            // Initialize arrays for each column
            string[] column1 = new string[lines.Length];
            string[] column2 = new string[lines.Length];
            // Add more arrays as per the number of columns

            // Parse and store data column-wise
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                column1[i] = fields[2];
                column2[i] = fields[3];
                // Assign more columns here
            }

            // Print column data
            for (int i = 1; i < column1.Length; i++)
            {
                if (column1[i] == "Male")
                {
                    male += 1;
                }
                else
                {
                    female += 1;
                }
            }

            for (int i = 1; i < column2.Length; i++)
            {
                if (column2[i] == "A")
                {
                    absent += 1;
                }
                else
                {
                    present += 1;
                }
            }
            Console.WriteLine("Male {0} Female {1}", male, female);
            Console.WriteLine("Absent {0} Present {1}", absent, present);
            label1.Text = male.ToString();
            label2.Text = female.ToString();
            label3.Text = absent.ToString();
            label4.Text = present.ToString();

            chart1.Series["Series1"].Points.AddXY("Male", male);
            chart1.Series["Series1"].Points.AddXY("Female", female);
            //chart title  
            chart1.Titles.Add("Attendance Chart");

            chart2.Series["Series1"].Points.AddXY("Absent", absent);
            chart2.Series["Series1"].Points.AddXY("Present", present);
            //chart title  
            chart2.Titles.Add("Attendance Chart");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
