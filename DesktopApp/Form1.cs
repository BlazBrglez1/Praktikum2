using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Apitron.PDF.Controls;
using Apitron.PDF.Rasterizer;
using System.Text;

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

        //roèno nalaganje v programu
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                listBoxKode.Items.Clear();
                pdfViewer1.Document = null;

                PdfSerialNumberSearch search = new PdfSerialNumberSearch();
                List<string> serialNumbers = search.SearchSerialNumbers(dialog.FileName);

                PdfDateAndOrderNumberSearch dateAndNumSearch = new PdfDateAndOrderNumberSearch();
                string dateAndOrderNumber = dateAndNumSearch.SearchDateAndOrderNumber(dialog.FileName);

                MessageBox.Show(dateAndOrderNumber);

                foreach (string serialNumber in serialNumbers)
                {
                    listBoxKode.Items.Add(serialNumber);
                }

                if (File.Exists(dialog.FileName))
                {
                    // Load the PDF into the PdfViewer control
                    try
                    {
                        FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                        pdfViewer1.Document = new Document(fs);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


                PdfPrinter printer = new PdfPrinter();
                printer.PrintAll(serialNumbers, dateAndOrderNumber);

            }
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            fileSystemWatcher1.EnableRaisingEvents = false;

            listBoxKode.Items.Clear();
            pdfViewer1.Document = null;

            PdfSerialNumberSearch search = new PdfSerialNumberSearch();
            List<string> serialNumbers = search.SearchSerialNumbers(e.FullPath);

            PdfDateAndOrderNumberSearch dateAndNumSearch = new PdfDateAndOrderNumberSearch();
            string dateAndOrderNumber = dateAndNumSearch.SearchDateAndOrderNumber(e.FullPath);

            MessageBox.Show(dateAndOrderNumber);

            foreach (string serialNumber in serialNumbers)
            {
                listBoxKode.Items.Add(serialNumber);
            }

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


            PdfPrinter printer = new PdfPrinter();
            printer.PrintAll(serialNumbers, dateAndOrderNumber);

            fileSystemWatcher1.EnableRaisingEvents = true;

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

        //ob zapiranju forme izbrisi obstojeèe datoteke(naroèilnice)
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string currDir = AppDomain.CurrentDomain.BaseDirectory;
            string? parentDir = Directory.GetParent(currDir)?.Parent?.Parent?.Parent?.FullName;
            string? pathDelete = Path.Combine(parentDir, "pdftest");            

            // Get all file paths in the directory
            string[] filePaths = Directory.GetFiles(pathDelete);

            foreach (string filePath in filePaths)
            {
                string fileExtension = Path.GetExtension(filePath);

                if (fileExtension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    File.Delete(filePath);
                }
            }
        }
    }
}