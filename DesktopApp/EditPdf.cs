
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Font = iTextSharp.text.Font;
using Microsoft.VisualBasic.ApplicationServices;

namespace DesktopApp
{
    internal class EditPdf
    {
        public string AddWatermarkToPDF(string inputFilePath, string dateAndOrderNumber)
        {
            string outputFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".pdf");

            // Create reader and stamper
            using (PdfReader reader = new PdfReader(inputFilePath))
            using (FileStream fs = new FileStream(outputFilePath, FileMode.Create))
            using (PdfStamper stamper = new PdfStamper(reader, fs))
            {
                // Create font and set properties
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, 15, Font.BOLD, BaseColor.BLUE);

                // Get the content of the first page
                PdfContentByte content = stamper.GetUnderContent(1);

                // Set the transparent black box color
                content.SetColorFill(new BaseColor(0, 0, 0, 128)); // Transparent black box (adjust opacity as needed)

                // Add the transparent black box
                content.Rectangle(10, 10, 200, 40); // Position and dimensions of the box
                content.Fill();

                // Add the watermark text in dark blue color
                content.SetColorFill(new BaseColor(0, 0, 139)); // Dark blue color
                content.SetFontAndSize(baseFont, 18);
                content.BeginText();
                content.ShowTextAligned(Element.ALIGN_LEFT, dateAndOrderNumber, 20, 30, 0); // Position of the watermark text
                content.EndText();

                // Close the stamper
                stamper.Close();
            }

            return outputFilePath;
        }

    }
}
