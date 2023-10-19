using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AzurLane.Contents.Projectiles
{
    public class 斩舰刀刀光 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Projectile.width = 256;
            Projectile.height = 256;
            Projectile.scale = 1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.alpha = 0;
            Projectile.timeLeft = 360;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 684;
            //AIType = 132;
            Projectile.light = 1f;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 1;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return base.OnTileCollide(oldVelocity);
        }

        public override bool? CanHitNPC(NPC target)
        {
            return base.CanHitNPC(target);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return base.GetAlpha(lightColor);
        }

        public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);
        }

        public override void Kill(int timeLeft)
        {
            base.Kill(timeLeft);
        }

        public override bool PreAI()
        {
            return base.PreAI();
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
    }
}