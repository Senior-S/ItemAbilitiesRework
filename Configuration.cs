using ItemAbilitiesRework.Models;
using Rocket.API;
using System.Collections.Generic;

namespace ItemAbilitiesRework
{
    public class Configuration : IRocketPluginConfiguration
    {
        public void LoadDefaults()
        {
            //item_effects = "140,speed3,81,gravity0";
            //clothing_effects = "310,jump2";
            ItemEffects = new List<ItemEffect> { ItemEffect };
            ClothEffects = new List<ClothEffect> { ClothEffect };
        }

        public List<ItemEffect> ItemEffects = new List<ItemEffect>();
        public List<ClothEffect> ClothEffects = new List<ClothEffect>();

        private readonly ItemEffect ItemEffect = new ItemEffect
        {
            ItemId = 140,
            Effect = "speed",
            Multiplier = 3
        };

        private readonly ClothEffect ClothEffect = new ClothEffect
        {
            ClothId = 310,
            Effect = "jump",
            Multiplier = 2
        };
    }
}
