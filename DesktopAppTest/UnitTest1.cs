using DesktopApp;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Diagnostics.CodeAnalysis;

namespace DesktopAppTest
{
    public class Tests { 


        string directoryPath;
        string directoryPathInstall;
        string directoryPathDoc1;

        [OneTimeSetUp]
        public void Setup()
        {
            string currDir = AppDomain.CurrentDomain.BaseDirectory;
            string? parentDir = Directory.GetParent(currDir)?.Parent?.Parent?.Parent?.Parent?.FullName;

            string? pathInstall = Path.Combine(parentDir, "Install.txt");
            directoryPathInstall = pathInstall;

            string? pathNarocilnica = Path.Combine(parentDir, "document - 2023-04-27T142316.364.pdf");
            directoryPath = pathNarocilnica;

            string? pathDoc1 = Path.Combine(parentDir, "Doc1.pdf");
            directoryPathDoc1 = pathDoc1;
        }

        [Test]
        public void ReadSettingsTest()
        {

            Dictionary<string, string> expectedKeyValuePairs = new Dictionary<string, string>();
            expectedKeyValuePairs["printerName"] = "EPSONAC97C2 (L3150 Series)";
            expectedKeyValuePairs["acrobatPath"] = "C:\\Program Files\\Adobe\\Acrobat DC\\Acrobat\\Acrobat.exe";

            ReadSettings readSettings = new ReadSettings();


            Assert.That(expectedKeyValuePairs, Is.EqualTo(readSettings.ReadSettingsFromFile()));
        }

        [Test]
        public void SearchProdOrResTest()
        {
            string expectedSearchRes = "Produktionslager";

            SearchProductionOrReserve search = new SearchProductionOrReserve();

            Assert.That(expectedSearchRes, Is.EqualTo(search.SearchProdOrRes(directoryPath)));
        }

        [Test]
        public void PdfSerNumSearchTest()
        {
            List<string> expectedList = new List<string>
            {
                "S2020103000",
                "S2020103400",
                "S2020103300",
                "S2020103200",
                "S2020103100"
            };

            PdfSerialNumberSearch search = new PdfSerialNumberSearch();

            Assert.That(expectedList, Is.EqualTo(search.SearchSerialNumbers(directoryPath)));
        }

        [Test]
        public void PdfSerNumSearchCompareTest()
        {
            List<string> expectedList = new List<string>
            {
                "S2020103000",
                "S2020103400",
                "S2020103300",
                "S2020103200",
                "S2020103100"
            };

            HashSet<string> serialFull = new HashSet<string>{
                "S2020103000",
                "S2020103400",
                "S2020103300",
                "S2020103200",
                "S2020103100"
            };
            HashSet<string> serialXX = new HashSet<string>();

            PdfSerialNumberSearch pdfSerialNumberSearch = new PdfSerialNumberSearch();

            Assert.That(expectedList, Is.EqualTo(pdfSerialNumberSearch.CompareAndSave(serialFull, serialXX)));

        }

        [Test]
        public void FindCodesWithNoPlanTest() {

            List<string> expectedWithNoPlan = new List<string>
            {
                "S2020103000",
                "S2020103400",
                "S2020103300"
            };

            List<string> mockList = new List<string>
            {
                "S2020103000",
                "S2020103400",
                "S2020103300",
                "S2020103200",
                "S2020103100"
            };

            string datumInSt = "blblblbl";

            PdfPrinter printer = new PdfPrinter();

            Assert.That(expectedWithNoPlan, Is.EqualTo(printer.PrintAll(mockList,datumInSt)));
        }

        [Test]
        public void PdfDateAndOrdNumbTest()
        {
            string expectedDateAndNumber = "BE23-1550 27.04.23 ";

            PdfDateAndOrderNumberSearch search = new PdfDateAndOrderNumberSearch();

            Assert.That(expectedDateAndNumber ,Is.EqualTo(search.SearchDateAndOrderNumber(directoryPath)));
        }

        [Test]
        public void PdfDateAndNumberNotFoundTest() {
            string expectedDateAndNumber = "";

            PdfDateAndOrderNumberSearch search = new PdfDateAndOrderNumberSearch();

            Assert.That(expectedDateAndNumber, Is.EqualTo(search.SearchDateAndOrderNumber(directoryPathDoc1)));
        }

        [Test]
        public void PdfDateAndNumberFileTypeExcTest()
        {
            string mockDateAndNumber = "";

            PdfDateAndOrderNumberSearch search = new PdfDateAndOrderNumberSearch();

           Assert.Throws<iTextSharp.text.exceptions.InvalidPdfException>(() => search.SearchDateAndOrderNumber(directoryPathInstall));
        }

        [Test]
        public void FindFileTest()
        {
            string serialNumberMock = "S2020103200";

            string expectedResult = "s2020103200_-_Leuchtenhalter_links_Abrollkipper";

            FileFinder fileFinder = new FileFinder();

            Assert.That(expectedResult, Is.EqualTo(fileFinder.FindFileName(serialNumberMock)));
        }

        [Test]
        public void FindFileXXTest()
        {
            string serialNumberMock = "S20201032XX";

            string expectedResult = "s2020103200_-_Leuchtenhalter_links_Abrollkipper";

            FileFinder fileFinder = new FileFinder();

            Assert.That(expectedResult, Is.EqualTo(fileFinder.FindFileName(serialNumberMock)));
        }

    }
    
}