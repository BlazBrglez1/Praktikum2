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
        public void PrintPdf(string filePath)
        {
            // Replace "AcroRd32.exe" with the path to your Adobe Reader executable if necessary
            string pdfReaderPath = @"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe";
            string args = $"/s /o /h /p \"{filePath}\"";

            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = pdfReaderPath,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForExit();
        }

        public void PrintAll(List<string> serialNumbers)
        {
            foreach (string serialNumber in serialNumbers)
            {
                string pdfName = $"{serialNumber}.pdf";
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string printPdfDirectory = Path.Combine(baseDirectory, "printpdf");
                string pdfPath = Path.Combine(printPdfDirectory, pdfName);  // specify the directory where your PDFs are
                if (File.Exists(pdfPath))
                {
                    PrintPdf(pdfPath);
                }
                else
                {
                    // handle the case where the file does not exist
                }
            }
        }
    }
}
