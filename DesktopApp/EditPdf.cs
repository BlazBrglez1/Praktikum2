
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
                Font font = new Font(baseFont, 18, Font.BOLD, BaseColor.BLUE);

                // Get the content of the first page
                PdfContentByte content = stamper.GetUnderContent(1);

                // Add the rectangle with a black border
                content.SetLineWidth(0.5f); // Set the border width
                content.SetColorStroke(BaseColor.BLACK); // Set the border color

                float rectWidth = 150;
                float rectHeight = 40;
                float rectX = 10;
                float rectY = 5; // Adjust the Y position to move the watermark lower on the PDF

                content.Rectangle(rectX, rectY, rectWidth, rectHeight); // Position and dimensions of the box
                content.Stroke();

                // Add the watermark text in black color
                content.SetColorFill(BaseColor.BLACK); // Black color for text
                content.SetFontAndSize(baseFont, 18); // Font size for "PREJETO"

                float textX = rectX + rectWidth / 2;
                float textY = rectY + rectHeight / 2 - 7;

                content.BeginText();
                content.ShowTextAligned(Element.ALIGN_CENTER, "PREJETO", textX, textY + 10, 0); // Position of the "PREJETO" text
                content.SetFontAndSize(baseFont, 12); // Decrease the font size for the dateAndOrderNumber
                content.ShowTextAligned(Element.ALIGN_CENTER, dateAndOrderNumber, textX, textY - 12, 0); // Position of the second line
                content.EndText();

                // Close the stamper
                stamper.Close();
            }

            return outputFilePath;
        }





    }
}
