using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon1();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace OutlookAddIn
{
    [ComVisible(true)]
    public class ButtonRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public ButtonRibbon()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("OutlookAddIn.Ribbon1.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion


        //On button click gets the selected attachment and calls function SavePdf from class SavePDFToDir
        public void PrintPdf_Click(Office.IRibbonControl control)
        {
            try
            {
                object context = control.Context;
                if (context is Outlook.AttachmentSelection)
                {
                    Outlook.AttachmentSelection selectedAttachments = context as Outlook.AttachmentSelection;
                    Outlook.Attachment SelectedAttachment = selectedAttachments[1];
                    if (SelectedAttachment != null && SelectedAttachment.FileName.ToLower().EndsWith(".pdf"))
                    {
                        SavePDFToDir savePDFToDir = new SavePDFToDir();
                        if (savePDFToDir.SavePdf(SelectedAttachment))
                        {
                            MessageBox.Show("Uspešno!", "Datoteka prenešena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            throw new Exception("Datoteke ni preneslo!");
                        }
                    } else
                    {
                        throw new Exception("Datoteka ni formata .pdf!");
                    }
                            
                }
                Marshal.ReleaseComObject(context); context = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
