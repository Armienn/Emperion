using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emperion;

namespace EmperionGUI
{
	public partial class MapControl : UserControl
	{
		WorldForm main;
		public float HexHeight {
			get {
				return height;
			}
			set {
				height = value;
				width = (float)0.86602540378 * height; //sqrt(3)/2 * height
			}
		}
		float height = 10;
		float width = (float)8.6602540378;
		int offsetx = 0;
		int offsety = 0;
		int mx = 0;
		int my = 0;
		bool dragging = false;

		public MapControl(WorldForm main) {
			this.main = main;
			InitializeComponent();
			this.MouseDown += MyMouseDown;
			this.MouseUp += MyMouseUp;
			this.MouseLeave += MyMouseUp;
			this.MouseMove += MyMouseMove;
			this.MouseWheel += MyMouseRoll;
			this.MouseEnter += MyMouseEnter;
			this.MouseClick += MyMouseClick;
			this.DoubleBuffered = true;
		}

		

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			Pen pen = new Pen(Color.Black);
			Verden world = main.world;
			
			if (world.Status != "Klar")
				return;

			int startx = (int)((- offsetx - (width * 2)) / width);
			int endx = (int)((- offsetx + this.Size.Width + width) / width);

			for (int j = 0; j < world.Y; j++) {
				for (int i = startx - (j / 2); i <= endx - (j / 2); i++) {
					int hx = i;
					int hy = world.Y - 1 - j;
					while (hx < 0) {
						hx += world.X;
					}
					while (hx >= world.X) {
						hx -= world.X;
					}

					float a = (i * width + j * width / 2) + offsetx;
					float b = (j * 3 * height / 4) + offsety;

					System.Drawing.PointF[] hexagon = GetHexagon(a, b);

					pen.Color = TileColor(hx, hy);

					g.FillPolygon(pen.Brush, hexagon);
					//pen.Color = Color.Black;
					//g.DrawPolygon(pen, hexagon);

					TileInfo(hx, hy, a, b, g);
				}
			}
		}

		private System.Drawing.PointF[] GetHexagon(float x, float y) {
			System.Drawing.PointF[] hexagon = new System.Drawing.PointF[6];
			hexagon[0] = new System.Drawing.PointF(x + width / 2, y);
			hexagon[1] = new System.Drawing.PointF(x + width, y + height / 4);
			hexagon[2] = new System.Drawing.PointF(x + width, y + 3 * height / 4);
			hexagon[3] = new System.Drawing.PointF(x + width / 2, y + height);
			hexagon[4] = new System.Drawing.PointF(x, y + 3 * height / 4);
			hexagon[5] = new System.Drawing.PointF(x, y + height / 4);
			return hexagon;
		}

		private void TileInfo(int i, int j, float x, float y, Graphics g) {
			if (HexHeight > 30) {

				string text = "";
				if (main.vishøjdetekst) {
					text = main.world[i, j].Højde.ToString() + ":" + main.world[i, j].Vandhøjde;
				}
				else {
					text = (int)(main.world[i, j].Fugtighed ) + ":" + (int)(main.world[i, j].Vandmængde );
				}
				g.DrawString(text, new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular),
					new Pen(Color.Black).Brush, x, y + height / 4);
			}
			if (HexHeight > 50) {
				float mx = x + height / 2;
				float my = y + width / 2;
				int flodret = main.world[i, j].Flodretning;
				Vector flod = flodret == -1 ? new Vector(0, 0) : Tools.GetUnityVector(Tools.DirectionFromNumber(flodret));
				Vector vind = main.world[i, j].vind;
				string text = "t" + (int)main.world[i, j].Temperatur + " f" + (int)(main.world[i, j].Fugtighed*10) + " v" + (int)(vind.Magnitude * 10);
				g.DrawString(text, new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular),
					new Pen(Color.Black).Brush, x, y + 20 + height / 4);
				g.DrawLine(new Pen(Color.Red,2), mx, my,
					vind.x*40 + mx,
					-vind.y*40 + my);
				g.DrawLine(new Pen(Color.Blue, 2), mx, my,
					mx + flod.x * 15,
					my - flod.y * 15);
			}
		}

		private Color TileColor(int x, int y) {
			/*int p = world.pladekort[i, world.Y - 1 - j];
			pen.Color = Color.FromArgb((p * 12), (p * 12), (p * 12));
			*/
			Color result = Color.White;
			int rødhed = 0;
			int grønhed = 55;
			switch (main.rødhed) {
				case 0:
					rødhed = 0;
					break;
				case 1: //terræn
					switch (main.world[x, y].Terræn) {
						case Terræn.Jord:
							rødhed = 0;
							break;
						case Terræn.Grus:
							rødhed = 100;
							break;
						case Terræn.Klippe:
							rødhed = 200;
							break;
						case Terræn.Vulkansk:
							rødhed = 255;
							break;
					}
					break;
				case 2: //ujævnhed
					rødhed = main.world[x, y].Ujævnhed * 60;
					break;
				case 3: //temperatur
					double tempe = main.world[x, y].Temperatur;
					if (tempe > 40) {
						rødhed = 255;
					}
					else if (tempe > 30) {
						rødhed = 210;
					}
					else if (tempe > 20) {
						rødhed = 160;
					}
					else if (tempe > 10) {
						rødhed = 120;
					}
					else if (tempe > 0) {
						rødhed = 64;
					}
					else if (tempe > -10) {
						rødhed = 32;
					}
					else {
						rødhed = 0;
					}
					break;
				case 4: //skyer
					rødhed = (int)(main.world[x, y].Skyer * main.rødmulti);
					break;
				case 5: //fugtighed
					rødhed = (int)(main.world[x, y].Fugtighed * main.rødmulti);
					break;
				case 6: //vandmængde
					rødhed = (int)(main.world[x, y].Vandmængde * main.rødmulti);
					break;
				case 7: //trope
					rødhed = (int)(main.world[x, y].Tropeskov*255);
					break;
				case 8: //temp
					rødhed = (int)(main.world[x, y].Tempskov * 255);
					break;
				case 9: //nål
					rødhed = (int)(main.world[x, y].Nåleskov * 255);
					break;
				case 10: //næring
					rødhed = (int)(main.world[x, y].Næring * 255);
					break;
				default:
					rødhed = 0;
					break;
			}
			if (rødhed > 255) {
				rødhed = 255;
			}
			if (rødhed < 0) {
				rødhed = 0;
			}

			if (main.vishøjde) {
				int h = main.world[x, y].Højde;
				if (h > 32)
				h = 32;
				grønhed = (h * 8) - 1;
			}
			
			int v = main.world[x, y].Vandhøjde;

			
			result = Color.FromArgb(rødhed, grønhed, v > 0 ? 255 : 0);
			if (main.selx == x && main.sely == y) {
				result = Color.FromArgb(255, 255, 255);
			}
			return result;
		}

		#region MouseEventHandlers

		private void MyMouseDown(Object sender, MouseEventArgs args) {
			dragging = true;
			mx = args.X;
			my = args.Y;
		}

		private void MyMouseUp(object sender, EventArgs e) {
			dragging = false;
		}

		private void MyMouseMove(Object sender, MouseEventArgs args) {
			if (dragging) {
				offsetx -= mx - args.X;
				offsety -= my - args.Y;
				mx = args.X;
				my = args.Y;
			}
			this.Refresh();
		}

		private void MyMouseRoll(Object sender, MouseEventArgs args) {
			int a = args.Delta;
			if (a > 0) {
				offsetx = (int)((offsetx - (float)this.Width / 2) * 1.5) + this.Width / 2;
				offsety = (int)((offsety - (float)this.Height / 2) * 1.5) + this.Height / 2;
				HexHeight *= (float)1.5;
			}
			else if (a < 0) {
				HexHeight /= (float)1.5;
				offsetx = (int)((offsetx - (float)this.Width / 2) / 1.5) + this.Width / 2;
				offsety = (int)((offsety - (float)this.Height / 2) / 1.5) + this.Height / 2;
			}
			this.Refresh();
		}

		private void MyMouseEnter(Object sender, EventArgs args) {
			this.Focus();
		}

		private void MyMouseClick(Object sender, MouseEventArgs args) {
			float normalizedx = args.X - offsetx;
			float normalizedy = args.Y - offsety;
			normalizedx -= normalizedx % ((height*3)/4);
			normalizedy -= normalizedy % width;

			int j = (int)Math.Round((normalizedy * 4) / (height * 3));
			int i = (int)Math.Round(((normalizedx) / width) - j / 2);
			int X = main.world.X;
			int Y = main.world.Y;
			j = Y - 1 - j;
			if (j < 0) {
				j = -1;
				return;
			}
			else if (j >= Y) {
				j = -1;
				return;
			}
			while (i < 0) {
				i += X;
			}
			while (i >= X) {
				i -= X;
			}
			main.selx = i;
			main.sely = j;
			main.LoadValuesToText(null, null);
			//this.Refresh();
		}

		#endregion
	}
}
