using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria;
using Terraria.Localization;

namespace Dimensionalism.Items
{
	internal class GateItem : ModItem
	{
		public override void SetStaticDefaults()
		{
		 	DisplayName.SetDefault(Language.GetText("Mods.Dimensionalism.Items.GateItem.DisplayName").Value);
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.GateTile>();
			Item.width = 10;
			Item.height = 24;
			Item.value = 500;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TestEssance>(), 1);
			recipe.Register();
		}
	}
}