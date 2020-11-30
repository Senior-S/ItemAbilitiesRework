using System;

namespace ItemAbilitiesRework.Models
{
    public class ItemEffect
    {
        public ushort ItemId { get; set; }

        public string Effect { get; set; }

        public float Multiplier { get; set; }
    }
}
