using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FYM.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    class Yeezys : ModItem
    {
        public override void SetDefaults()
        {
            item.Size = new Vector2(20);
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Purple;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamageMult += 10f;
            player.meleeSpeed += 0.5f;
            player.waterWalk = true;
            player.moveSpeed += 10000f;
            player.jumpSpeedBoost += 10;
            player.lavaImmune = true;
            player.jumpBoost = true;
            player.noKnockback = true;
            player.noFallDmg = true;
            player.gills = true;
            player.maxFallSpeed += 10f;
            player.maxRunSpeed += 1000f;
            player.iceSkate = true;
            player.rocketBoots = Math.Max(player.rocketBoots, 3);
            player.rocketTimeMax = Math.Max(player.rocketTimeMax, 21);





        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldOre, 100);
            recipe.AddIngredient(ItemID.PlatinumCoin, 10);
            recipe.AddIngredient(ItemID.GoldGrasshopper, 1);
            recipe.AddIngredient(ItemID.FrostsparkBoots, 1);
            recipe.AddIngredient(ItemID.FrogLeg, 1);
            recipe.AddIngredient(ItemID.FlurryBoots, 1);
            recipe.AddIngredient(ItemID.SailfishBoots, 1);
            recipe.AddIngredient(ItemID.LavaWaders, 1);
            recipe.AddIngredient(ItemID.GoldenToilet, 1);
            recipe.AddIngredient(ItemID.DiamondRing, 1);
            recipe.AddIngredient(ItemID.GoldBunny, 1);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}



