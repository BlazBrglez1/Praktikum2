using DesktopApp;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace DesktopAppTest
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReadSettingsTest()
        {

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs["printerName"] = "EPSONAC97C2 (L3150 Series)";
            keyValuePairs["acrobatPath"] = "C:\\Program Files\\Adobe\\Acrobat DC\\Acrobat\\Acrobat.exe";

            ReadSettings readSettings = new ReadSettings();


            Assert.That(keyValuePairs, Is.EqualTo(readSettings.ReadSettingsFromFile()));
        }
    }
}