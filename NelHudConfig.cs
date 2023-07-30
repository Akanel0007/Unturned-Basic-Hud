using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NelHud
{
    public class NelHudConfig : IRocketPluginConfiguration
    {
        public string NelPlugins;
        public string NelPluginsDiscord;
        public void LoadDefaults()
        {
            NelPlugins = "NelPlugins";
            NelPluginsDiscord = "https://discord.gg/yk5Sa6GR7g";
        }
    }
}
