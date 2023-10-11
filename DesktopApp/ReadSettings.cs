using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    /// <summary>
    /// This class is responsible for reading settings from a file.
    /// </summary>
    internal class ReadSettings
    {
        /// <summary>
        /// Reads settings from a file and returns them as a dictionary.
        /// </summary>
        /// <returns>A dictionary containing key-value pairs of settings.</returns>
        public Dictionary<string, string> ReadSettingsFromFile()
        {
            // Create a dictionary to store settings.
            Dictionary<string, string> settings = new Dictionary<string, string>();

            // Get the path to the settings file.
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Settings.txt");

            // Read all lines from the file into an array.
            string[] lines = File.ReadAllLines(filePath);

            // Parse each line to extract key-value pairs.
            foreach (string line in lines)
            {
                // Split the line into key and value parts.
                string[] parts = line.Split('=');

                // Check if the line contains a valid key-value pair.
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    // Add the key-value pair to the settings dictionary.
                    settings[key] = value;
                }
            }

            // Return the settings dictionary.
            return settings;
        }
    }
}
