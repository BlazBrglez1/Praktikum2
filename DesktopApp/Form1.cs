using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string pdfFilePath = dialog.FileName;
                PdfSerialNumberSearch serach = new PdfSerialNumberSearch();

                List<string> serialNumbers = serach.SearchSerialNumbers(pdfFilePath);

                foreach (string serialNumber in serialNumbers)
                {
                    listBoxKode.Items.Add(serialNumber);
                }

            }
        }
    }
}