using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesktopApp
{
    internal class PdfDateAndOrderNumberSearch
    {

        public string SearchDateAndOrderNumber(string pdfFilePath)
        {
            string result = "";
            bool isDateFound = false;
            bool isOrderNumberFound = false;

            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string text = PdfTextExtractor.GetTextFromPage(reader, i);
                    string[] lines = text.Split('\n');

                    foreach (string line in lines)
                    {
                        string datePattern = @"Belegdatum:\s+(\d{2}\.\d{2}\.\d{2})";
                        // Extract the date
                        Match dateMatch = Regex.Match(line, datePattern);
                        if (dateMatch.Success)
                        {
                            string date = dateMatch.Groups[1].Value;
                            result += date + "\n";
                            isDateFound = true;
                        }

                        string orderNumberPattern = @"Bestellnr\.:\s+([A-Z]{2}\d{2}-\d{4})";
                        // Extract the order number
                        Match orderNumberMatch = Regex.Match(line, orderNumberPattern);
                        if (orderNumberMatch.Success)
                        {
                            string orderNumber = orderNumberMatch.Groups[1].Value;
                            result += orderNumber + "\n";
                            isOrderNumberFound = true;
                        }
                    }
                }
            }

            if (!isDateFound || !isOrderNumberFound || string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Datum ali številka naročila nista bila najdena v naročilnici! Preverite načrte in ju dodajte ročno");
                return "";
            }

            return result;
        }




    }
}
