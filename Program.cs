using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace ConsoleApp3
{
    internal class Program
    {
        static string filePath = "test.csv";

        static string filePath2 = "today.csv";
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("1. Add record");
                Console.WriteLine("2. View all records");
                Console.WriteLine("3. Update record");
                Console.WriteLine("4. Delete record");
                Console.WriteLine("5. Create Attandence");
                Console.WriteLine("6. View Attandence");
                Console.WriteLine("7. Exit");
                Console.WriteLine("8. Analytics");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRecord();
                        break;
                    case "2":
                        ViewAllRecords();
                        break;
                    case "3":
                        UpdateRecord();
                        break;
                    case "4":
                        DeleteRecord();
                        break;
                    case "5":
                        CreateAttendance();
                        break;
                    case "6":
                        ViewAttendance();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    case "8":
                        Analytics();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddRecord()
        {
            Console.WriteLine("Enter record (Format: id,name,gender): ");
            string record = Console.ReadLine();

            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(record);
                    Console.WriteLine("Record added successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding record: " + ex.Message);
            }
        }

        static void ViewAllRecords()
        {
            try
            {
                List<string> records = File.ReadAllLines(filePath).ToList();
                Console.WriteLine("Records:");
                foreach (string record in records)
                {
                    Console.WriteLine(record);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error viewing records: " + ex.Message);
            }
        }

        static void UpdateRecord()
        {
            Console.WriteLine("Enter index of record to update (0-based): ");
            int index = int.Parse(Console.ReadLine());

            try
            {
                List<string> records = File.ReadAllLines(filePath).ToList();
                if (index >= 0 && index < records.Count)
                {
                    Console.WriteLine("Enter new record (Format: id,name,gender): ");
                    string newRecord = Console.ReadLine();
                    records[index] = newRecord;

                    File.WriteAllLines(filePath, records);
                    Console.WriteLine("Record updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating record: " + ex.Message);
            }
        }

        static void DeleteRecord()
        {
            Console.WriteLine("Enter index of record to delete (0-based): ");
            int index = int.Parse(Console.ReadLine());

            try
            {
                List<string> records = File.ReadAllLines(filePath).ToList();
                if (index >= 0 && index < records.Count)
                {
                    records.RemoveAt(index);

                    File.WriteAllLines(filePath, records);
                    Console.WriteLine("Record deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting record: " + ex.Message);
            }
        }

        static void CreateAttendance()
        {
            Console.WriteLine("Student Attendance Time");
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
                        updatedData = lines[i] +",attendence";

                    } else
                    {
                        // Display the current line to the user
                        Console.WriteLine($"Student Info {i + 1}: {lines[i]}");

                        // Ask the user for updated data
                        Console.Write($"Attendence (A = absent or P = Present): ");
                        string attendence = Console.ReadLine();
                        updatedData = lines[i] + "," + attendence;
                    }
                   

                    // Update the data in the array
                    lines[i] = updatedData;
                }

                // Write the updated data back to the CSV file
                File.WriteAllLines("today.csv", lines);

                Console.WriteLine("CSV file updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating CSV file: " + ex.Message);
            }


            //try
            //{
            //    // Read data from existing CSV file
            //    string[] lines = File.ReadAllLines("test.csv");

            //    // Write data to new CSV file
            //    File.WriteAllLines("today.csv", lines);

            //    Console.WriteLine("Data copied successfully from existing CSV file to new CSV file.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error copying data: " + ex.Message);
            //}
        }

        static void ViewAttendance()
        {
            try
            {
                List<string> records = File.ReadAllLines(filePath2).ToList();
                Console.WriteLine("Records:");
                foreach (string record in records)
                {
                    Console.WriteLine(record);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error viewing records: " + ex.Message);
            }
        }

        static void Analytics()
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
            Console.WriteLine("Column 1:");
            for (int i = 1; i < column1.Length; i++)
            {
                if (column1[i] == "Male")
                {
                    male += 1;
                } else
                {
                    female += 1;
                }
            }

            Console.WriteLine("Column 2:");
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
        }

    }
}
