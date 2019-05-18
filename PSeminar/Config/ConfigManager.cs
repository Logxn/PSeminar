using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace PSeminar.Config
{
    public class ConfigManager
    {
        static string _configPath;

        public ConfigManager()
        {
            _configPath = Application.StartupPath;
        }

        public Configuration LoadConfig()
        {
            if (!ConfigFileExist())
            {
                CreateConfigFile();
            }

            return JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(_configPath + @"\config.json"));
        }

        private static void CreateConfigFile()
        {
            var configContent = new Configuration
            {
                GoogleApiKey = ""
            };

            File.WriteAllText(_configPath + @"\config.json", JsonConvert.SerializeObject(configContent));
        }

        private static bool ConfigFileExist()
        {
            return File.Exists(_configPath + @"\config.json");
        }
    }

    public class Configuration
    {
        public string GoogleApiKey { get; set; }
    }
}