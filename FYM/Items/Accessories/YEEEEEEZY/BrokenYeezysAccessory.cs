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

namespace FYM.Items.Accessories.YEEEEEEZY
{
    internal class BrokenYeezys : ModItem
    {
        public BrokenYeezys()
        {
        }

        public override void SetDefaults()
        {
            item.Size = new Vector2(20);
            item.accessory = true;
            item.value = Item.sellPrice(copper: 10);
            item.rare = ItemRarityID.Purple;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            


        ;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddIngredient(ItemID.FrostsparkBoots, 1);
            recipe.AddIngredient(ItemID.FlurryBoots, 1);
            recipe.AddIngredient(ItemID.SailfishBoots, 1);
            recipe.AddIngredient(ItemID.LavaWaders, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}
