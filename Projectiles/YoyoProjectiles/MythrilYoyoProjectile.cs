using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CombinationsMod.Projectiles.YoyoEffects;
using CombinationsMod.ModSystems;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class MythrilYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 263f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 17.6f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;
        }
        public override void OnSpawn(IEntitySource source)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X,
                    Projectile.Center.Y, 0, 0, ModContent.ProjectileType<MythrilSwirl>(),
                    (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);

                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X,
                    Projectile.Center.Y, 0, 0, ModContent.ProjectileType<MythrilPartSwirl>(),
                    (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[proj].scale = 1.8f;
            }
        }
    }   
}
