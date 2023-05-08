using CombinationsMod.Items.Bars;
using CombinationsMod.Items.Misc;
using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Rings
{
    public class TrepidationRing : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ring of Trepidation");
            // Tooltip.SetDefault("[c/6EAE6E:+10% base yoyo damage]");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 12, 55, 0);
        }
        public override bool? PrefixChance(int pre, Terraria.Utilities.UnifiedRandom rand)
        {
            return false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (!hideVisual)
            {
                modPlayer.trepidationRing = true;
            }
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return modded && (LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<RingSlot>().Type ||
                LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<RingSlot2>().Type);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(); 
            recipe.AddIngredient(ModContent.ItemType<BrokenHeroRing>());
            recipe.AddIngredient(ModContent.ItemType<EclipseBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<FrightBar>(), 10);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
    }
}