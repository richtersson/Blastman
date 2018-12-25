namespace Blastman
{
    partial class Povrchy
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
            this.dataGridViewPovrchy = new System.Windows.Forms.DataGridView();
            this.btnPridatPovrch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chBoxTop = new System.Windows.Forms.CheckBox();
            this.chBoxBottom = new System.Windows.Forms.CheckBox();
            this.chBoxSide = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPovrchy)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPovrchy
            // 
            this.dataGridViewPovrchy.AllowUserToAddRows = false;
            this.dataGridViewPovrchy.AllowUserToDeleteRows = false;
            this.dataGridViewPovrchy.AllowUserToResizeRows = false;
            this.dataGridViewPovrchy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPovrchy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPovrchy.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewPovrchy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewPovrchy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPovrchy.Location = new System.Drawing.Point(109, 9);
            this.dataGridViewPovrchy.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewPovrchy.Name = "dataGridViewPovrchy";
            this.dataGridViewPovrchy.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewPovrchy.RowHeadersVisible = false;
            this.dataGridViewPovrchy.RowTemplate.Height = 24;
            this.dataGridViewPovrchy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPovrchy.Size = new System.Drawing.Size(393, 187);
            this.dataGridViewPovrchy.TabIndex = 3;
            this.dataGridViewPovrchy.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewPovrchy_CellFormatting);
            this.dataGridViewPovrchy.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPovrchy_RowEnter);
            // 
            // btnPridatPovrch
            // 
            this.btnPridatPovrch.Location = new System.Drawing.Point(388, 203);
            this.btnPridatPovrch.Margin = new System.Windows.Forms.Padding(2);
            this.btnPridatPovrch.Name = "btnPridatPovrch";
            this.btnPridatPovrch.Size = new System.Drawing.Size(114, 42);
            this.btnPridatPovrch.TabIndex = 7;
            this.btnPridatPovrch.Text = "Pridať povrchy";
            this.btnPridatPovrch.UseVisualStyleBackColor = true;
            this.btnPridatPovrch.Click += new System.EventHandler(this.btnPridatPovrch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(270, 203);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 42);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Vymazať povrch";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chBoxTop
            // 
            this.chBoxTop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chBoxTop.Location = new System.Drawing.Point(12, 12);
            this.chBoxTop.Name = "chBoxTop";
            this.chBoxTop.Size = new System.Drawing.Size(90, 42);
            this.chBoxTop.TabIndex = 9;
            this.chBoxTop.Text = "Horný pohľad";
            this.chBoxTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chBoxTop.UseVisualStyleBackColor = true;
            this.chBoxTop.CheckedChanged += new System.EventHandler(this.chBoxTop_CheckedChanged);
            // 
            // chBoxBottom
            // 
            this.chBoxBottom.Appearance = System.Windows.Forms.Appearance.Button;
            this.chBoxBottom.Location = new System.Drawing.Point(12, 60);
            this.chBoxBottom.Name = "chBoxBottom";
            this.chBoxBottom.Size = new System.Drawing.Size(90, 42);
            this.chBoxBottom.TabIndex = 10;
            this.chBoxBottom.Text = "Spodný pohľad";
            this.chBoxBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chBoxBottom.UseVisualStyleBackColor = true;
            this.chBoxBottom.CheckedChanged += new System.EventHandler(this.chBoxBottom_CheckedChanged);
            // 
            // chBoxSide
            // 
            this.chBoxSide.Appearance = System.Windows.Forms.Appearance.Button;
            this.chBoxSide.Location = new System.Drawing.Point(12, 108);
            this.chBoxSide.Name = "chBoxSide";
            this.chBoxSide.Size = new System.Drawing.Size(90, 42);
            this.chBoxSide.TabIndex = 11;
            this.chBoxSide.Text = "Bočný pohľad";
            this.chBoxSide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chBoxSide.UseVisualStyleBackColor = true;
            this.chBoxSide.CheckedChanged += new System.EventHandler(this.chBoxSide_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 203);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 42);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Zavrieť";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Povrchy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 256);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chBoxSide);
            this.Controls.Add(this.chBoxBottom);
            this.Controls.Add(this.chBoxTop);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPridatPovrch);
            this.Controls.Add(this.dataGridViewPovrchy);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Povrchy";
            this.ShowIcon = false;
            this.Text = "Spravovať povrchy";
            this.Load += new System.EventHandler(this.Povrchy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPovrchy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPovrchy;
        private System.Windows.Forms.Button btnPridatPovrch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chBoxTop;
        private System.Windows.Forms.CheckBox chBoxBottom;
        private System.Windows.Forms.CheckBox chBoxSide;
        private System.Windows.Forms.Button btnClose;
    }
}