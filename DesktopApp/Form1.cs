using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            fileSystemWatcher1.Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "pdftest");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string pdfFilePath = dialog.FileName;
                PdfSerialNumberSearch serach = new PdfSerialNumberSearch();

                List<string> serialNumbers = serach.SearchSerialNumbers(pdfFilePath);

                foreach (string serialNumber in serialNumbers)
                {
                    listBoxKode.Items.Add(serialNumber);
                }

            }
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            fileSystemWatcher1.EnableRaisingEvents = false;

            PdfSerialNumberSearch search = new PdfSerialNumberSearch();
            List<string> serialNumbers = search.SearchSerialNumbers(e.FullPath);

            foreach (string serialNumber in serialNumbers)
            {
               
                    listBoxKode.Items.Add(serialNumber);
                
            }
            /*  PdfPrinter printer = new PdfPrinter();
              printer.PrintAll(serialNumbers);
            */

        }
    }
}