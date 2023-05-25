using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;

namespace DesktopApp
{
    internal class PdfPrinter
    {


        /*TODO:
         * Iskanje pdfjev po serijski stevilki na zacetku imena pdf-ja
         * 
        */
        public void PrintAll(List<string> serialNumbers)
        {
            foreach (string serialNumber in serialNumbers)
            {

                string pdfFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "printpdf", serialNumber + ".pdf");


                if (File.Exists(pdfFileName))
                {

                    EditPdf editPdfWatermark = new EditPdf();

                    string watermarkedPdfPath = editPdfWatermark.addWatermarkToPDF(pdfFileName);

                    PrintPdf(watermarkedPdfPath);
                }
            }
            
            
                PrinterSettings settings = new PrinterSettings();
                foreach (string printerName in PrinterSettings.InstalledPrinters)
                {
                    Console.WriteLine(printerName);
                }
            
        }

        private void PrintPdf(string pdfFileName)
        {
            string acrobatPath = @"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe";

            string printerName = "EPSONAC97C2 (L3150 Series)";

            // Example command line argument for silent printing: /N /T PdfFile PrinterName DriverName PortName
            // We're just going to use /N /T PdfFile to use the default printer
            string args = $"/N /T \"{pdfFileName}\"";

            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = acrobatPath,
                Arguments = args,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };

            Process p = new Process();
            p.StartInfo = psi;
            p.Start();

        }

    }
}

