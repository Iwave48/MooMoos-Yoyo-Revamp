﻿using CombinationsMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Projectiles.YoyoEffects.Solid
{

    public class Sparkle3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sparkle 1");
        }

        public override void SetDefaults()
        {
            Projectile.width = 200;
            Projectile.height = 200;
            Projectile.friendly = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.knockBack = 1f;
            Projectile.light = 0.8f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 150;
            Projectile.alpha = 0;
        }

        public override string Texture => "CombinationsMod/Projectiles/YoyoEffects/Solid/Sparkle1";

        public override void PostAI()
        {
            if (Main.rand.NextBool(2))
            {
                for (int i = 0; i < 1; i++)
                {
                    Vector2 circular = Main.rand.NextVector2Circular(3f, 3f);

                    int dust = 0;

                    int rand = Main.rand.Next(4) + 1;
                    switch (rand)
                    {
                        case 1:
                            dust = DustID.SolarFlare;
                            break;

                        case 2:
                            dust = 73;
                            break;

                        case 3:
                            dust = DustID.Vortex;
                            break;

                        case 4:
                            dust = DustID.MartianHit;
                            break;
                    }
                   int dustIndex = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, dust, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 0, default, 1f);
                    //int dustIndex  Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dust, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[dustIndex].noGravity = true;

                }
            }
        }
        public override void AI()
        {

            if (Projectile.ai[1] != -1)
            {
                Projectile proj = Main.projectile[(int)Projectile.ai[1]];

                if (proj.active && proj.owner == Projectile.owner && proj.aiStyle == 99 && !proj.counterweight)
                {
                    Projectile.Center = proj.Center;
                    Projectile.timeLeft = 6;

                    Projectile.netUpdate = true;
                }

                if (proj.ai[0] == -1)
                {
                    Projectile.Kill();
                }
            }
        }
    }
}