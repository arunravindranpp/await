using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int CountCharacters()
        {
            int count = 0;
            // Create a StreamReader and point it to the file to read
            using (StreamReader reader = new StreamReader("C:\\Data\\Data.txt"))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                // Make the program look busy for 5 seconds
                Thread.Sleep(5000);
            }

            return count;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<int> task =new Task<int>(CountCharacters);
            task.Start();
            label2.Text = "Processing file. Please wait...";
            int count = await task;
            label2.Text = count.ToString() + " characters in file";
        }


    }
}