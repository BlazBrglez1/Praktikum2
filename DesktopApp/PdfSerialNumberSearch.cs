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

        List<string> serialFull = new List<string>();

        List<string> serialXX = new List<string>();

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
                        serialFull.Add(match.Value);
                    }


                    string patternXX = @"\bS\d{8}XX\b";
                    ;
                    MatchCollection matchesXX = Regex.Matches(line, patternXX);

                    foreach (Match match in matchesXX)
                    {
                        serialXX.Add(match.Value);
                    }
                }
            }
            serialNumbers = CompareAndSave(serialFull, serialXX);
            return serialNumbers;
            
        }
        

    }
    public List<string> CompareAndSave(List<string> serialFull, List<string> serialXX)
    {
        List<string> result = new List<string>();

        foreach (string fullValue in serialFull)
        {
            string firstNineChars = fullValue.Substring(0, 9);
            bool matchFound = false;

            foreach (string valueWithoutXX in serialXX)
            {
                string firstNineCharsWithoutXX = valueWithoutXX.Substring(0, 9);

                if (firstNineChars == firstNineCharsWithoutXX)
                {
                    result.Add(fullValue);
                    matchFound = true;
                    break;
                }
            }

            if (!matchFound)
            {
                result.Add(fullValue);
            }
        }

        foreach (string valueWithoutXX in serialXX)
        {
            bool matchFound = false;

            foreach (string fullValue in serialFull)
            {
                string firstNineChars = fullValue.Substring(0, 9);
                string firstNineCharsWithoutXX = valueWithoutXX.Substring(0, 9);

                if (firstNineChars == firstNineCharsWithoutXX)
                {
                    matchFound = true;
                    break;
                }
            }

            if (!matchFound)
            {
                result.Add(valueWithoutXX);
            }
        }

        return result;
    }




}

