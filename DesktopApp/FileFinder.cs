using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DesktopApp
{
    internal class FileFinder
    {

        private string directoryPath;

        public FileFinder()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            directoryPath = Path.Combine(baseDirectory, "..", "..", "..", "printpdf");
        }

        public string FindFileName(string serialNumber)
        {

            string[] pdfFiles = Directory.GetFiles(directoryPath, "*.pdf");

            // Find an exact match for serial numbers starting with 'S' and followed by 10 digits
            if (serialNumber.Length == 11 && serialNumber.StartsWith("S") && !serialNumber.EndsWith("XX"))
            {
                string numberWithoutS = serialNumber.Substring(1, 10);
                string numberWithSmallS = "s" + numberWithoutS;

                foreach (string pdfFile in pdfFiles)
                {
                    string pdfFileName = Path.GetFileNameWithoutExtension(pdfFile);
                    if (pdfFileName.StartsWith(numberWithSmallS))
                    {
                        if (pdfFileName != null)
                        {
                            return pdfFileName;
                        }
                    }
                }

            }
            // Find the newest version for serial numbers starting with 'S' and followed by 8 digits and ending with "XX"
            else if (serialNumber.Length == 11 && serialNumber.StartsWith("S") && serialNumber.EndsWith("XX"))
            {
                string firstEightDigits = serialNumber.Substring(1, 8);
                string firstEightDigitsWithSmallS = "s" + firstEightDigits;


                string matchingFileName = null;
                int maxVersion = -1;

                foreach (string pdfFile in pdfFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pdfFile);

                    if (fileName.StartsWith(firstEightDigitsWithSmallS))
                    {
                        int version;
                        if (int.TryParse(fileName.Substring(1, 10), out version) && version > maxVersion)
                        {
                            maxVersion = version;
                            matchingFileName = fileName;
                        }
                    }
                }

                if (matchingFileName != null)
                {
                    return matchingFileName;
                }
            }

            return null; // No matching file found
        }

    }
}
