using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Chat;
using Terraria.Localization;
using SubworldLibrary;
using Terraria.Graphics.Effects;

namespace Dimensionalism.Items
{
	public class d : ModItem
	{
		bool active;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("d"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			//Tooltip.SetDefault("This is a basic modded sword.");
			DisplayName.SetDefault(Language.GetText("Mods.Dimensionalism.Items.d.DisplayName").Value);
			Tooltip.SetDefault(Language.GetText("Mods.Dimensionalism.Items.d.Tooltip").Value);
		}

		public override void SetDefaults()
		{
			Item.consumable = false;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 4;
			Item.knockBack = 6;
			Item.rare = 2;
			Item.UseSound = SoundID.Pixie;
			Item.autoReuse = false;
		}
        public override void UseAnimation(Player player)
        {
            base.UseAnimation(player);
			/*if(SubworldSystem.Current is Dimension)
            {
				SubworldSystem.Exit();
            }
            else
            {
				SubworldSystem.Enter<Dimension>();
			}*/
			if (Main.netMode != NetmodeID.Server)
            {
                if (!active)
                {
					active = true;
					Filters.Scene.Activate("Test");

				}
				else
                {
					active = false;
					Filters.Scene.Deactivate("Test");
                }				
			}
			ChatHelper.BroadcastChatMessage(Language.GetText("Mods.Dimensionalism.Items.GateItem.DisplayName").ToNetworkText(), Microsoft.Xna.Framework.Color.HotPink);

		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TestEssance>(), 1);
			recipe.Register();
		}
	}
}