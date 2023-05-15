using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Core;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Outlook;

namespace OutlookAddIn
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.ActiveExplorer().SelectionChange += Explorer_SelectionChange;
        }
  
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        #endregion

        private void Explorer_SelectionChange()
        {
            var selection = this.Application.ActiveExplorer().Selection;
            // Check if exactly one item is selected, and if it's a PDF attachment
            if (selection.Count == 1 && selection[1] is Outlook.Attachment attachment && attachment.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                // Get the context menu for the selected attachment
                var contextMenu = attachment.Parent.CommandBars["Attachment"];

                // Add a new button to the context menu
                var newButton = (CommandBarButton)contextMenu.Controls.Add(MsoControlType.msoControlButton, missing, missing, missing, true);
                newButton.Caption = "Kopiraj pdf";
                newButton.Visible = true;

                MessageBox.Show($"To je datoteka {attachment.FileName}");
            }
            /*if (selection.Count == 1 && selection[1] is Outlook.Attachment attachment)
            {
                MessageBox.Show("Prvi IF");
                    
               
                 if (attachment.Type == Outlook.OlAttachmentType.olByValue && attachment.FileName.EndsWith(".pdf"))
                 {
                     MessageBox.Show("Drugi IF");
                     var commandBars = this.Application.ActiveExplorer().CommandBars;
                     var contextMenu = commandBars["Attachment"] as Office.CommandBarPopup; ; // "Attachment" context menu
                     var copyButton = contextMenu.Controls.Add(Office.MsoControlType.msoControlButton, missing, missing, missing, true) as Office.CommandBarButton;
                     copyButton.Visible = true;
                     copyButton.Caption = "Kopiraj pdf";
                     copyButton.Click += new _CommandBarButtonEvents_ClickEventHandler(CopyButton_Click);
                 }*/
        }
        


        private void CopyButton_Click(Office.CommandBarButton ctrl, ref bool cancel)
        {
            var selection = this.Application.ActiveExplorer().Selection;
            if (selection.Count == 1 && selection[1] is Outlook.Attachment attachment)
            {
                MessageBox.Show("Tretji IF");
                if (attachment.Type == Outlook.OlAttachmentType.olByValue && attachment.FileName.EndsWith(".pdf"))
                {
                    MessageBox.Show("Cetrti IF");
                    var file = Path.Combine("C:\\Users\\Matevž\\Desktop\\Praktikum2\\PdfFromAddIn", attachment.FileName);
                    attachment.SaveAsFile(file);

                    MessageBox.Show("PDF attachment copied to clipboard.");
                }
            }
        }


    }
}
