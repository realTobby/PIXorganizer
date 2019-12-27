using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIXOrganizer.Logic
{
    public class ConfigManager
    {
        private string ConfigPath = "";
        private string ConfigFolder = "PIXOrganizer";
        private string ConfigFileName = "cfg.porg";
        public ConfigManager()
        {
            

            if(!System.IO.Directory.Exists(Environment.SpecialFolder.UserProfile + @"\" + ConfigFolder))
            {
                System.IO.Directory.CreateDirectory(Environment.SpecialFolder.UserProfile + @"\" + ConfigFolder);
            }

            ConfigPath = Environment.SpecialFolder.UserProfile + @"\" + ConfigFolder + @"\" + ConfigFileName;

            // DEBUG: Process.Start(Environment.SpecialFolder.UserProfile + @"\" + ConfigFolder);
        }

        public bool CheckConfig()
        {
            if(System.IO.File.Exists(ConfigPath))
            {
                // check plausability of config (maybe the syntax or needed parameters)
                return true;
            }
            return false;
        }

        public void SaveConfig()
        {
            System.IO.File.Create(ConfigPath);
        }

        public void ReadConfig()
        {

        }
    }
}
