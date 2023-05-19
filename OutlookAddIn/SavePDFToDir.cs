using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
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
            string parentdir = GetParentDirectory(AppDomain.CurrentDomain.BaseDirectory, 3);

            string path = Path.Combine(parentdir, "DesktopApp", "pdftest", attachment.FileName);

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

        static string GetParentDirectory(string directoryPath, int levels)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            for (int i = 0; i < levels; i++)
            {
                if (directory.Parent == null)
                {
                    // Return null or throw an exception, depending on your requirement
                    return null;
                }
                directory = directory.Parent;
            }

            return directory.FullName;
        }
    }
}
