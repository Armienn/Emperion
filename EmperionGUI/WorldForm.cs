using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Emperion;

namespace EmperionGUI
{
	public partial class WorldForm : Form
	{
		public Verden world = new Verden(20, 20);
		public int selx = -1;
		public int sely = -1;
		public int rødhed = 0;
		public int rødmulti = 64;
		public bool vishøjde = true;
		public bool vishøjdetekst = true;

		private Thread threadgen;
		private Thread threadwaitgen;

		public WorldForm() {
			InitializeComponent();

			MapControl kort = new MapControl(this);
			panelkort.Controls.Add(kort);
			kort.Dock = DockStyle.Fill;
			kort.Show();
		}

		protected override void OnPaint(PaintEventArgs e) {
			labelStatus.Text = world.Status;
			labelMåned.Text = "Måned: " + world.Måned;
		}

		private void buttonGenerate_Click(object sender, EventArgs e) {
			int seed = 0;
			int size = 20;

			if (buttonGenerer.Text == "Stop") {
				threadgen.Abort();
				threadwaitgen.Abort();
				buttonGenerer.Text = "Generér";
			}
			else {
				try {
					seed = int.Parse(textBoxSeed.Text);
				}
				catch { }
				try {
					size = int.Parse(textBoxSize.Text);
				}
				catch { }

				if (seed == 0) {
					world = new Verden(size, size);
				}
				else {
					world = new Verden(size, size, seed);
				}

				threadgen = new Thread(() => world.GenererVerden());
				threadgen.Start();

				threadwaitgen = new Thread(() => WaitForGeneration());
				threadwaitgen.Start();
				buttonMåned.Enabled = false;
				buttonRefresh.Enabled = false;
			}
		}

		private void WaitForGeneration() {
			SetText(buttonGenerer, "Stop");
			while (world.Status != "Klar") {
				SetText(labelStatus, world.Status);
				Thread.Sleep(100);
			}
			SetText(buttonGenerer, "Generér");
			SetText(labelStatus, world.Status);
			SetEnabled(buttonMåned, true);
			SetEnabled(buttonRefresh, true);
			ThreadsafeRefresh();
		}

		delegate void SetTextCallback(Control control, string text);

		private void SetText(Control control, string text) {
			if (control.InvokeRequired) {
				SetTextCallback d = new SetTextCallback(SetText);
				this.Invoke(d, new object[] { control, text });
			}
			else {
				control.Text = text;
			}
		}

		delegate void SetRefreshCallback();

		private void ThreadsafeRefresh() {
			if (this.InvokeRequired) {
				SetRefreshCallback d = new SetRefreshCallback(ThreadsafeRefresh);
				this.Invoke(d, new object[] {  });
			}
			else {
				this.Refresh();
			}
		}

		delegate void SetEnabledCallback(Control control, bool en);

		private void SetEnabled(Control control, bool en) {
			if (control.InvokeRequired) {
				SetEnabledCallback d = new SetEnabledCallback(SetEnabled);
				this.Invoke(d, new object[] { control, en });
			}
			else {
				control.Enabled = en;
			}
		}

		public void LoadValuesToText(object sender, EventArgs e) {
			int a = selx;
			int b = sely;
			if (a < 0 || b < 0 || a >= world.X || b >= world.Y || world.Status != "Klar") {
				return;
			}
			labelX.Text = "x: " + selx;
			labelY.Text = "y: " + sely;
			labelHøjde.Text = "Højde: " + world[a, b].Højde;
			labelVandhøjde.Text = "Vandhøjde: " + world[a, b].Vandhøjde;
			labelUjævn.Text = "Ujævnhed: " + world[a, b].Ujævnhed;
			labelTerræn.Text = "Terræn: " + world[a, b].Terræn.ToString();
			labelSkov.Text = "Samlet skov: " + (int)(100*(world[a, b].Tropeskov + world[a, b].Tempskov + world[a, b].Nåleskov));
			labelTrop.Text = "Tropisk: " + (int)(100*world[a, b].Tropeskov);
			labelTemp.Text = "Tempereret: " + (int)(100*world[a, b].Tempskov);
			labelNål.Text = "Nål: " + (int)(100*world[a, b].Nåleskov);
			labelTemperatur.Text = "Temperatur: " + (int)world[a, b].Temperatur;
			labelSky.Text = "Skyer: " + (int)(100 * world[a, b].Skyer);
			labelFugt.Text = "Fugtighed: " + (int)(100 * world[a, b].Fugtighed);
			labelVand.Text = "Vandmængde: " + (int)(100 * world[a, b].Vandmængde);
			labelNæring.Text = "Næring: " + (int)(100 * world[a, b].Næring);
			labelSmåvildt.Text = "Småvildt: " + (int)world[a, b].Småvildt;
			labelPlanteæder.Text = "Planteædere: " + (int)world[a, b].Planteædere;
			labelRovdyr.Text = "Rovdyr: " + (int)world[a, b].Rovdyr;

			label5.Text = "";
			for (int i = 0; i < world[a, b].Højde; i++) {
				label5.Text += "" + i + " " +
					(int)(world[a, b][i].diamant * 1000) + " " +
					(int)(world[a, b][i].guld * 1000) + " " +
					(int)(world[a, b][i].sølv * 1000) + " " +
					(int)(world[a, b][i].jern * 1000) + " " +
					(int)(world[a, b][i].kobber * 1000) + " " +
					(int)(world[a, b][i].bly * 1000) + " " +
					(int)(world[a, b][i].tin * 1000) + " \n";
			}
			this.Refresh();
		}

		private void buttonRefresh_Click(object sender, EventArgs e) {
			labelStatus.Text = world.Status;
			labelMåned.Text = "Måned: " + world.Måned;
			this.Refresh();
		}

		private void comboBoxRødhed_SelectedIndexChanged(object sender, EventArgs e) {
			rødhed = comboBoxRødhed.SelectedIndex;
			labelStatus.Text = world.Status;
			labelMåned.Text = "Måned: " + world.Måned;
			this.Refresh();
		}

		private void buttonMåned_Click(object sender, EventArgs e) {
			if (world.Status != "Klar") {
				return;
			}
			world.SimulerNatur();
			labelStatus.Text = world.Status;
			labelMåned.Text = "Måned: " + world.Måned;
			this.Refresh();
		}

		private void checkBoxAltitude_CheckedChanged(object sender, EventArgs e) {
			vishøjde = checkBoxAltitude.Checked;
			this.Refresh();
		}

		private void trackBar1Multi_Scroll(object sender, EventArgs e) {
			try {
				rødmulti = trackBar1Multi.Value;
			}
			catch { }
			this.Refresh();
		}

		private void checkBoxHøjdeText_CheckedChanged(object sender, EventArgs e) {
			vishøjdetekst = checkBoxHøjdeText.Checked;
			this.Refresh();
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void controllerToolStripMenuItem_Click(object sender, EventArgs e) {
			panelController.Visible = !panelController.Visible;
		}

		private void hexBoxToolStripMenuItem_Click(object sender, EventArgs e) {
			panelHex.Visible = !panelHex.Visible;
		}

		private void folkBoxToolStripMenuItem_Click(object sender, EventArgs e) {
			panelFolk.Visible = !panelFolk.Visible;
		}
	}
}
