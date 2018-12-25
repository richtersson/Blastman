namespace Blastman
{
    partial class BasicInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicInterface));
            this.label1 = new System.Windows.Forms.Label();
            this.lblModelPath = new System.Windows.Forms.Label();
            this.dataGridViewMerania = new System.Windows.Forms.DataGridView();
            this.cBoxTypMerania = new System.Windows.Forms.ComboBox();
            this.lblTypMerania = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPridatMeranie = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCharRez = new System.Windows.Forms.Label();
            this.btnCharakteristickyRez = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVymazMeranie = new System.Windows.Forms.Button();
            this.btnUpravMeranie = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxNazovPredpisuKontroly = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxCisloVykresu = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chBoxSkupTolPovrch = new System.Windows.Forms.CheckBox();
            this.chBoxSkupTolRadius = new System.Windows.Forms.CheckBox();
            this.chBoxSkupTolUhol = new System.Windows.Forms.CheckBox();
            this.chBoxSkupTolVzd = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSkupPovrchChyby = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSkupRadiusMinus = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSkupRadiusPlus = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSkupUholMinus = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSkupUholPlus = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSkupVzdMinus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSkupVzdPlus = new System.Windows.Forms.TextBox();
            this.btnSavePredpisKontroly = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblPolohovaciRez = new System.Windows.Forms.Label();
            this.btnPolohovaciRez = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnTabulkaRezov = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnKontrolaKvalityPovrchov = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMerania)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Priradený model:";
            // 
            // lblModelPath
            // 
            this.lblModelPath.AutoSize = true;
            this.lblModelPath.Location = new System.Drawing.Point(8, 34);
            this.lblModelPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModelPath.Name = "lblModelPath";
            this.lblModelPath.Size = new System.Drawing.Size(62, 13);
            this.lblModelPath.TabIndex = 3;
            this.lblModelPath.Text = "nepriradený";
            // 
            // dataGridViewMerania
            // 
            this.dataGridViewMerania.AllowUserToAddRows = false;
            this.dataGridViewMerania.AllowUserToDeleteRows = false;
            this.dataGridViewMerania.AllowUserToResizeRows = false;
            this.dataGridViewMerania.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMerania.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMerania.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewMerania.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewMerania.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMerania.Location = new System.Drawing.Point(265, 28);
            this.dataGridViewMerania.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewMerania.MultiSelect = false;
            this.dataGridViewMerania.Name = "dataGridViewMerania";
            this.dataGridViewMerania.ReadOnly = true;
            this.dataGridViewMerania.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewMerania.RowHeadersVisible = false;
            this.dataGridViewMerania.RowTemplate.Height = 24;
            this.dataGridViewMerania.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMerania.Size = new System.Drawing.Size(575, 209);
            this.dataGridViewMerania.TabIndex = 10;
            this.dataGridViewMerania.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewMerania_CellFormatting);
            this.dataGridViewMerania.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMerania_CellMouseClick);
            this.dataGridViewMerania.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMerania_RowEnter);
            this.dataGridViewMerania.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewMerania_MouseDoubleClick);
            // 
            // cBoxTypMerania
            // 
            this.cBoxTypMerania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTypMerania.FormattingEnabled = true;
            this.cBoxTypMerania.Location = new System.Drawing.Point(8, 45);
            this.cBoxTypMerania.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxTypMerania.Name = "cBoxTypMerania";
            this.cBoxTypMerania.Size = new System.Drawing.Size(248, 21);
            this.cBoxTypMerania.TabIndex = 0;
            this.cBoxTypMerania.SelectedIndexChanged += new System.EventHandler(this.cBoxTypMerania_SelectedIndexChanged);
            this.cBoxTypMerania.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cBoxTypMerania_Format);
            // 
            // lblTypMerania
            // 
            this.lblTypMerania.AutoSize = true;
            this.lblTypMerania.Location = new System.Drawing.Point(5, 28);
            this.lblTypMerania.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTypMerania.Name = "lblTypMerania";
            this.lblTypMerania.Size = new System.Drawing.Size(68, 13);
            this.lblTypMerania.TabIndex = 4;
            this.lblTypMerania.Text = "Typ merania:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cBoxTypMerania);
            this.groupBox1.Controls.Add(this.lblTypMerania);
            this.groupBox1.Controls.Add(this.btnPridatMeranie);
            this.groupBox1.Location = new System.Drawing.Point(265, 249);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(362, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pridanie merania";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnPridatMeranie
            // 
            this.btnPridatMeranie.Location = new System.Drawing.Point(271, 34);
            this.btnPridatMeranie.Margin = new System.Windows.Forms.Padding(2);
            this.btnPridatMeranie.Name = "btnPridatMeranie";
            this.btnPridatMeranie.Size = new System.Drawing.Size(86, 39);
            this.btnPridatMeranie.TabIndex = 1;
            this.btnPridatMeranie.Text = "Pridať meranie";
            this.btnPridatMeranie.UseVisualStyleBackColor = true;
            this.btnPridatMeranie.Click += new System.EventHandler(this.btnPridatMeranie_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Vyberte charakteristickú rovinu:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lblCharRez);
            this.groupBox2.Controls.Add(this.btnCharakteristickyRez);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(9, 164);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(239, 81);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Priradenie charakteristického rezu (povinné)";
            // 
            // lblCharRez
            // 
            this.lblCharRez.AutoSize = true;
            this.lblCharRez.Location = new System.Drawing.Point(4, 55);
            this.lblCharRez.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCharRez.Name = "lblCharRez";
            this.lblCharRez.Size = new System.Drawing.Size(0, 13);
            this.lblCharRez.TabIndex = 7;
            // 
            // btnCharakteristickyRez
            // 
            this.btnCharakteristickyRez.Image = ((System.Drawing.Image)(resources.GetObject("btnCharakteristickyRez.Image")));
            this.btnCharakteristickyRez.Location = new System.Drawing.Point(169, 22);
            this.btnCharakteristickyRez.Margin = new System.Windows.Forms.Padding(2);
            this.btnCharakteristickyRez.Name = "btnCharakteristickyRez";
            this.btnCharakteristickyRez.Size = new System.Drawing.Size(22, 24);
            this.btnCharakteristickyRez.TabIndex = 0;
            this.btnCharakteristickyRez.UseVisualStyleBackColor = true;
            this.btnCharakteristickyRez.Click += new System.EventHandler(this.btnCharakteristickaRovina_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Zoznam meraní:";
            // 
            // btnVymazMeranie
            // 
            this.btnVymazMeranie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVymazMeranie.Location = new System.Drawing.Point(110, 34);
            this.btnVymazMeranie.Margin = new System.Windows.Forms.Padding(2);
            this.btnVymazMeranie.Name = "btnVymazMeranie";
            this.btnVymazMeranie.Size = new System.Drawing.Size(96, 39);
            this.btnVymazMeranie.TabIndex = 1;
            this.btnVymazMeranie.Text = "Vymazať";
            this.btnVymazMeranie.UseVisualStyleBackColor = true;
            this.btnVymazMeranie.Click += new System.EventHandler(this.btnVymazMeranie_Click);
            // 
            // btnUpravMeranie
            // 
            this.btnUpravMeranie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpravMeranie.Location = new System.Drawing.Point(9, 34);
            this.btnUpravMeranie.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpravMeranie.Name = "btnUpravMeranie";
            this.btnUpravMeranie.Size = new System.Drawing.Size(96, 39);
            this.btnUpravMeranie.TabIndex = 0;
            this.btnUpravMeranie.Text = "Upraviť";
            this.btnUpravMeranie.UseVisualStyleBackColor = true;
            this.btnUpravMeranie.Click += new System.EventHandler(this.btnUpravMeranie_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(740, 418);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 39);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Exportovať";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtBoxNazovPredpisuKontroly);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtBoxCisloVykresu);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lblModelPath);
            this.groupBox3.Location = new System.Drawing.Point(9, 10);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(239, 148);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Základné vlastnosti";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Názov predpisu kontroly:";
            // 
            // txtBoxNazovPredpisuKontroly
            // 
            this.txtBoxNazovPredpisuKontroly.Location = new System.Drawing.Point(8, 119);
            this.txtBoxNazovPredpisuKontroly.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxNazovPredpisuKontroly.Name = "txtBoxNazovPredpisuKontroly";
            this.txtBoxNazovPredpisuKontroly.ReadOnly = true;
            this.txtBoxNazovPredpisuKontroly.Size = new System.Drawing.Size(150, 20);
            this.txtBoxNazovPredpisuKontroly.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Číslo výkresu:";
            // 
            // txtBoxCisloVykresu
            // 
            this.txtBoxCisloVykresu.Location = new System.Drawing.Point(8, 74);
            this.txtBoxCisloVykresu.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxCisloVykresu.Name = "txtBoxCisloVykresu";
            this.txtBoxCisloVykresu.ReadOnly = true;
            this.txtBoxCisloVykresu.Size = new System.Drawing.Size(150, 20);
            this.txtBoxCisloVykresu.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chBoxSkupTolPovrch);
            this.groupBox4.Controls.Add(this.chBoxSkupTolRadius);
            this.groupBox4.Controls.Add(this.chBoxSkupTolUhol);
            this.groupBox4.Controls.Add(this.chBoxSkupTolVzd);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtSkupPovrchChyby);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtSkupRadiusMinus);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtSkupRadiusPlus);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtSkupUholMinus);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtSkupUholPlus);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtSkupVzdMinus);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtSkupVzdPlus);
            this.groupBox4.Location = new System.Drawing.Point(9, 249);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(239, 208);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Skupinové tolerancie";
            // 
            // chBoxSkupTolPovrch
            // 
            this.chBoxSkupTolPovrch.AutoSize = true;
            this.chBoxSkupTolPovrch.Location = new System.Drawing.Point(144, 186);
            this.chBoxSkupTolPovrch.Name = "chBoxSkupTolPovrch";
            this.chBoxSkupTolPovrch.Size = new System.Drawing.Size(56, 17);
            this.chBoxSkupTolPovrch.TabIndex = 10;
            this.chBoxSkupTolPovrch.Text = "Použiť";
            this.chBoxSkupTolPovrch.UseVisualStyleBackColor = true;
            this.chBoxSkupTolPovrch.CheckedChanged += new System.EventHandler(this.chBoxSkupTolPovrch_CheckedChanged);
            // 
            // chBoxSkupTolRadius
            // 
            this.chBoxSkupTolRadius.AutoSize = true;
            this.chBoxSkupTolRadius.Location = new System.Drawing.Point(144, 139);
            this.chBoxSkupTolRadius.Name = "chBoxSkupTolRadius";
            this.chBoxSkupTolRadius.Size = new System.Drawing.Size(56, 17);
            this.chBoxSkupTolRadius.TabIndex = 9;
            this.chBoxSkupTolRadius.Text = "Použiť";
            this.chBoxSkupTolRadius.UseVisualStyleBackColor = true;
            this.chBoxSkupTolRadius.CheckedChanged += new System.EventHandler(this.chBoxSkupTolRadius_CheckedChanged);
            // 
            // chBoxSkupTolUhol
            // 
            this.chBoxSkupTolUhol.AutoSize = true;
            this.chBoxSkupTolUhol.Location = new System.Drawing.Point(144, 94);
            this.chBoxSkupTolUhol.Name = "chBoxSkupTolUhol";
            this.chBoxSkupTolUhol.Size = new System.Drawing.Size(56, 17);
            this.chBoxSkupTolUhol.TabIndex = 8;
            this.chBoxSkupTolUhol.Text = "Použiť";
            this.chBoxSkupTolUhol.UseVisualStyleBackColor = true;
            this.chBoxSkupTolUhol.CheckedChanged += new System.EventHandler(this.chBoxSkupTolUhol_CheckedChanged);
            // 
            // chBoxSkupTolVzd
            // 
            this.chBoxSkupTolVzd.AutoSize = true;
            this.chBoxSkupTolVzd.Location = new System.Drawing.Point(144, 49);
            this.chBoxSkupTolVzd.Name = "chBoxSkupTolVzd";
            this.chBoxSkupTolVzd.Size = new System.Drawing.Size(56, 17);
            this.chBoxSkupTolVzd.TabIndex = 7;
            this.chBoxSkupTolVzd.Text = "Použiť";
            this.chBoxSkupTolVzd.UseVisualStyleBackColor = true;
            this.chBoxSkupTolVzd.CheckedChanged += new System.EventHandler(this.chBoxSkupTolVzd_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 164);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(201, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Skupinová tolerancia povrchových chýb:";
            // 
            // txtSkupPovrchChyby
            // 
            this.txtSkupPovrchChyby.Enabled = false;
            this.txtSkupPovrchChyby.Location = new System.Drawing.Point(103, 183);
            this.txtSkupPovrchChyby.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkupPovrchChyby.Name = "txtSkupPovrchChyby";
            this.txtSkupPovrchChyby.Size = new System.Drawing.Size(27, 20);
            this.txtSkupPovrchChyby.TabIndex = 6;
            this.txtSkupPovrchChyby.Text = "0";
            this.txtSkupPovrchChyby.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(24, 136);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 20);
            this.label13.TabIndex = 19;
            this.label13.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(81, 136);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 20);
            this.label14.TabIndex = 18;
            this.label14.Text = "+";
            // 
            // txtSkupRadiusMinus
            // 
            this.txtSkupRadiusMinus.Enabled = false;
            this.txtSkupRadiusMinus.Location = new System.Drawing.Point(42, 141);
            this.txtSkupRadiusMinus.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkupRadiusMinus.Name = "txtSkupRadiusMinus";
            this.txtSkupRadiusMinus.Size = new System.Drawing.Size(27, 20);
            this.txtSkupRadiusMinus.TabIndex = 4;
            this.txtSkupRadiusMinus.Text = "0";
            this.txtSkupRadiusMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 120);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Skupinová tolerancia rádiusu:";
            // 
            // txtSkupRadiusPlus
            // 
            this.txtSkupRadiusPlus.Enabled = false;
            this.txtSkupRadiusPlus.Location = new System.Drawing.Point(103, 141);
            this.txtSkupRadiusPlus.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkupRadiusPlus.Name = "txtSkupRadiusPlus";
            this.txtSkupRadiusPlus.Size = new System.Drawing.Size(27, 20);
            this.txtSkupRadiusPlus.TabIndex = 5;
            this.txtSkupRadiusPlus.Text = "0";
            this.txtSkupRadiusPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(24, 90);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(81, 92);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "+";
            // 
            // txtSkupUholMinus
            // 
            this.txtSkupUholMinus.Enabled = false;
            this.txtSkupUholMinus.Location = new System.Drawing.Point(42, 94);
            this.txtSkupUholMinus.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkupUholMinus.Name = "txtSkupUholMinus";
            this.txtSkupUholMinus.Size = new System.Drawing.Size(27, 20);
            this.txtSkupUholMinus.TabIndex = 2;
            this.txtSkupUholMinus.Text = "0";
            this.txtSkupUholMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 75);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Skupinová tolerancia uhlu:";
            // 
            // txtSkupUholPlus
            // 
            this.txtSkupUholPlus.Enabled = false;
            this.txtSkupUholPlus.Location = new System.Drawing.Point(103, 94);
            this.txtSkupUholPlus.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkupUholPlus.Name = "txtSkupUholPlus";
            this.txtSkupUholPlus.Size = new System.Drawing.Size(27, 20);
            this.txtSkupUholPlus.TabIndex = 3;
            this.txtSkupUholPlus.Text = "0";
            this.txtSkupUholPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(24, 46);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(81, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "+";
            // 
            // txtSkupVzdMinus
            // 
            this.txtSkupVzdMinus.Enabled = false;
            this.txtSkupVzdMinus.Location = new System.Drawing.Point(42, 48);
            this.txtSkupVzdMinus.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkupVzdMinus.Name = "txtSkupVzdMinus";
            this.txtSkupVzdMinus.Size = new System.Drawing.Size(27, 20);
            this.txtSkupVzdMinus.TabIndex = 0;
            this.txtSkupVzdMinus.Text = "0";
            this.txtSkupVzdMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Skupinová tolerancia vzdialenosti:";
            // 
            // txtSkupVzdPlus
            // 
            this.txtSkupVzdPlus.Enabled = false;
            this.txtSkupVzdPlus.Location = new System.Drawing.Point(103, 48);
            this.txtSkupVzdPlus.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkupVzdPlus.Name = "txtSkupVzdPlus";
            this.txtSkupVzdPlus.Size = new System.Drawing.Size(27, 20);
            this.txtSkupVzdPlus.TabIndex = 1;
            this.txtSkupVzdPlus.Text = "0";
            this.txtSkupVzdPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSavePredpisKontroly
            // 
            this.btnSavePredpisKontroly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePredpisKontroly.Location = new System.Drawing.Point(640, 418);
            this.btnSavePredpisKontroly.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavePredpisKontroly.Name = "btnSavePredpisKontroly";
            this.btnSavePredpisKontroly.Size = new System.Drawing.Size(96, 39);
            this.btnSavePredpisKontroly.TabIndex = 4;
            this.btnSavePredpisKontroly.Text = "Uložiť";
            this.btnSavePredpisKontroly.UseVisualStyleBackColor = true;
            this.btnSavePredpisKontroly.Click += new System.EventHandler(this.btnSavePredpisKontroly_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.lblPolohovaciRez);
            this.groupBox5.Controls.Add(this.btnPolohovaciRez);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Location = new System.Drawing.Point(265, 375);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(211, 81);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Priradenie polohovacieho rezu";
            // 
            // lblPolohovaciRez
            // 
            this.lblPolohovaciRez.AutoSize = true;
            this.lblPolohovaciRez.Location = new System.Drawing.Point(5, 55);
            this.lblPolohovaciRez.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPolohovaciRez.Name = "lblPolohovaciRez";
            this.lblPolohovaciRez.Size = new System.Drawing.Size(0, 13);
            this.lblPolohovaciRez.TabIndex = 7;
            // 
            // btnPolohovaciRez
            // 
            this.btnPolohovaciRez.Image = ((System.Drawing.Image)(resources.GetObject("btnPolohovaciRez.Image")));
            this.btnPolohovaciRez.Location = new System.Drawing.Point(169, 22);
            this.btnPolohovaciRez.Margin = new System.Windows.Forms.Padding(2);
            this.btnPolohovaciRez.Name = "btnPolohovaciRez";
            this.btnPolohovaciRez.Size = new System.Drawing.Size(22, 24);
            this.btnPolohovaciRez.TabIndex = 0;
            this.btnPolohovaciRez.UseVisualStyleBackColor = true;
            this.btnPolohovaciRez.Click += new System.EventHandler(this.btnPolohovaciRez_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 22);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(139, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Vyberte polohovaciu rovinu:";
            // 
            // btnTabulkaRezov
            // 
            this.btnTabulkaRezov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTabulkaRezov.Location = new System.Drawing.Point(740, 355);
            this.btnTabulkaRezov.Name = "btnTabulkaRezov";
            this.btnTabulkaRezov.Size = new System.Drawing.Size(96, 39);
            this.btnTabulkaRezov.TabIndex = 9;
            this.btnTabulkaRezov.Text = "Spravovať rezy";
            this.btnTabulkaRezov.UseVisualStyleBackColor = true;
            this.btnTabulkaRezov.Click += new System.EventHandler(this.btnTabulkaRezov_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(539, 418);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 39);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Zavrieť";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnKontrolaKvalityPovrchov
            // 
            this.btnKontrolaKvalityPovrchov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKontrolaKvalityPovrchov.Location = new System.Drawing.Point(640, 355);
            this.btnKontrolaKvalityPovrchov.Name = "btnKontrolaKvalityPovrchov";
            this.btnKontrolaKvalityPovrchov.Size = new System.Drawing.Size(96, 39);
            this.btnKontrolaKvalityPovrchov.TabIndex = 8;
            this.btnKontrolaKvalityPovrchov.Text = "Spravovať povrchy";
            this.btnKontrolaKvalityPovrchov.UseVisualStyleBackColor = true;
            this.btnKontrolaKvalityPovrchov.Click += new System.EventHandler(this.btnKontrolaKvalityPovrchov_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnUpravMeranie);
            this.groupBox6.Controls.Add(this.btnVymazMeranie);
            this.groupBox6.Location = new System.Drawing.Point(631, 249);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(209, 89);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Správa meraní";
            // 
            // BasicInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 466);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnKontrolaKvalityPovrchov);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTabulkaRezov);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnSavePredpisKontroly);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewMerania);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicInterface";
            this.Text = "Predpis kontroly";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BasicInterface_FormClosed);
            this.Load += new System.EventHandler(this.BasicInterface_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BasicInterface_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMerania)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblModelPath;
        private System.Windows.Forms.DataGridView dataGridViewMerania;
        private System.Windows.Forms.ComboBox cBoxTypMerania;
        private System.Windows.Forms.Label lblTypMerania;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCharakteristickyRez;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVymazMeranie;
        private System.Windows.Forms.Button btnUpravMeranie;
        private System.Windows.Forms.Button btnExport;
        private Predpis_kontroly pk;
        private System.Windows.Forms.Button btnPridatMeranie;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxNazovPredpisuKontroly;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxCisloVykresu;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSavePredpisKontroly;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnPolohovaciRez;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnTabulkaRezov;
        private System.Windows.Forms.TextBox txtSkupPovrchChyby;
        private System.Windows.Forms.TextBox txtSkupRadiusMinus;
        private System.Windows.Forms.TextBox txtSkupRadiusPlus;
        private System.Windows.Forms.TextBox txtSkupUholMinus;
        private System.Windows.Forms.TextBox txtSkupUholPlus;
        private System.Windows.Forms.TextBox txtSkupVzdMinus;
        private System.Windows.Forms.TextBox txtSkupVzdPlus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chBoxSkupTolRadius;
        private System.Windows.Forms.CheckBox chBoxSkupTolUhol;
        private System.Windows.Forms.CheckBox chBoxSkupTolVzd;
        private System.Windows.Forms.CheckBox chBoxSkupTolPovrch;
        private System.Windows.Forms.Button btnKontrolaKvalityPovrchov;
        private System.Windows.Forms.Label lblCharRez;
        private System.Windows.Forms.Label lblPolohovaciRez;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}