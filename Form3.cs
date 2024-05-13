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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                UpdateRecord(int.Parse(textBox1.Text), textBox2.Text);
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Enter the index Number and Record with mentioned note");
            }

        }

        static void UpdateRecord(int index_no,string update_info)
        {
            string filePath = "test.csv";
            int index = index_no;

            try
            {
                List<string> records = File.ReadAllLines(filePath).ToList();
                if (index >= 0 && index < records.Count)
                {
                    string newRecord = update_info;
                    records[index] = newRecord;

                    File.WriteAllLines(filePath, records);
                    MessageBox.Show("Record updated successfully.");
                }
                else
                {
                    MessageBox.Show("Invalid index.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        static string FindRecord(int index_no)
        {
            string filePath = "test.csv";
            int index = index_no;

            try
            {
                List<string> records = File.ReadAllLines(filePath).ToList();
                if (index >= 0 && index < records.Count)
                {
                   return records[index];
                }
                else
                {
                    return "Invalid index.";
                }
            }
            catch (Exception ex)
            {
                return "Error updating record: " +  ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           textBox2.Text = FindRecord(int.Parse(textBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
