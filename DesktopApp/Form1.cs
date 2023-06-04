using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Apitron.PDF.Controls;
using Apitron.PDF.Rasterizer;
using System.Text;
using System.Linq;
using com.itextpdf.text.pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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

        //ro�no nalaganje v programu
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                listBoxKode.Items.Clear();
                listBoxBrez.Items.Clear();
                pdfViewer1.Document = null;

                SearchProductionOrReserve searchProductionOrReserve = new SearchProductionOrReserve();
                string productionOrReserve = searchProductionOrReserve.SearchProdOrRes(dialog.FileName);




                PdfSerialNumberSearch search = new PdfSerialNumberSearch();
                List<string> serialNumbers = search.SearchSerialNumbers(dialog.FileName);

                label3.Text = "Najdene kode" + "(" + serialNumbers.Count + ")" + ":";

                PdfDateAndOrderNumberSearch dateAndNumSearch = new PdfDateAndOrderNumberSearch();
                string dateAndOrderNumber = dateAndNumSearch.SearchDateAndOrderNumber(dialog.FileName);


                if (productionOrReserve != null)
                {
                    label2.Text = "PREGLED NARO�ILA" + "(" + productionOrReserve + " " + dateAndOrderNumber + ")";
                }
                else
                {
                    MessageBox.Show("Naro�ilnica ni 'Produktionslager' niti 'Ersatzteillager'! Program bo nadaljeval izvajanje.");
                }

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
                        MessageBox.Show($"Pri prikazovanju naro�ilnice {dialog.FileName} je pri�lo do napake: {ex.Message}");
                    }
                }


                PdfPrinter printer = new PdfPrinter();
                List<string> kodeBrezNa�rta = printer.PrintAll(serialNumbers, dateAndOrderNumber);

                foreach (string kodaBrez in kodeBrezNa�rta)
                {
                    listBoxBrez.Items.Add(kodaBrez);
                }

            }
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            fileSystemWatcher1.EnableRaisingEvents = false;

            listBoxKode.Items.Clear();
            listBoxBrez.Items.Clear();
            pdfViewer1.Document = null;

            SearchProductionOrReserve searchProductionOrReserve = new SearchProductionOrReserve();
            string productionOrReserve = searchProductionOrReserve.SearchProdOrRes(e.FullPath);

            PdfSerialNumberSearch search = new PdfSerialNumberSearch();
            List<string> serialNumbers = search.SearchSerialNumbers(e.FullPath);

            label3.Text = "Najdene kode" + "(" + serialNumbers.Count + ")" + ":";


            PdfDateAndOrderNumberSearch dateAndNumSearch = new PdfDateAndOrderNumberSearch();
            string dateAndOrderNumber = dateAndNumSearch.SearchDateAndOrderNumber(e.FullPath);

            if (productionOrReserve != null)
            {
                label2.Text = "PREGLED NARO�ILA" + "(" + productionOrReserve + " " + dateAndOrderNumber + ")";
            }
            else
            {
                MessageBox.Show("Naro�ilnica ni 'Produktionslager' niti 'Ersatzteillager'! Program bo nadaljeval izvajanje.");
            }

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
                    MessageBox.Show($"Pri prikazovanju naro�ilnice {e.FullPath} je pri�lo do napake: {ex.Message}");
                }
            }


            PdfPrinter printer = new PdfPrinter();
            List<string> kodeBrezNa�rta = printer.PrintAll(serialNumbers, dateAndOrderNumber);

            foreach (string kodaBrez in kodeBrezNa�rta)
            {
                listBoxBrez.Items.Add(kodaBrez);
            }

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
                    MessageBox.Show("Datoteka s tak�nim imenom �e obstaja!");
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

        //ob odpiranju forme izbrisi obstoje�e datoteke(naro�ilnice)
        private void Form1_Load(object sender, EventArgs e)
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
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ob brisanju datoteke {filePath} je pri�lo do napake: {ex.Message}");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Iterate over the selected items in the ListView
            foreach (ListViewItem selectedItem in listView1.SelectedItems)
            {
                // Get the full file path from the Tag property of the
                string filePath = null;
                try
                {
                   filePath = selectedItem.Tag.ToString();
                }
                catch 
                {
                    MessageBox.Show("Novo vstavljene datoteke ni mo�no najti. Znova za�enite program in poskusite ponovno!");
                }
                

                try
                {
                    // Delete the file
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during deletion
                    MessageBox.Show($"Ob brisanju datoteke {filePath} je pri�lo do napake: {ex.Message}");
                }
            }

            // Refresh the ListView to reflect the changes
            RefreshListView();
        }

        private void listBoxKode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (listBoxKode.SelectedItem != null)
                {
                    try
                    {
                        string selectedText = listBoxKode.SelectedItem.ToString();
                        Clipboard.SetText(selectedText);
                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show("Kopiranje texta ni mo�no. Ponovno za�enite aplikacijo! Exception: "+ ex.Message);
                    }
                    
                }
            }
        }
    }
}