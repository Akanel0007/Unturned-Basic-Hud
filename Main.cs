using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NelHud
{
    public class Main : RocketPlugin<NelHudConfig>
    {
        protected override void Load()
        {
            Logger.Log("Nel Plugins", ConsoleColor.Red);
            Logger.Log("Nel Hud Version 1.0.0 Loaded", ConsoleColor.Cyan);
            UnturnedPlayerEvents.OnPlayerUpdateHealth += UnturnedPlayerEvents_OnPlayerUpdateHealth;
            UnturnedPlayerEvents.OnPlayerUpdateFood += UnturnedPlayerEvents_OnPlayerUpdateFood;
            UnturnedPlayerEvents.OnPlayerUpdateWater += UnturnedPlayerEvents_OnPlayerUpdateWater;
            UnturnedPlayerEvents.OnPlayerUpdateStamina += UnturnedPlayerEvents_OnPlayerUpdateStamina;
            U.Events.OnPlayerConnected += HandlePlayerConnect;
        }


        private void HandlePlayerConnect(UnturnedPlayer player)
        {
            player.Player.disablePluginWidgetFlag(EPluginWidgetFlags.ShowHealth);
            player.Player.disablePluginWidgetFlag(EPluginWidgetFlags.ShowFood);
            player.Player.disablePluginWidgetFlag(EPluginWidgetFlags.ShowWater);
            player.Player.disablePluginWidgetFlag(EPluginWidgetFlags.ShowStamina);
            player.Player.disablePluginWidgetFlag(EPluginWidgetFlags.ShowVirus);
            player.Player.disablePluginWidgetFlag(EPluginWidgetFlags.ShowOxygen);
            EffectManager.sendUIEffect(9090, 9090, player.SteamPlayer().transportConnection, false);
            EffectManager.sendUIEffectText(9090, player.Player.channel.owner.transportConnection, true, "StaminaText", Configuration.Instance.NelPlugins);
            EffectManager.sendUIEffectText(9090, player.Player.channel.owner.transportConnection, true, "WaterText", player.Thirst.ToString());
            EffectManager.sendUIEffectText(9090, player.Player.channel.owner.transportConnection, true, "FoodText", player.Hunger.ToString());
            EffectManager.sendUIEffectText(9090, player.Player.channel.owner.transportConnection, true, "HealthText", player.Health.ToString());
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateStamina(Rocket.Unturned.Player.UnturnedPlayer player, byte stamina)
        {
            EffectManager.sendUIEffectText(9090, player.Player.channel.owner.transportConnection, true, "StaminaText", player.Stamina.ToString());
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateWater(UnturnedPlayer player, byte water)
        {
            EffectManager.sendUIEffectText(9090, player.Player.channel.owner.transportConnection, true, "WaterText", player.Thirst.ToString());
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateFood(UnturnedPlayer player, byte food)
        {
            EffectManager.sendUIEffectText(9090, player.Player.channel.owner.transportConnection, true, "FoodText", player.Hunger.ToString());
        }
        private void UnturnedPlayerEvents_OnPlayerUpdateHealth(Rocket.Unturned.Player.UnturnedPlayer player, byte health)
        {
            EffectManager.sendUIEffectText(9090, player.Player.channel.owner.transportConnection, true, "HealthText", player.Health.ToString());
        }

        protected override void Unload()
        {
            Logger.Log("Nel Plugins", ConsoleColor.Red);
            Logger.Log("Nel Hud Version 1.0.0 Unloaded", ConsoleColor.Cyan);
            UnturnedPlayerEvents.OnPlayerUpdateHealth -= UnturnedPlayerEvents_OnPlayerUpdateHealth;
            UnturnedPlayerEvents.OnPlayerUpdateFood -= UnturnedPlayerEvents_OnPlayerUpdateFood;
            UnturnedPlayerEvents.OnPlayerUpdateWater -= UnturnedPlayerEvents_OnPlayerUpdateWater;
            UnturnedPlayerEvents.OnPlayerUpdateStamina -= UnturnedPlayerEvents_OnPlayerUpdateStamina;
            U.Events.OnPlayerConnected -= HandlePlayerConnect;
        }
    }
}
