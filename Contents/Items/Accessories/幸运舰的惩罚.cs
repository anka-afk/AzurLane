using System;
using AzurLane.Contents.Buffs;
using AzurLane.Contents.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AzurLane.Contents.Items.Accessories
{
    public class 幸运舰的惩罚 : ModItem

    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("幸运舰的\"惩罚\"");
            // Tooltip.SetDefault("攻击命中有5%的概率给予破甲debuff(防御-20%)\n防御增加10%\n——这就是你给我的答案吗？怎么办好呢……噗，真是笨啊，我的指挥官大人，我早就不是一开始那个对什么都感到空虚的我了，你难道忘了是谁让我改变的吗？");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 128;
            Item.height = 128;
            Item.rare = ItemRarityID.Cyan;
            Item.value = Item.sellPrice(2, 0, 0, 0);
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += player.statDefense * 0.1f;
            //当命中敌人时给予敌人一种自定义的buff
        }
    }
}