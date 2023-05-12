using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PraktikumProjekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                    listBox1.Items.Add(serialNumber);
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public partial class PdfSerialNumberSearch
    {
        public List<string> SearchSerialNumbers(string pdfFilePath)
        {
            List<string> serialNumbers = new List<string>();

            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string text = PdfTextExtractor.GetTextFromPage(reader, i);
                    string[] lines = text.Split('\n');

                    foreach (string line in lines)
                    {
                        // Search for serial numbers using regular expression
                        string pattern = @"\bS\d{10}\b"; // Assuming the serial number has 10 digits after 'S'
                        MatchCollection matches = Regex.Matches(line, pattern);

                        foreach (Match match in matches)
                        {
                            serialNumbers.Add(match.Value);
                        }
                    }
                }
            }

            return serialNumbers;
        }
    }
}
