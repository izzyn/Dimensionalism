using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Chat;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Dimensionalism.Tiles
{
    public class GateTile : ModTile
    {
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = false;
			Main.tileLighted[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<TileEntities.GateTileEntity>().Hook_AfterPlacement, -1, 0, false);
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 18 };
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.addTile(Type);

			AddMapEntry(new Color(200, 0, 200), Language.GetText("Mods.Dimensionalism.Items.GateItem.DisplayName"));
			// Set other values here
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			Point16 origin = TileUtils.GetTileOrigin(i, j);
			ModContent.GetInstance<TileEntities.GateTileEntity>().Kill(origin.X, origin.Y);
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 64, ModContent.ItemType<Items.GateItem>());
		}

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;

            //Should your tile entity bring up a UI, this line is useful to prevent item slots from misbehaving
            Main.mouseRightRelease = false;

            //The following four (4) if-blocks are recommended to be used if your multitile opens a UI when right clicked:
            if (player.sign > -1)
            {
                SoundEngine.SoundPlayer.Play(SoundID.MenuClose);
                player.sign = -1;
                Main.editSign = false;
                Main.npcChatText = string.Empty;
            }
            if (Main.editChest)
            {
                SoundEngine.SoundPlayer.Play(SoundID.MenuClose);
                Main.editChest = false;
                Main.npcChatText = string.Empty;
            }
            if (player.editedChestName)
            {
                NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f, 0f, 0f, 0, 0, 0);
                player.editedChestName = false;
            }
            if (player.talkNPC > -1)
            {
                player.SetTalkNPC(-1);
                Main.npcChatCornerItem = 0;
                Main.npcChatText = string.Empty;
            }

            if (TileUtils.TryGetTileEntityAs(i, j, out TileEntities.GateTileEntity entity))
            {
                entity.Test();
            }
            else
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Bwomp"), Microsoft.Xna.Framework.Color.Red);
            }

            return base.RightClick( i, j);
        }
    }
}
