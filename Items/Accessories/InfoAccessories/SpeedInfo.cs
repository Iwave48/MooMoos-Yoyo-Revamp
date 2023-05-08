﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CombinationsMod.Items.Yoyos;

namespace CombinationsMod.Items.Accessories.InfoAccessories
{
    class SpeedInfo : InfoDisplay
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Yoyo Speed Display");
        }

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().speedTracker;
        }
        
        public override string DisplayValue(ref Color displayColor)/* tModPorter Suggestion: Set displayColor to InactiveInfoTextColor if your display value is "zero"/shows no valuable information */
        {
            Player player = Main.LocalPlayer;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
             Item held = player.HeldItem;
            Projectile projectile = ContentSamples.ProjectilesByType[player.HeldItem.shoot];

            if (ContentSamples.ProjectilesByType[player.HeldItem.shoot].aiStyle == 99)
            {
                if (ContentSamples.ProjectilesByType[player.HeldItem.shoot].MaxUpdates != 0)
                {
                    return (ProjectileID.Sets.YoyosTopSpeed[player.HeldItem.shoot] * projectile.MaxUpdates).ToString();
                }

                return ProjectileID.Sets.YoyosTopSpeed[player.HeldItem.shoot].ToString();
            }
            else
            {
                return ("No Yoyo detected");
            }
        }
    }
}