using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace AzurLane.Contents.Items.Items
{
    public class 心智单元I : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1; // 该物品的研究解锁序号
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = Terraria.ID.ItemRarityID.Cyan;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(2, 0, 0, 0);
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
            float scaleFactor = 0.25f; // 缩放比例为25%
            Vector2 origin = texture.Size() * 0.25f; // 设置贴图的原点为中心
            spriteBatch.Draw(texture, position + origin, null, lightColor, rotation, origin, scaleFactor, SpriteEffects.None, 0f); // 绘制缩放后的物品贴图
        }
    }
}