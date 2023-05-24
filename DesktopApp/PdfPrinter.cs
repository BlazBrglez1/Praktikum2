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
        public void PrintAll(List<string> serialNumbers)
        {
            foreach (string serialNumber in serialNumbers)
            {

                string pdfFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "printpdf", serialNumber + ".pdf");


                Debug.WriteLine("printam"); 

                if (File.Exists(pdfFileName))
                {
                    PrintPdf(pdfFileName);
                }
            }
        }

        private void PrintPdf(string pdfFileName)
        {
            string acrobatPath = @"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe";

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

            p.WaitForExit();
        }

    }
}

