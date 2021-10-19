using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Exiled.CustomItems.API;
using Server = Exiled.Events.Handlers.Server;

namespace Custom500s
{
    public class Plugin : Plugin<PluginConfig>
    {
        public static Plugin Instance;

        public override string Author => "BlackstrikeSK";
        public override string Name => "Custom500s";
        public override string Prefix => ".c5";
        public override Version RequiredExiledVersion => new Version(3, 0, 5);
        public override Version Version => new Version(1, 0, 0);

        private EventHandlers eventHandler;

        public override void OnEnabled()
        {
            eventHandler = new EventHandlers();

            Config.LoadItems();
            RegisterItems();

            Server.ReloadedConfigs += eventHandler.OnReloadingConfigs; 

            base.OnEnabled();
        }

        public override void OnDisabled()
        {

            UnregisterItems();

            Server.ReloadedConfigs -= eventHandler.OnReloadingConfigs;
            base.OnDisabled();

            eventHandler = null;
        }

        private void RegisterItems()
        {
            Instance.Config.ItemConfigs.SCP330s.Register();
        }

        private void UnregisterItems()
        {
            Instance.Config.ItemConfigs.SCP330s.Unregister();
        }
    }
}
