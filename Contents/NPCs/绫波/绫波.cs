using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Collections.Generic;
using Terraria.Audio;

namespace AzurLane.Contents.NPCs.绫波
{
    [AutoloadHead]
    public class 绫波 : ModNPC
    {
        public override void SetDefaults()
        {
            // 设置友方单位的基本属性
            NPC.width = 40;
            NPC.height = 45;
            NPC.lifeMax = 500;
            NPC.defense = 20;
            NPC.damage = 50;
            NPC.knockBackResist = 0f;
            NPCID.Sets.AttackTime[NPC.type] = 240;
            NPC.townNPC = true;
            //必带项，没有为什么
            //加上这个后NPC就不会在退出地图后消失了，你可以灵活运用一下
            NPC.friendly = true;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            //返回条件为：无
            return true;
        }
        public override bool CanGoToStatue(bool toKingStatue)
        {
            //可以被国王雕像传送
            return !toKingStatue;
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("绫波");
            NPC.townNPC = true;
            base.SetStaticDefaults();
        }

        private const int MoveRange = 200;

        private int frameCounter = 1;

        public override void AI()
        {
            NPCID.Sets.DangerDetectRange[NPC.type] = 1000;
            NPC.scale = 0.3f;
            NPCID.Sets.AttackAverageChance[NPC.type] = 1;
            NPCID.Sets.AttackType[NPC.type] = 3;
            NPC.dontTakeDamage = true;//无敌，不会受到伤害
            Player player = Main.player[NPC.target]; // 获取当前NPC追踪的玩家
            NPC.aiStyle = -1; // 禁用默认AI样式

            float distance = Vector2.Distance(NPC.Center, player.Center);
            if (distance > MoveRange)
            {
                NPC.noGravity = false;
                NPC.noTileCollide = false;
                // 计算NPC向玩家移动的向量
                Vector2 moveDirection = player.Center - NPC.Center;
                moveDirection.Normalize(); // 标准化向量，使其长度为1

                float moveSpeed = 5f; // 移动速度可以根据需要进行调整

                NPC.velocity = moveDirection * moveSpeed; // 设置NPC的速度，使其向玩家移动
            }
            if (distance > MoveRange + 200)
            {
                // 太远了就穿墙飞过来
                NPC.noGravity = true;
                NPC.noTileCollide = true;
                // 计算NPC向玩家移动的向量
                Vector2 moveDirection = player.Center - NPC.Center;
                moveDirection.Normalize(); // 标准化向量，使其长度为1

                float moveSpeed = 10f; // 移动速度可以根据需要进行调整

                NPC.velocity = moveDirection * moveSpeed; // 设置NPC的速度，使其向玩家移动
            }
            if (distance > MoveRange + 2000)
            {
                // 太远了就穿墙飞过来
                NPC.noGravity = true;
                NPC.noTileCollide = true;
                // 计算NPC向玩家移动的向量
                Vector2 moveDirection = player.Center - NPC.Center;
                moveDirection.Normalize(); // 标准化向量，使其长度为1

                float moveSpeed = 100f; // 移动速度可以根据需要进行调整

                NPC.velocity = moveDirection * moveSpeed; // 设置NPC的速度，使其向玩家移动
            }
            
            //如果距离超过10000,传送到玩家身边
            if (distance > 10000)
            {
                NPC.Center = player.Center;
            }
            //当距离小于20时，停止移动
            if (distance < 20)
            {
                NPC.velocity = new Vector2(0, 0);
            }

            if (NPC.velocity.X < 0)
            {
                frameCounter++;
                if (frameCounter > 120)
                {
                    frameCounter = 1; // 重置帧计数器
                }
            }
            if (NPC.velocity.X > 0)
            {
                frameCounter++;
                if (frameCounter > 120)
                {
                    frameCounter = 1; // 重置帧计数器
                }
            }

            //在一般情况下,npc进行随机左右移动
            if (NPC.velocity.X == 0)
            {
                NPC.velocity.X = 1;
            }
            if(distance>MoveRange/2)
            {
                NPC.velocity.X = -1;
            }

            
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 36;
            knockback = 3f;
        }

        //NPC攻击一次后的间隔
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 1;
            randExtraCooldown = 1;
            //间隔的算法：实际间隔会大于或等于cooldown的值且总是小于cooldown+randExtraCooldown的总和（TR总整这些莫名其妙的玩意）
        }

        public override void DrawTownAttackSwing(ref Texture2D item, ref Rectangle itemFrame, ref int itemSize, ref float scale, ref Vector2 offset)
        {
            item = ModContent.Request<Texture2D>("AzurLane/Contents/Items/Weapons/斩舰刀").Value;
            //破坏者大剑hhhhh（注意，这里的Item是Texture2D形式，也就是说，只要有材质就够了）
            //itemSize这个属性目前意义不明，本质上和下面的TownNPCAttackSwing差不多，平时用不到
            scale = 1f;
            //贴图大小，和实际尺寸无关
            //offset这个向量值是决定武器绘制在NPC的哪个位置，平时不用
            itemSize = 80;
            //贴图挥动起点到NPC中心的距离比例，值太大可能会导致武器脱手
            //！注意这不是调整贴图大小的
            scale = 0.1f;
            //绘制偏移量，绝对值越大距离NPC越近
            offset = new Vector2(2 * -NPC.direction, 0);
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<Projectiles.斩舰刀刀光>(); // 使用你的弹幕类的类型
            attackDelay = 20; // 攻击延迟，可以根据需要进行调整
        }
        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
        {
            itemWidth = 119;
            itemHeight = 125;
        }
        private bool firstChat = true;
        public override string GetChat()
        {
            if (firstChat)
            {
                firstChat = false;
                return "吹雪级驱逐舰的改良舰绫波……的说，对我来说，战斗没什么好害怕的，所以虽然只是驱逐舰，但是无论什么敌人我都敢一战……\r\n\r\n";
            }
            else
            {
                string[] randomTexts =
                {
                    "指挥官，吃了吗？我这里还有点心",
                    "这次有好好的检查了通讯设备，不会再给您添麻烦了……",
                    "绫波的耳朵……比较可爱吗？不太懂……指挥官开心就好",
                    "最近时常会做和大家走散的噩梦，一定是我做的还不够好……",
                    "指挥官？…不，没事。我只是确认一下你是不是还在",
                    "唔——有点痒……",
                    "指挥官，请不要……乱碰，感觉……有点奇怪",
                    "虽然不太明白这样有什么意义……但是有点高兴（蹭蹭）",

                };
                return Main.rand.Next(randomTexts);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            // 根据帧计数器获取当前帧的贴图
            Texture2D frameTexture = ModContent.Request<Texture2D>($"AzurLane/Contents/NPCs/绫波/绫波向右移动/绫波向右({frameCounter})").Value;
            // 根据贴图大小和NPC尺寸计算绘制位置和缩放
            Vector2 position = NPC.Center - Main.screenPosition + new Vector2(0f, NPC.gfxOffY - 53 * NPC.scale + 10);
            float scale = NPC.scale * 1f;// 控制贴图大小
            SpriteEffects effects;// 控制左右翻转贴图
            if (NPC.velocity.X < 0)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            else if (NPC.velocity.X > 0)
            {
                effects = SpriteEffects.None;
            }
            else
            {
                effects = NPC.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            }
            Vector2 origin = frameTexture.Size() / 2f;
            // 绘制NPC贴图
            spriteBatch.Draw(frameTexture, position, null, drawColor, NPC.rotation, origin, scale, effects, 0f);
            return false;
        }
    }
}