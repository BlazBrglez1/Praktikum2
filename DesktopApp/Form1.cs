using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Apitron.PDF.Controls;
using Apitron.PDF.Rasterizer;

namespace DesktopApp
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            fileSystemWatcher1.Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "pdftest");

            // Populate the ListView with PDF files
            string printPdfFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "printpdf");
            string[] pdfFiles = Directory.GetFiles(printPdfFolderPath, "*.pdf");

            foreach (string filePath in pdfFiles)
            {
                string fileName = Path.GetFileName(filePath);
                ListViewItem item = new ListViewItem(fileName);
                item.Tag = filePath;
                listView1.Items.Add(item);
            }
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

            PdfPrinter printer = new PdfPrinter();
            printer.PrintAll(serialNumbers);




            if (File.Exists(e.FullPath))
            {
                // Load the PDF into the PdfViewer control
                try
                {

                    FileStream fs = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read);
                    pdfViewer1.Document = new Document(fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }



        //Dodajanje nacrta

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                string fileName = Path.GetFileName(filePath);
                string destinationFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "printpdf");
                string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

                if (File.Exists(destinationFilePath))
                {
                    MessageBox.Show("Datoteka s takšnim imenom že obstaja!");
                }
                else
                {
                    // Copy the file to the destination folder
                    File.Copy(filePath, destinationFilePath);
                    RefreshListView();
                }
            }
        }



        //Osvezi list nacrtov 

        private void RefreshListView()
        {
            string destinationFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "printpdf");

            listView1.Items.Clear();

            string[] pdfFiles = Directory.GetFiles(destinationFolderPath, "*.pdf");

            foreach (string pdfFile in pdfFiles)
            {
                listView1.Items.Add(Path.GetFileName(pdfFile));
            }
        }

        //filtriranje nacrtov
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.ToLower();

            listView1.Items.Clear();

            string destinationFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "printpdf");

            string[] pdfFiles = Directory.GetFiles(destinationFolderPath, "*.pdf");

            foreach (string pdfFile in pdfFiles)
            {
                string fileName = Path.GetFileName(pdfFile).ToLower();

                if (fileName.Contains(filterText))
                {
                    listView1.Items.Add(Path.GetFileName(pdfFile));
                }
            }
        }
    }
}