using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.DataStructures;

namespace Dimensionalism.Items
{
	public class TestEssance : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("d"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			DisplayName.SetDefault(Language.GetText("Mods.Dimensionalism.Items.TestEssance.DisplayName").Value);
			Tooltip.SetDefault(Language.GetText("Mods.Dimensionalism.Items.TestEssance.Tooltip").Value);

		}

		public override void SetDefaults()
		{
			Item.consumable = false;
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.rare = ItemRarityID.Purple;
			Item.autoReuse = false;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 2));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
		public override void UseAnimation(Player player)
		{
			base.UseAnimation(player);
			ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("hi"), Microsoft.Xna.Framework.Color.HotPink);

		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(9999);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.Register();
		}
	}
}
