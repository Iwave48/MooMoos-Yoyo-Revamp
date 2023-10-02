using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using CombinationsMod.Projectiles.YoyoProjectiles;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using CombinationsMod.Items.Bars;
using Microsoft.Xna.Framework.Graphics;

namespace CombinationsMod.Items.Yoyos
{
    public class TheCrowyo : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 42;
            Item.height = 40;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 4f;
            Item.knockBack = 3f;
            Item.damage = 49;
            Item.rare = ItemRarityID.Lime;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 8, 60, 0);
            Item.shoot = ModContent.ProjectileType<TheCrowyoProjectile>();
        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<EclipseBar>(), 10)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
        }
    }
}