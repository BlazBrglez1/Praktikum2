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
    internal class SearchProductionOrReserve
    {
        public string SearchProdOrRes(string pdfFilePath)
        {
            string productionOrReserve = null;

            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string text = PdfTextExtractor.GetTextFromPage(reader, i);
                    string[] lines = text.Split('\n');

                    foreach (string line in lines)
                    {
                        if (line.Contains("Produktionslager"))
                        {
                            productionOrReserve = "Produktionslager";
                            break;
                        }
                        else if (line.Contains("Ersatzteillager"))
                        {
                            productionOrReserve = "Ersatzteillager";
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(productionOrReserve))
                        break;
                }

                return productionOrReserve;
            }
        }
    }
}
