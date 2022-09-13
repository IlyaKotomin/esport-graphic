using DuckGame;
using EsportGraphics.src.Core;
using EsportGraphics.src.Config;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace EsportGraphics.src
{
    internal class DEBUG : UpdateAndDraw
    {
        public override void Update()
        {
			if (Keyboard.Pressed(Keys.F10))
				Level.current = new WeaponBrowser();

            if (Keyboard.Pressed(Keys.F8))
                Config.ESOptions.Save();

            if (Keyboard.Pressed(Keys.F9))
                Config.ESOptions.Load();
        }
    }
	internal class WorkshopBrowser : Level
	{
		// Token: 0x060004C3 RID: 1219 RVA: 0x00038BD4 File Offset: 0x00036DD4
		public override void Initialize()
		{
			this._quackLoader = new SpriteMap("quackLoader", 31, 31, false);
			this._quackLoader.speed = 0.2f;
			this._quackLoader.CenterOrigin();
			this._quackLoader.scale = new Vec2(0.5f, 0.5f);
			this._font = new FancyBitmapFont("smallFont");
			Layer.HUD.camera.width *= 2f;
			Layer.HUD.camera.height *= 2f;
			this.groups.Add(new WorkshopBrowser.Group("Subscribed", WorkshopQueryFilterOrder.RankedByVote, Steam.user.id, null, new string[]
			{
				"Mod"
			}));
			this.groups.Add(new WorkshopBrowser.Group("Hats", WorkshopQueryFilterOrder.RankedByVote, 0UL, "hat", new string[]
			{
				"Mod"
			}));
			this.groups.Add(new WorkshopBrowser.Group("Mods", WorkshopQueryFilterOrder.RankedByVote, 0UL, null, new string[]
			{
				"Mod"
			}));
			this.groups.Add(new WorkshopBrowser.Group("Maps", WorkshopQueryFilterOrder.RankedByVote, 0UL, null, new string[]
			{
				"Map"
			}));
			base.Initialize();
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00038D20 File Offset: 0x00036F20
		public override void Update()
		{
			if (Input.Pressed("UP", "Any") && this._selectedGroup > 0)
			{
				SFX.Play("rainpop", 1f, 0f, 0f, false);
				this._selectedGroup--;
			}
			if (Input.Pressed("DOWN", "Any") && this._selectedGroup < this.groups.Count - 1)
			{
				SFX.Play("rainpop", 1f, 0f, 0f, false);
				this._selectedGroup++;
			}
			if (Input.Pressed("LEFT", "Any") && this._selectedItem > 0)
			{
				SFX.Play("rainpop", 1f, 0f, 0f, false);
				this._selectedItem--;
			}
			if (Input.Pressed("RIGHT", "Any") && this._selectedItem < 8)
			{
				SFX.Play("rainpop", 1f, 0f, 0f, false);
				this._selectedItem++;
			}
			if (this._selectedItem >= this.groups[this._selectedGroup].items.Count)
			{
				this._selectedItem = this.groups[this._selectedGroup].items.Count - 1;
			}
			if (this._selectedItem < 0)
			{
				this._selectedItem = 0;
			}
			if (Input.Pressed("SELECT", "Any"))
			{
				this._openedItem = this.groups[this._selectedGroup].items[this._selectedItem];
			}
			if (Input.Pressed("CANCEL", "Any"))
			{
				this._openedItem = null;
			}
			base.Update();
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00038EF4 File Offset: 0x000370F4
		public override void PostDrawLayer(Layer layer)
		{
			if (layer == Layer.HUD)
			{
				if (this._openedItem != null)
				{
					this._font.scale = new Vec2(1f, 1f);
					this._font.Draw(this._openedItem.name, new Vec2(16f, 16f), Color.White, 0.5f, false);
					if (this._openedItem.preview != null)
					{
						Graphics.Draw(this._openedItem.preview, 16f, 32f, 256f / (float)this._openedItem.preview.height * 0.5f, 256f / (float)this._openedItem.preview.height * 0.5f, 0.5f);
					}
					this._font.maxWidth = 300;
					this._font.Draw(this._openedItem.description, new Vec2(16f, 170f), Color.White, 0.5f, false);
					this._font.maxWidth = 0;
				}
				else
				{
					Vec2 groupDrawPos = new Vec2(32f, 16f);
					Vec2 itemSize = new Vec2(64f, 64f);
					int groupIndex = 0;
					foreach (WorkshopBrowser.Group g in this.groups)
					{
						Vec2 drawPos = groupDrawPos + new Vec2(0f, 12f);
						this._font.scale = new Vec2(1f, 1f);
						this._font.Draw(g.name, groupDrawPos, Color.White, 0.5f, false);
						int itemIndex = 0;
						foreach (WorkshopBrowser.Item i in g.items)
						{
							Vec2 extraOffset = new Vec2(0f);
							float sizeMul = 0.25f;
							float baseDepth = 0.1f;
							if (groupIndex == this._selectedGroup && itemIndex == this._selectedItem)
							{
								extraOffset = new Vec2(-4f, -4f);
								Graphics.DrawRect(drawPos + extraOffset + new Vec2(-1f, -1f), drawPos + extraOffset + itemSize + new Vec2(8f, 8f) + new Vec2(1f, 1f), Color.White, 0.5f, false, 2f);
								sizeMul = 0.28f;
								baseDepth = 0.5f;
							}
							if (i.preview != null)
							{
								float scaleFactor = 256f / (float)i.preview.height;
								float xCrop = (float)(i.preview.width / 2 - i.preview.height / 2);
								Graphics.Draw(i.preview, drawPos + extraOffset, new Rectangle?(new Rectangle(xCrop, 0f, (float)i.preview.height, (float)i.preview.height)), Color.White, 0f, Vec2.Zero, new Vec2(scaleFactor * sizeMul, scaleFactor * sizeMul), SpriteEffects.None, baseDepth);
							}
							else
							{
								Graphics.Draw(this._quackLoader, drawPos.x + itemSize.x / 2f, drawPos.y + itemSize.y / 2f);
							}
							this._font.scale = new Vec2(0.5f, 0.5f);
							string drawName = i.name.Reduced(21);
							this._font.Draw(drawName, drawPos + extraOffset + new Vec2(2f, 2f), Color.White, baseDepth + 0.1f, false);
							Graphics.DrawRect(drawPos + extraOffset + new Vec2(1f, 1f), drawPos + extraOffset + new Vec2(this._font.GetWidth(drawName, false) + 6f, 8f), Color.Black * 0.7f, baseDepth + 0.05f, true, 1f);
							drawPos.x += itemSize.x;
							if (drawPos.x + itemSize.x > Layer.HUD.width)
							{
								break;
							}
							itemIndex++;
						}
						groupIndex++;
						groupDrawPos.y += 84f;
					}
				}
			}
			base.PostDrawLayer(layer);
		}

		// Token: 0x0400052B RID: 1323
		private List<WorkshopBrowser.Group> groups = new List<WorkshopBrowser.Group>();

		// Token: 0x0400052C RID: 1324
		private SpriteMap _quackLoader;

		// Token: 0x0400052D RID: 1325
		private FancyBitmapFont _font;

		// Token: 0x0400052E RID: 1326
		private int _selectedGroup;

		// Token: 0x0400052F RID: 1327
		private int _selectedItem;

		// Token: 0x04000530 RID: 1328
		private WorkshopBrowser.Item _openedItem;

		// Token: 0x02000646 RID: 1606
		private class Item
		{
			// Token: 0x170008DD RID: 2269
			// (get) Token: 0x06002F72 RID: 12146 RVA: 0x001D76BB File Offset: 0x001D58BB
			public string name
			{
				get
				{
					return this.details.title;
				}
			}

			// Token: 0x170008DE RID: 2270
			// (get) Token: 0x06002F73 RID: 12147 RVA: 0x001D76C8 File Offset: 0x001D58C8
			public Tex2D preview
			{
				get
				{
					if (this._preview == null && this._previewData != null)
					{
						this._preview = new Tex2D(this._previewData.width, this._previewData.height);
						this._preview.SetData<int>(this._previewData.data);
					}
					return this._preview;
				}
			}

			// Token: 0x06002F74 RID: 12148 RVA: 0x001D7724 File Offset: 0x001D5924
			public static WorkshopBrowser.Item Get(ulong pID)
			{
				WorkshopBrowser.Item item = null;
				if (!WorkshopBrowser.Item._items.TryGetValue(pID, out item))
				{
					item = (WorkshopBrowser.Item._items[pID] = new WorkshopBrowser.Item());
				}
				return item;
			}

			// Token: 0x06002F75 RID: 12149 RVA: 0x00002688 File Offset: 0x00000888
			internal Item()
			{
			}

			// Token: 0x04002C9E RID: 11422
			public string description;

			// Token: 0x04002C9F RID: 11423
			public WorkshopQueryResultDetails details;

			// Token: 0x04002CA0 RID: 11424
			private Tex2D _preview;

			// Token: 0x04002CA1 RID: 11425
			public PNGData _previewData;

			// Token: 0x04002CA2 RID: 11426
			private static Dictionary<ulong, WorkshopBrowser.Item> _items = new Dictionary<ulong, WorkshopBrowser.Item>();
		}

		// Token: 0x02000647 RID: 1607
		private class Group
		{
			// Token: 0x06002F77 RID: 12151 RVA: 0x001D7764 File Offset: 0x001D5964
			public Group(string pName, WorkshopQueryFilterOrder pOrder, ulong pUserID, string pSearchText, params string[] pTags)
			{
				this.name = pName;
				this.orderMode = pOrder;
				this.tags = pTags.ToList<string>();
				this.searchText = pSearchText;
				this.userID = pUserID;
				this.OpenPage(0);
			}

			// Token: 0x06002F78 RID: 12152 RVA: 0x001D77B4 File Offset: 0x001D59B4
			public void OpenPage(int pIndex)
			{
				if (this.userID != 0UL)
				{
					this._currentQuery = Steam.CreateQueryUser(this.userID, WorkshopList.Subscribed, WorkshopType.Items, WorkshopSortOrder.SubscriptionDateDesc);
				}
				else
				{
					this._currentQuery = Steam.CreateQueryAll(this.orderMode, WorkshopType.Items);
					(this._currentQuery as WorkshopQueryAll).searchText = this.searchText;
				}
				foreach (string s in this.tags)
				{
					this._currentQuery.requiredTags.Add(s);
				}
				this._currentQuery.justOnePage = true;
				this._currentQuery.QueryFinished += this.FinishedQuery;
				this._currentQuery.ResultFetched += this.Fetched;
				this._currentQuery.fetchedData = (WorkshopQueryData.AdditionalPreviews | WorkshopQueryData.PreviewURL);
				this._currentQuery.Request();
			}

			// Token: 0x06002F79 RID: 12153 RVA: 0x001D78AC File Offset: 0x001D5AAC
			private void Fetched(object sender, WorkshopQueryResult result)
			{
				WorkshopBrowser.Item item = WorkshopBrowser.Item.Get(result.details.publishedFile.id);
				if (item.preview == null)
				{
					string previewUrl = result.previewURL;
					if (string.IsNullOrEmpty(previewUrl) && result.additionalPreviews != null)
					{
						foreach (WorkshopQueryResultAdditionalPreview p in result.additionalPreviews)
						{
							if (p.isImage)
							{
								previewUrl = p.urlOrVideoID;
								break;
							}
						}
					}
					if (!string.IsNullOrEmpty(previewUrl))
					{
						new Task(delegate ()
						{
							using (WebClient client = new WebClient())
							{
								byte[] data = client.DownloadData(new Uri(previewUrl));
								item._previewData = ContentPack.LoadPNGDataFromStream(new MemoryStream(data), true);
							}
						}).Start();
					}
				}
				item.details = result.details;
				this.items.Add(item);
			}

			// Token: 0x06002F7A RID: 12154 RVA: 0x00004940 File Offset: 0x00002B40
			private void FinishedQuery(object sender)
			{
			}

			// Token: 0x04002CA3 RID: 11427
			public string name;

			// Token: 0x04002CA4 RID: 11428
			public List<WorkshopBrowser.Item> items = new List<WorkshopBrowser.Item>();

			// Token: 0x04002CA5 RID: 11429
			public List<string> tags;

			// Token: 0x04002CA6 RID: 11430
			public string searchText;

			// Token: 0x04002CA7 RID: 11431
			public ulong userID;

			// Token: 0x04002CA8 RID: 11432
			public WorkshopQueryFilterOrder orderMode;

			// Token: 0x04002CA9 RID: 11433
			private WorkshopQueryUGC _currentQuery;
		}
	}
}
