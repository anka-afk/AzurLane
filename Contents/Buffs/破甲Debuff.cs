using AzurLane.Contents.Global;
using AzurLane.Contents.Items.Accessories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AzurLane.Contents.Buffs
{
    public class 破甲Debuff : ModBuff//继承modbuff类
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("破甲");//buff名称
            // Description.SetDefault("破甲");//buff的提示
            Main.debuff[Type] = true;//为true时就是debuff
            Main.buffNoSave[Type] = false;//为true时退出世界时buff消失
            Main.buffNoTimeDisplay[Type] = false;//为true时不显示剩余时间
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            Main.lightPet[Type] = false;
            BuffID.Sets.LongerExpertDebuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.persistentBuff[Type] = false;
            Main.vanityPet[Type] = false;
        }
        public const int DefenseReductionPercent = 25;
        public static float DefenseMultiplier = 1 - DefenseReductionPercent / 100f;


        //我们做一个让NPC破防的buff
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<施加破甲buff>().has破甲Debuff = true;
        }
    }
}