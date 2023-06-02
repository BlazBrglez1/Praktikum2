using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    internal class ReadSettings
    {
        public Dictionary<string, string> ReadSettingsFromFile()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Settings.txt");

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('=');
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    settings[key] = value;
                }
            }

            return settings;
        }
    }
}
