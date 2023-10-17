﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Buffs
{
	public class Frostbite : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
			
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			
        }
	}
}