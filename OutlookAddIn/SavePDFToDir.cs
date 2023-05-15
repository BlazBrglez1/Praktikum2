using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookAddIn
{
    internal class SavePDFToDir
    {
        
        //Saves pdf to dir, checks if file already exists
        public bool SavePdf(Outlook.Attachment attachment)
        {
            string path = "C:\\Users\\Matevž\\Desktop\\Praktikum2\\PdfFromAddIn\\" + attachment.FileName;            
            
            if (File.Exists(path))
            {
                DialogResult result = MessageBox.Show($"Datoteka z imenom {attachment.FileName} že obstaja! Jo želite prepisati?", "Datoteka že obstaja", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    attachment.SaveAsFile(path);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                attachment.SaveAsFile(path);
                return true;
            }
            
        }
    }
}
