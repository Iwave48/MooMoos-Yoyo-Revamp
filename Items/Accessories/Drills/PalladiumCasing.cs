using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Drills
{
    public class PalladiumCasing : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Palladium Drill Casing");
            // Tooltip.SetDefault("Allows Yoyos to drill through blocks\nHold right click to drill\n[c/BCFFF0:130% pickaxe power]");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 1, silver: 44);
        }
        public override bool? PrefixChance(int pre, Terraria.Utilities.UnifiedRandom rand)
        {
            return false;
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return modded && LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<DrillSlot>().Type;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.palladiumDrill = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PalladiumBar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}