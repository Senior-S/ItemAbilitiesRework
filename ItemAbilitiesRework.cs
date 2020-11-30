using ItemAbilitiesRework.Models;
using Rocket.Core.Plugins;
using SDG.Unturned;
using Steamworks;
using System.Linq;
using Logger = Rocket.Core.Logging.Logger;

namespace ItemAbilitiesRework
{
    public class ItemAbilitiesRework : RocketPlugin<Configuration>
    {
        protected override void Load()
        {
            Provider.onEnemyConnected += OnEnemyConnected;
            Provider.onEnemyDisconnected += OnEnemyDisconnected;
            PlayerLife.onPlayerDied += OnPlayerDied;
            Logger.Log("[ItemAbilitiesRework] Plugin loaded correctly!");
            Logger.Log("[ItemAbilitiesRework] Official discord: discord.dvtserver.xyz");
        }

        private void OnPlayerDied(PlayerLife sender, EDeathCause cause, ELimb limb, CSteamID instigator)
        {
            sender.player.movement.sendPluginGravityMultiplier(1);
            sender.player.movement.sendPluginJumpMultiplier(1);
            sender.player.movement.sendPluginSpeedMultiplier(1);
        }

        #region Events
        private void OnEnemyConnected(SteamPlayer player)
        {
            player.player.movement.sendPluginGravityMultiplier(1);
            player.player.movement.sendPluginJumpMultiplier(1);
            player.player.movement.sendPluginSpeedMultiplier(1);
            var clothing = player.player.clothing;
            SendEffectClothing(clothing.backpack, player.player);
            SendEffectClothing(clothing.glasses, player.player);
            SendEffectClothing(clothing.hat, player.player);
            SendEffectClothing(clothing.mask, player.player);
            SendEffectClothing(clothing.pants, player.player);
            SendEffectClothing(clothing.shirt, player.player);
            SendEffectClothing(clothing.vest, player.player);
            player.player.equipment.onEquipRequested += OnEquipRequested;
            player.player.equipment.onDequipRequested += OnDequipRequested;
            player.player.clothing.onBackpackUpdated += (newBackpack, newBackpackQuality, newBackpackState) => OnBackpackUpdated(player.player, newBackpack, newBackpackQuality, newBackpackState);
            player.player.clothing.onGlassesUpdated += (newGlasses, newGlassesQuality, newGlassesState) => OnGlassesUpdated(player.player, newGlasses, newGlassesQuality, newGlassesState);
            player.player.clothing.onHatUpdated += (newHat, newHatQuality, newHatState) => OnHatUpdated(player.player, newHat, newHatQuality, newHatState);
            player.player.clothing.onMaskUpdated += (newMask, newMaskQuality, newMaskState) => OnMaskUpdated(player.player, newMask, newMaskQuality, newMaskState);
            player.player.clothing.onPantsUpdated += (newPants, newPantsQuality, newPantsState) => OnPantsUpdated(player.player, newPants, newPantsQuality, newPantsState);
            player.player.clothing.onShirtUpdated += (newShirt, newShirtQuality, newShirtState) => OnShirtUpdated(player.player, newShirt, newShirtQuality, newShirtState);
            player.player.clothing.onVestUpdated += (newVest, newVestQuality, newVestState) => OnVestUpdated(player.player, newVest, newVestQuality, newVestState);
        }

        private void OnEnemyDisconnected(SteamPlayer player)
        {
            player.player.equipment.onEquipRequested -= OnEquipRequested;
            player.player.equipment.onDequipRequested -= OnDequipRequested;
            player.player.clothing.onBackpackUpdated -= (newBackpack, newBackpackQuality, newBackpackState) => OnBackpackUpdated(player.player, newBackpack, newBackpackQuality, newBackpackState);
            player.player.clothing.onGlassesUpdated -= (newGlasses, newGlassesQuality, newGlassesState) => OnGlassesUpdated(player.player, newGlasses, newGlassesQuality, newGlassesState);
            player.player.clothing.onHatUpdated -= (newHat, newHatQuality, newHatState) => OnHatUpdated(player.player, newHat, newHatQuality, newHatState);
            player.player.clothing.onMaskUpdated -= (newMask, newMaskQuality, newMaskState) => OnMaskUpdated(player.player, newMask, newMaskQuality, newMaskState);
            player.player.clothing.onPantsUpdated -= (newPants, newPantsQuality, newPantsState) => OnPantsUpdated(player.player, newPants, newPantsQuality, newPantsState);
            player.player.clothing.onShirtUpdated -= (newShirt, newShirtQuality, newShirtState) => OnShirtUpdated(player.player, newShirt, newShirtQuality, newShirtState);
            player.player.clothing.onVestUpdated -= (newVest, newVestQuality, newVestState) => OnVestUpdated(player.player, newVest, newVestQuality, newVestState);
        }

        private void OnVestUpdated(Player player, ushort newVest, byte newVestQuality, byte[] newVestState)
        {
            player.movement.sendPluginGravityMultiplier(1);
            player.movement.sendPluginJumpMultiplier(1);
            player.movement.sendPluginSpeedMultiplier(1);
            var id = player.equipment.itemID;
            SendEffectItems(id, player);
            SendEffectClothing(newVest, player);
        }

        private void OnShirtUpdated(Player player, ushort newShirt, byte newShirtQuality, byte[] newShirtState)
        {
            player.movement.sendPluginGravityMultiplier(1);
            player.movement.sendPluginJumpMultiplier(1);
            player.movement.sendPluginSpeedMultiplier(1);
            var id = player.equipment.itemID;
            SendEffectItems(id, player);
            SendEffectClothing(newShirt, player);
        }

        private void OnPantsUpdated(Player player, ushort newPants, byte newPantsQuality, byte[] newPantsState)
        {
            player.movement.sendPluginGravityMultiplier(1);
            player.movement.sendPluginJumpMultiplier(1);
            player.movement.sendPluginSpeedMultiplier(1);
            var id = player.equipment.itemID;
            SendEffectItems(id, player);
            SendEffectClothing(newPants, player);
        }

        private void OnMaskUpdated(Player player, ushort newMask, byte newMaskQuality, byte[] newMaskState)
        {
            player.movement.sendPluginGravityMultiplier(1);
            player.movement.sendPluginJumpMultiplier(1);
            player.movement.sendPluginSpeedMultiplier(1);
            var id = player.equipment.itemID;
            SendEffectItems(id, player);
            SendEffectClothing(newMask, player);
        }

        private void OnHatUpdated(Player player, ushort newHat, byte newHatQuality, byte[] newHatState)
        {
            player.movement.sendPluginGravityMultiplier(1);
            player.movement.sendPluginJumpMultiplier(1);
            player.movement.sendPluginSpeedMultiplier(1);
            var id = player.equipment.itemID;
            SendEffectItems(id, player);
            SendEffectClothing(newHat, player);
        }

        private void OnGlassesUpdated(Player player, ushort newGlasses, byte newGlassesQuality, byte[] newGlassesState)
        {
            player.movement.sendPluginGravityMultiplier(1);
            player.movement.sendPluginJumpMultiplier(1);
            player.movement.sendPluginSpeedMultiplier(1);
            var id = player.equipment.itemID;
            SendEffectItems(id, player);
            SendEffectClothing(newGlasses, player);
        }

        private void OnBackpackUpdated(Player player, ushort newBackpack, byte newBackpackQuality, byte[] newBackpackState)
        {
            player.movement.sendPluginGravityMultiplier(1);
            player.movement.sendPluginJumpMultiplier(1);
            player.movement.sendPluginSpeedMultiplier(1);
            var id = player.equipment.itemID;
            SendEffectItems(id, player);
            SendEffectClothing(newBackpack, player);
        }


        private void OnDequipRequested(PlayerEquipment equipment, ref bool shouldAllow)
        {
            equipment.player.movement.sendPluginGravityMultiplier(1);
            equipment.player.movement.sendPluginJumpMultiplier(1);
            equipment.player.movement.sendPluginSpeedMultiplier(1);
            var clothing = equipment.player.clothing;
            SendEffectClothing(clothing.backpack, equipment.player);
            SendEffectClothing(clothing.glasses, equipment.player);
            SendEffectClothing(clothing.hat, equipment.player);
            SendEffectClothing(clothing.mask, equipment.player);
            SendEffectClothing(clothing.pants, equipment.player);
            SendEffectClothing(clothing.shirt, equipment.player);
            SendEffectClothing(clothing.vest, equipment.player);
        }

        private void OnEquipRequested(PlayerEquipment equipment, ItemJar jar, ItemAsset asset, ref bool shouldAllow)
        {
            equipment.player.movement.sendPluginGravityMultiplier(1);
            equipment.player.movement.sendPluginJumpMultiplier(1);
            equipment.player.movement.sendPluginSpeedMultiplier(1);
            var id = jar.item.id;
            var clothing = equipment.player.clothing;
            SendEffectItems(id, equipment.player);
            SendEffectClothing(clothing.backpack, equipment.player);
            SendEffectClothing(clothing.glasses, equipment.player);
            SendEffectClothing(clothing.hat, equipment.player);
            SendEffectClothing(clothing.mask, equipment.player);
            SendEffectClothing(clothing.pants, equipment.player);
            SendEffectClothing(clothing.shirt, equipment.player);
            SendEffectClothing(clothing.vest, equipment.player);
        }
        #endregion Events

        #region Functions
        private void SendEffectItems(ushort id, Player player)
        {
            var items = Configuration.Instance.ItemEffects.Where(k => k.ItemId == id);
            if (items.Count() > 1)
            {
                foreach (ItemEffect item in items)
                {
                    switch (item.Effect.ToLower())
                    {
                        case "speed":
                            player.movement.sendPluginSpeedMultiplier(item.Multiplier);
                            break;
                        case "jump":
                            player.movement.sendPluginJumpMultiplier(item.Multiplier);
                            break;
                        case "gravity":
                            player.movement.sendPluginGravityMultiplier(item.Multiplier);
                            break;
                    }
                }
            }
            else if(items.Count() == 1)
            {
                switch (items.First().Effect.ToLower())
                {
                    case "speed":
                        player.movement.sendPluginSpeedMultiplier(items.First().Multiplier);
                        break;
                    case "jump":
                        player.movement.sendPluginJumpMultiplier(items.First().Multiplier);
                        break;
                    case "gravity":
                        player.movement.sendPluginGravityMultiplier(items.First().Multiplier);
                        break;
                }
            }
        }

        private void SendEffectClothing(ushort id, Player player)
        {
            var cloths = Configuration.Instance.ClothEffects.Where(k => k.ClothId == id);
            if (cloths.Count() > 1)
            {
                foreach (ClothEffect cloth in cloths)
                {
                    switch (cloth.Effect.ToLower())
                    {
                        case "speed":
                            player.movement.sendPluginSpeedMultiplier(cloth.Multiplier);
                            break;
                        case "jump":
                            player.movement.sendPluginJumpMultiplier(cloth.Multiplier);
                            break;
                        case "gravity":
                            player.movement.sendPluginGravityMultiplier(cloth.Multiplier);
                            break;
                    }
                }
            }
            else if (cloths.Count() == 1)
            {
                switch (cloths.First().Effect.ToLower())
                {
                    case "speed":
                        player.movement.sendPluginSpeedMultiplier(cloths.First().Multiplier);
                        break;
                    case "jump":
                        player.movement.sendPluginJumpMultiplier(cloths.First().Multiplier);
                        break;
                    case "gravity":
                        player.movement.sendPluginGravityMultiplier(cloths.First().Multiplier);
                        break;
                }
            }
        }
        #endregion

        protected override void Unload()
        {
            Provider.onEnemyConnected -= OnEnemyConnected;
            Provider.onEnemyDisconnected -= OnEnemyDisconnected;
            Logger.Log("[ItemAbilities] Plugin unloaded correctly!");
        }
    }
}