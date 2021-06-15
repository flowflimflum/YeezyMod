using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FYM.NPCs
{
    [AutoloadHead]
    public class DrippyNPC : ModNPC
    {
        public override string Texture
        {
            get { return "FYM/NPC/DrippyNPC"; }
        }

        public override string[] AltTextures
        {
            get { return new[] { "FYM/NPC/DrippyNPC_Alt_1" }; }
        }

        public override bool Autoload(ref string name)
        {
            name = "Drippy Npc";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 26;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 5;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7; 
            npc.damage = 12;
            npc.defense = 17;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    if (item.type == mod.ItemType("TMMCItem"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    return "Flow";
                case 1:
                    return "Gansta";
                case 2:
                    return "Ryan";
                default: 
                    return "Short";
            }
        }

        public override string GetChat()
        {
            int otherNPC = NPC.FindFirstNPC(NPCID.Angler);
            if (otherNPC >= 0 && Main.rand.NextBool(4))
            {
                return "Did you know that " + Main.npc[otherNPC].GivenName + " is dumb?";
            }
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "Honestly These Shoes Are Drippy.";
                case 1:
                    return "These Shoes are for the right price.";
                case 2:
                    return "These shoes are the best PROVE ME WRONG.";
                default:
                    return "This is pretty simple to do, just modify the GetChat() method";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Custom";

        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
               
                shop = true;
            }
            else
            {
                Main.npcChatText = "Im too gansta.";
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {

            shop.item[nextSlot].SetDefaults(mod.ItemType("Broken Yeezys, 1"));
            nextSlot++;

            if (Main.moonPhase == 2)
            {
                shop.item[nextSlot].SetDefaults(ItemID.MoonCharm);
                nextSlot++;
            }
            if (Main.hardMode) 
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("Yeezys"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType(""));
                nextSlot++;
            }
            if (Main.LocalPlayer.HasBuff(BuffID.Regeneration)) 
            {
                shop.item[nextSlot].SetDefaults(ItemID.RecallPotion);
                nextSlot++;
            }

        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), mod.ItemType("Broken Yeezys"));
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 25;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 25;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.DemonScythe;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 5f;
            randomOffset = 2f;
        }
    }
}


