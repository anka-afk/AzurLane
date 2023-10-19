using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AzurLane.Contents.Items.Accessories
{
    public class 夜姬的任性组合 : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("夜姬的任性组合");
            // Tooltip.SetDefault("获得1%的吸血效果.\n哼哼，你还真是不坦率……好啦，准备好收下我甜美的鲜血，迎接以罗伊的赐福吧.");
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
            player.lifeSteal += 0.01f;
        }
    }
}