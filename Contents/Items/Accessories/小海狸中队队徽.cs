using System;
using AzurLane.Contents.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AzurLane.Contents.Items.Accessories
{
    public class 小海狸中队队徽 : ModItem
    {
        public override void SetStaticDefaults()
        {
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
            //使得玩家速度增加20%
            player.moveSpeed += 0.2f;
            player.maxRunSpeed += 0.2f;
            player.accRunSpeed += 0.2f;
            player.runAcceleration += 0.2f;
            player.stepSpeed += 0.2f;
        }
    }
}