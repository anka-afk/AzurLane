using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace AzurLane.Contents.Items.Items
{
    public class 心智魔方 : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("心智魔方");
            // Tooltip.SetDefault("心智魔方，又名“失智魔方”，“宇宙魔方”(误)。\n 特殊的材料，主要用于制作舰船的龙骨，舰娘就诞生于心智魔方。");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 51;
            Item.height = 51;
            Item.rare = ItemRarityID.Cyan;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(2, 0, 0, 0);
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            return false;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation,
        float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Type].Value; // 获取物品的贴图
            Vector2 position = Item.position - Main.screenPosition; // 计算物品在屏幕上的位置

            float scaleFactor = 0.1f; // 缩放比例为50%
            Vector2 origin = texture.Size() * 0.1f; // 设置贴图的原点为中心

            spriteBatch.Draw(texture, position + origin, null, lightColor, rotation, origin, scaleFactor,
                SpriteEffects.None, 0f); // 绘制缩放后的物品贴图

            base.PostDrawInWorld(spriteBatch, lightColor, alphaColor, rotation, scale, whoAmI);
        }
    }
}