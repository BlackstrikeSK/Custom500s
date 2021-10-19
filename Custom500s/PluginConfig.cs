using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.CustomItems.API.Features;
using Exiled.Loader;

namespace Custom500s
{
    public sealed class PluginConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public Configs.ItemConfig ItemConfigs;

        public string ItemConfigFolder { get; set; } = Path.Combine(Paths.Configs, "CustomItems");

        public string ItemConfigFile { get; set; } = "global.yml";

        public void LoadItems()
        {
            if (!Directory.Exists(ItemConfigFolder))
                Directory.CreateDirectory(ItemConfigFolder);

            string filePath = Path.Combine(ItemConfigFolder, ItemConfigFile);
            Log.Info($"{filePath}");
            if (!File.Exists(filePath))
            {
                ItemConfigs = new Configs.ItemConfig();
                File.WriteAllText(filePath, Loader.Serializer.Serialize(ItemConfigs));
            }
            else
            {
                ItemConfigs = Loader.Deserializer.Deserialize<Configs.ItemConfig>(File.ReadAllText(filePath));
                File.WriteAllText(filePath, Loader.Serializer.Serialize(ItemConfigs));
            }
        }
    }
}
