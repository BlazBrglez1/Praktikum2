﻿using System;
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

        private string printerName;

        private string acrobatPath;

        public List<string> PrintAll(List<string> serialNumbers, string dateAndOrderNumber)
        {
            ReadSettings readSettings = new ReadSettings();

            Dictionary<string, string> settings = readSettings.ReadSettingsFromFile();

            printerName = settings["printerName"];
            acrobatPath = settings["acrobatPath"];

            List<string> kodeBrezNačrtov = new List<string>();

            FileFinder filefinder = new FileFinder();


            foreach (string serialNumber in serialNumbers)
            {
                

                string fileName = filefinder.FindFileName(serialNumber);


                string pdfFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "printpdf", fileName + ".pdf");


                if (File.Exists(pdfFileName))
                {

                    EditPdf editPdfWatermark = new EditPdf();

                    string watermarkedPdfPath = editPdfWatermark.AddWatermarkToPDF(pdfFileName, dateAndOrderNumber);

                    //PrintPdf(watermarkedPdfPath);
                    //PrintPdf(watermarkedPdfPath);

                    Thread.Sleep(500);
                }
                else
                {
                    kodeBrezNačrtov.Add(serialNumber);
                    MessageBox.Show("Program ni našel načrta za serijsko število: " + serialNumber+". " +
                        "Vstavite v program pdf načrta, ki se mu ime začne z zgornjo serijsko številko!");
                }
            }
            return kodeBrezNačrtov;
        }

        private void PrintPdf(string pdfFileName)
        {
            try { 
            // Example command line argument for silent printing: /N /T PdfFile PrinterName DriverName PortName
            // We're just going to use /N /T PdfFile to use the default printer
            string args = $"/N /T \"{pdfFileName}\" \"{printerName}\"";

            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = @""+acrobatPath,
                Arguments = args,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };

            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
            p.CloseMainWindow();
            }
            catch
            {
                MessageBox.Show("Pri tiskanju načrta je šlo nekaj narobe");
            }
        }
        
    }
}

