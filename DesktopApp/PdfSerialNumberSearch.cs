using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesktopApp;

internal class PdfSerialNumberSearch
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
