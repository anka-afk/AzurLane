﻿using AzurLane.Contents.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AzurLane.Contents.Global
{
    internal class 施加破甲buff:GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool has破甲Debuff;
        public override void ResetEffects(NPC npc)
        {
             has破甲Debuff = false;
        }
        public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
        {
            if (has破甲Debuff)
            {
                // For best results, defense debuffs should be multiplicative
                // 为了获得最佳效果，防御减益应该是乘法的
                modifiers.Defense *= 破甲Debuff.DefenseReductionPercent;
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            // This simple color effect indicates that the buff is active
            // 这种简单的颜色效果表示增益已激活
            if (has破甲Debuff)
            {
                drawColor.G = 0;
            }
        }
    }
}
