namespace EmperionGUI
{
	partial class WorldForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.panelController = new System.Windows.Forms.Panel();
			this.labelNæring = new System.Windows.Forms.Label();
			this.labelRovdyr = new System.Windows.Forms.Label();
			this.labelPlanteæder = new System.Windows.Forms.Label();
			this.labelSmåvildt = new System.Windows.Forms.Label();
			this.labelTemperatur = new System.Windows.Forms.Label();
			this.labelVand = new System.Windows.Forms.Label();
			this.labelFugt = new System.Windows.Forms.Label();
			this.labelSky = new System.Windows.Forms.Label();
			this.labelY = new System.Windows.Forms.Label();
			this.labelNål = new System.Windows.Forms.Label();
			this.labelTemp = new System.Windows.Forms.Label();
			this.labelSkov = new System.Windows.Forms.Label();
			this.labelTrop = new System.Windows.Forms.Label();
			this.labelVandhøjde = new System.Windows.Forms.Label();
			this.checkBoxHøjdeText = new System.Windows.Forms.CheckBox();
			this.trackBar1Multi = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.labelMåned = new System.Windows.Forms.Label();
			this.checkBoxAltitude = new System.Windows.Forms.CheckBox();
			this.buttonMåned = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxSize = new System.Windows.Forms.TextBox();
			this.textBoxSeed = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxRødhed = new System.Windows.Forms.ComboBox();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.labelUjævn = new System.Windows.Forms.Label();
			this.labelTerræn = new System.Windows.Forms.Label();
			this.labelHøjde = new System.Windows.Forms.Label();
			this.buttonGenerer = new System.Windows.Forms.Button();
			this.labelStatus = new System.Windows.Forms.Label();
			this.labelX = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.filerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.visToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.controllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hexBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folkBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelkort = new System.Windows.Forms.Panel();
			this.panelHex = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.panelFolk = new System.Windows.Forms.Panel();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panelController.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1Multi)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.panelHex.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelController
			// 
			this.panelController.Controls.Add(this.labelNæring);
			this.panelController.Controls.Add(this.labelRovdyr);
			this.panelController.Controls.Add(this.labelPlanteæder);
			this.panelController.Controls.Add(this.labelSmåvildt);
			this.panelController.Controls.Add(this.labelTemperatur);
			this.panelController.Controls.Add(this.labelVand);
			this.panelController.Controls.Add(this.labelFugt);
			this.panelController.Controls.Add(this.labelSky);
			this.panelController.Controls.Add(this.labelY);
			this.panelController.Controls.Add(this.labelNål);
			this.panelController.Controls.Add(this.labelTemp);
			this.panelController.Controls.Add(this.labelSkov);
			this.panelController.Controls.Add(this.labelTrop);
			this.panelController.Controls.Add(this.labelVandhøjde);
			this.panelController.Controls.Add(this.checkBoxHøjdeText);
			this.panelController.Controls.Add(this.trackBar1Multi);
			this.panelController.Controls.Add(this.label4);
			this.panelController.Controls.Add(this.labelMåned);
			this.panelController.Controls.Add(this.checkBoxAltitude);
			this.panelController.Controls.Add(this.buttonMåned);
			this.panelController.Controls.Add(this.label2);
			this.panelController.Controls.Add(this.textBoxSize);
			this.panelController.Controls.Add(this.textBoxSeed);
			this.panelController.Controls.Add(this.label1);
			this.panelController.Controls.Add(this.comboBoxRødhed);
			this.panelController.Controls.Add(this.buttonRefresh);
			this.panelController.Controls.Add(this.labelUjævn);
			this.panelController.Controls.Add(this.labelTerræn);
			this.panelController.Controls.Add(this.labelHøjde);
			this.panelController.Controls.Add(this.buttonGenerer);
			this.panelController.Controls.Add(this.labelStatus);
			this.panelController.Controls.Add(this.labelX);
			this.panelController.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelController.Location = new System.Drawing.Point(645, 0);
			this.panelController.Name = "panelController";
			this.panelController.Size = new System.Drawing.Size(139, 562);
			this.panelController.TabIndex = 0;
			// 
			// labelNæring
			// 
			this.labelNæring.AutoSize = true;
			this.labelNæring.Location = new System.Drawing.Point(6, 337);
			this.labelNæring.Name = "labelNæring";
			this.labelNæring.Size = new System.Drawing.Size(48, 13);
			this.labelNæring.TabIndex = 43;
			this.labelNæring.Text = "Næring: ";
			// 
			// labelRovdyr
			// 
			this.labelRovdyr.AutoSize = true;
			this.labelRovdyr.Location = new System.Drawing.Point(6, 376);
			this.labelRovdyr.Name = "labelRovdyr";
			this.labelRovdyr.Size = new System.Drawing.Size(47, 13);
			this.labelRovdyr.TabIndex = 42;
			this.labelRovdyr.Text = "Rovdyr: ";
			// 
			// labelPlanteæder
			// 
			this.labelPlanteæder.AutoSize = true;
			this.labelPlanteæder.Location = new System.Drawing.Point(6, 363);
			this.labelPlanteæder.Name = "labelPlanteæder";
			this.labelPlanteæder.Size = new System.Drawing.Size(74, 13);
			this.labelPlanteæder.TabIndex = 41;
			this.labelPlanteæder.Text = "Planteædere: ";
			// 
			// labelSmåvildt
			// 
			this.labelSmåvildt.AutoSize = true;
			this.labelSmåvildt.Location = new System.Drawing.Point(6, 350);
			this.labelSmåvildt.Name = "labelSmåvildt";
			this.labelSmåvildt.Size = new System.Drawing.Size(53, 13);
			this.labelSmåvildt.TabIndex = 40;
			this.labelSmåvildt.Text = "Småvildt: ";
			// 
			// labelTemperatur
			// 
			this.labelTemperatur.AutoSize = true;
			this.labelTemperatur.Location = new System.Drawing.Point(6, 276);
			this.labelTemperatur.Name = "labelTemperatur";
			this.labelTemperatur.Size = new System.Drawing.Size(64, 13);
			this.labelTemperatur.TabIndex = 39;
			this.labelTemperatur.Text = "Temperatur:";
			// 
			// labelVand
			// 
			this.labelVand.AutoSize = true;
			this.labelVand.Location = new System.Drawing.Point(6, 315);
			this.labelVand.Name = "labelVand";
			this.labelVand.Size = new System.Drawing.Size(77, 13);
			this.labelVand.TabIndex = 38;
			this.labelVand.Text = "Vandmængde:";
			// 
			// labelFugt
			// 
			this.labelFugt.AutoSize = true;
			this.labelFugt.Location = new System.Drawing.Point(6, 302);
			this.labelFugt.Name = "labelFugt";
			this.labelFugt.Size = new System.Drawing.Size(57, 13);
			this.labelFugt.TabIndex = 37;
			this.labelFugt.Text = "Fugtighed:";
			// 
			// labelSky
			// 
			this.labelSky.AutoSize = true;
			this.labelSky.Location = new System.Drawing.Point(6, 289);
			this.labelSky.Name = "labelSky";
			this.labelSky.Size = new System.Drawing.Size(37, 13);
			this.labelSky.TabIndex = 36;
			this.labelSky.Text = "Skyer:";
			// 
			// labelY
			// 
			this.labelY.AutoSize = true;
			this.labelY.Location = new System.Drawing.Point(36, 137);
			this.labelY.Name = "labelY";
			this.labelY.Size = new System.Drawing.Size(15, 13);
			this.labelY.TabIndex = 0;
			this.labelY.Text = "y:";
			// 
			// labelNål
			// 
			this.labelNål.AutoSize = true;
			this.labelNål.Location = new System.Drawing.Point(6, 254);
			this.labelNål.Name = "labelNål";
			this.labelNål.Size = new System.Drawing.Size(26, 13);
			this.labelNål.TabIndex = 35;
			this.labelNål.Text = "Nål:";
			// 
			// labelTemp
			// 
			this.labelTemp.AutoSize = true;
			this.labelTemp.Location = new System.Drawing.Point(6, 241);
			this.labelTemp.Name = "labelTemp";
			this.labelTemp.Size = new System.Drawing.Size(64, 13);
			this.labelTemp.TabIndex = 34;
			this.labelTemp.Text = "Tempereret:";
			// 
			// labelSkov
			// 
			this.labelSkov.AutoSize = true;
			this.labelSkov.Location = new System.Drawing.Point(6, 215);
			this.labelSkov.Name = "labelSkov";
			this.labelSkov.Size = new System.Drawing.Size(68, 13);
			this.labelSkov.TabIndex = 33;
			this.labelSkov.Text = "Samlet skov:";
			// 
			// labelTrop
			// 
			this.labelTrop.AutoSize = true;
			this.labelTrop.Location = new System.Drawing.Point(6, 228);
			this.labelTrop.Name = "labelTrop";
			this.labelTrop.Size = new System.Drawing.Size(45, 13);
			this.labelTrop.TabIndex = 32;
			this.labelTrop.Text = "Tropisk:";
			// 
			// labelVandhøjde
			// 
			this.labelVandhøjde.AutoSize = true;
			this.labelVandhøjde.Location = new System.Drawing.Point(6, 167);
			this.labelVandhøjde.Name = "labelVandhøjde";
			this.labelVandhøjde.Size = new System.Drawing.Size(61, 13);
			this.labelVandhøjde.TabIndex = 31;
			this.labelVandhøjde.Text = "Vandhøjde:";
			// 
			// checkBoxHøjdeText
			// 
			this.checkBoxHøjdeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxHøjdeText.AutoSize = true;
			this.checkBoxHøjdeText.Checked = true;
			this.checkBoxHøjdeText.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxHøjdeText.Location = new System.Drawing.Point(67, 486);
			this.checkBoxHøjdeText.Name = "checkBoxHøjdeText";
			this.checkBoxHøjdeText.Size = new System.Drawing.Size(53, 17);
			this.checkBoxHøjdeText.TabIndex = 30;
			this.checkBoxHøjdeText.Text = "Tekst";
			this.checkBoxHøjdeText.UseVisualStyleBackColor = true;
			this.checkBoxHøjdeText.CheckedChanged += new System.EventHandler(this.checkBoxHøjdeText_CheckedChanged);
			// 
			// trackBar1Multi
			// 
			this.trackBar1Multi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1Multi.LargeChange = 16;
			this.trackBar1Multi.Location = new System.Drawing.Point(9, 435);
			this.trackBar1Multi.Maximum = 255;
			this.trackBar1Multi.Name = "trackBar1Multi";
			this.trackBar1Multi.Size = new System.Drawing.Size(116, 45);
			this.trackBar1Multi.TabIndex = 29;
			this.trackBar1Multi.TickFrequency = 32;
			this.trackBar1Multi.Value = 64;
			this.trackBar1Multi.Scroll += new System.EventHandler(this.trackBar1Multi_Scroll);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 419);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 28;
			this.label4.Text = "Multiplier";
			// 
			// labelMåned
			// 
			this.labelMåned.AutoSize = true;
			this.labelMåned.Location = new System.Drawing.Point(77, 137);
			this.labelMåned.Name = "labelMåned";
			this.labelMåned.Size = new System.Drawing.Size(43, 13);
			this.labelMåned.TabIndex = 27;
			this.labelMåned.Text = "Måned:";
			// 
			// checkBoxAltitude
			// 
			this.checkBoxAltitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxAltitude.AutoSize = true;
			this.checkBoxAltitude.Checked = true;
			this.checkBoxAltitude.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxAltitude.Location = new System.Drawing.Point(7, 486);
			this.checkBoxAltitude.Name = "checkBoxAltitude";
			this.checkBoxAltitude.Size = new System.Drawing.Size(54, 17);
			this.checkBoxAltitude.TabIndex = 26;
			this.checkBoxAltitude.Text = "Højde";
			this.checkBoxAltitude.UseVisualStyleBackColor = true;
			this.checkBoxAltitude.CheckedChanged += new System.EventHandler(this.checkBoxAltitude_CheckedChanged);
			// 
			// buttonMåned
			// 
			this.buttonMåned.Enabled = false;
			this.buttonMåned.Location = new System.Drawing.Point(13, 111);
			this.buttonMåned.Name = "buttonMåned";
			this.buttonMåned.Size = new System.Drawing.Size(114, 23);
			this.buttonMåned.TabIndex = 25;
			this.buttonMåned.Text = "Ny Måned";
			this.buttonMåned.UseVisualStyleBackColor = true;
			this.buttonMåned.Click += new System.EventHandler(this.buttonMåned_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 22;
			this.label2.Text = "Size:";
			// 
			// textBoxSize
			// 
			this.textBoxSize.Location = new System.Drawing.Point(47, 55);
			this.textBoxSize.Name = "textBoxSize";
			this.textBoxSize.Size = new System.Drawing.Size(79, 20);
			this.textBoxSize.TabIndex = 21;
			// 
			// textBoxSeed
			// 
			this.textBoxSeed.Location = new System.Drawing.Point(47, 29);
			this.textBoxSeed.Name = "textBoxSeed";
			this.textBoxSeed.Size = new System.Drawing.Size(80, 20);
			this.textBoxSeed.TabIndex = 20;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "Seed:";
			// 
			// comboBoxRødhed
			// 
			this.comboBoxRødhed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxRødhed.FormattingEnabled = true;
			this.comboBoxRødhed.Items.AddRange(new object[] {
            "Intet",
            "Terræn",
            "Ujævnhed",
            "Temperatur",
            "Skyer",
            "Fugtighed",
            "Vandmængde",
            "Tropisk",
            "Tempereret",
            "Nål",
            "Næring"});
			this.comboBoxRødhed.Location = new System.Drawing.Point(7, 509);
			this.comboBoxRødhed.Name = "comboBoxRødhed";
			this.comboBoxRødhed.Size = new System.Drawing.Size(121, 21);
			this.comboBoxRødhed.TabIndex = 18;
			this.comboBoxRødhed.Text = "Intet";
			this.comboBoxRødhed.SelectedIndexChanged += new System.EventHandler(this.comboBoxRødhed_SelectedIndexChanged);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefresh.Enabled = false;
			this.buttonRefresh.Location = new System.Drawing.Point(53, 536);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
			this.buttonRefresh.TabIndex = 17;
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// labelUjævn
			// 
			this.labelUjævn.AutoSize = true;
			this.labelUjævn.Location = new System.Drawing.Point(6, 180);
			this.labelUjævn.Name = "labelUjævn";
			this.labelUjævn.Size = new System.Drawing.Size(60, 13);
			this.labelUjævn.TabIndex = 12;
			this.labelUjævn.Text = "Ujævnhed:";
			// 
			// labelTerræn
			// 
			this.labelTerræn.AutoSize = true;
			this.labelTerræn.Location = new System.Drawing.Point(6, 193);
			this.labelTerræn.Name = "labelTerræn";
			this.labelTerræn.Size = new System.Drawing.Size(45, 13);
			this.labelTerræn.TabIndex = 11;
			this.labelTerræn.Text = "Terræn:";
			// 
			// labelHøjde
			// 
			this.labelHøjde.AutoSize = true;
			this.labelHøjde.Location = new System.Drawing.Point(6, 154);
			this.labelHøjde.Name = "labelHøjde";
			this.labelHøjde.Size = new System.Drawing.Size(38, 13);
			this.labelHøjde.TabIndex = 10;
			this.labelHøjde.Text = "Højde:";
			// 
			// buttonGenerer
			// 
			this.buttonGenerer.Location = new System.Drawing.Point(13, 81);
			this.buttonGenerer.Name = "buttonGenerer";
			this.buttonGenerer.Size = new System.Drawing.Size(115, 23);
			this.buttonGenerer.TabIndex = 9;
			this.buttonGenerer.Text = "Generér";
			this.buttonGenerer.UseVisualStyleBackColor = true;
			this.buttonGenerer.Click += new System.EventHandler(this.buttonGenerate_Click);
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Location = new System.Drawing.Point(6, 9);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(35, 13);
			this.labelStatus.TabIndex = 8;
			this.labelStatus.Text = "status";
			// 
			// labelX
			// 
			this.labelX.AutoSize = true;
			this.labelX.Location = new System.Drawing.Point(6, 137);
			this.labelX.Name = "labelX";
			this.labelX.Size = new System.Drawing.Size(15, 13);
			this.labelX.TabIndex = 4;
			this.labelX.Text = "x:";
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filerToolStripMenuItem,
            this.visToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(645, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// filerToolStripMenuItem
			// 
			this.filerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.gemToolStripMenuItem,
            this.resetToolStripMenuItem});
			this.filerToolStripMenuItem.Name = "filerToolStripMenuItem";
			this.filerToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.filerToolStripMenuItem.Text = "Filer";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
			this.loadToolStripMenuItem.Text = "Load";
			// 
			// gemToolStripMenuItem
			// 
			this.gemToolStripMenuItem.Name = "gemToolStripMenuItem";
			this.gemToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
			this.gemToolStripMenuItem.Text = "Gem";
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
			this.resetToolStripMenuItem.Text = "Reset";
			// 
			// visToolStripMenuItem
			// 
			this.visToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controllerToolStripMenuItem,
            this.hexBoxToolStripMenuItem,
            this.folkBoxToolStripMenuItem});
			this.visToolStripMenuItem.Name = "visToolStripMenuItem";
			this.visToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
			this.visToolStripMenuItem.Text = "Vis";
			// 
			// controllerToolStripMenuItem
			// 
			this.controllerToolStripMenuItem.Name = "controllerToolStripMenuItem";
			this.controllerToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.controllerToolStripMenuItem.Text = "Controller";
			// 
			// hexBoxToolStripMenuItem
			// 
			this.hexBoxToolStripMenuItem.Name = "hexBoxToolStripMenuItem";
			this.hexBoxToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.hexBoxToolStripMenuItem.Text = "HexBox";
			this.hexBoxToolStripMenuItem.Click += new System.EventHandler(this.hexBoxToolStripMenuItem_Click);
			// 
			// folkBoxToolStripMenuItem
			// 
			this.folkBoxToolStripMenuItem.Name = "folkBoxToolStripMenuItem";
			this.folkBoxToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.folkBoxToolStripMenuItem.Text = "FolkBox";
			this.folkBoxToolStripMenuItem.Click += new System.EventHandler(this.folkBoxToolStripMenuItem_Click);
			// 
			// panelkort
			// 
			this.panelkort.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panelkort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelkort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelkort.Location = new System.Drawing.Point(0, 24);
			this.panelkort.Name = "panelkort";
			this.panelkort.Size = new System.Drawing.Size(645, 538);
			this.panelkort.TabIndex = 3;
			// 
			// panelHex
			// 
			this.panelHex.Controls.Add(this.label5);
			this.panelHex.Controls.Add(this.listBox1);
			this.panelHex.Controls.Add(this.label3);
			this.panelHex.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelHex.Location = new System.Drawing.Point(445, 24);
			this.panelHex.Name = "panelHex";
			this.panelHex.Size = new System.Drawing.Size(200, 538);
			this.panelHex.TabIndex = 4;
			this.panelHex.Visible = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "Hex:";
			// 
			// panelFolk
			// 
			this.panelFolk.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelFolk.Location = new System.Drawing.Point(0, 24);
			this.panelFolk.Name = "panelFolk";
			this.panelFolk.Size = new System.Drawing.Size(200, 538);
			this.panelFolk.TabIndex = 5;
			this.panelFolk.Visible = false;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(7, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(188, 56);
			this.listBox1.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(4, 92);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "label5";
			// 
			// WorldForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.panelFolk);
			this.Controls.Add(this.panelHex);
			this.Controls.Add(this.panelkort);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.panelController);
			this.Name = "WorldForm";
			this.Text = "Verden";
			this.panelController.ResumeLayout(false);
			this.panelController.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1Multi)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panelHex.ResumeLayout(false);
			this.panelHex.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panelController;
		private System.Windows.Forms.Button buttonGenerer;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Label labelX;
		private System.Windows.Forms.Label labelTerræn;
		private System.Windows.Forms.Label labelHøjde;
		private System.Windows.Forms.Label labelUjævn;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.ComboBox comboBoxRødhed;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxSize;
		private System.Windows.Forms.TextBox textBoxSeed;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonMåned;
		private System.Windows.Forms.CheckBox checkBoxAltitude;
		private System.Windows.Forms.Label labelMåned;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar trackBar1Multi;
		private System.Windows.Forms.CheckBox checkBoxHøjdeText;
		private System.Windows.Forms.Label labelNål;
		private System.Windows.Forms.Label labelTemp;
		private System.Windows.Forms.Label labelSkov;
		private System.Windows.Forms.Label labelTrop;
		private System.Windows.Forms.Label labelVandhøjde;
		private System.Windows.Forms.Label labelY;
		private System.Windows.Forms.Label labelTemperatur;
		private System.Windows.Forms.Label labelVand;
		private System.Windows.Forms.Label labelFugt;
		private System.Windows.Forms.Label labelSky;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem filerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem visToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem controllerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hexBoxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem folkBoxToolStripMenuItem;
		private System.Windows.Forms.Panel panelkort;
		private System.Windows.Forms.Panel panelHex;
		private System.Windows.Forms.Panel panelFolk;
		private System.Windows.Forms.Label labelRovdyr;
		private System.Windows.Forms.Label labelPlanteæder;
		private System.Windows.Forms.Label labelSmåvildt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelNæring;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label5;
	}
}

