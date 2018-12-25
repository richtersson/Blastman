namespace Blastman
{
    partial class Tabulka_rezov
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
            this.dataGridViewTabulkaRezov = new System.Windows.Forms.DataGridView();
            this.btnPridatRez = new System.Windows.Forms.Button();
            this.btnVymazatRez = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabulkaRezov)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTabulkaRezov
            // 
            this.dataGridViewTabulkaRezov.AllowUserToAddRows = false;
            this.dataGridViewTabulkaRezov.AllowUserToDeleteRows = false;
            this.dataGridViewTabulkaRezov.AllowUserToResizeRows = false;
            this.dataGridViewTabulkaRezov.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTabulkaRezov.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTabulkaRezov.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewTabulkaRezov.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewTabulkaRezov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabulkaRezov.Location = new System.Drawing.Point(116, 8);
            this.dataGridViewTabulkaRezov.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewTabulkaRezov.MultiSelect = false;
            this.dataGridViewTabulkaRezov.Name = "dataGridViewTabulkaRezov";
            this.dataGridViewTabulkaRezov.RowHeadersVisible = false;
            this.dataGridViewTabulkaRezov.RowTemplate.Height = 24;
            this.dataGridViewTabulkaRezov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewTabulkaRezov.Size = new System.Drawing.Size(608, 241);
            this.dataGridViewTabulkaRezov.TabIndex = 0;
            this.dataGridViewTabulkaRezov.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTabulkaRezov_CellContentClick);
            this.dataGridViewTabulkaRezov.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTabulkaRezov_RowEnter);
            // 
            // btnPridatRez
            // 
            this.btnPridatRez.Location = new System.Drawing.Point(9, 10);
            this.btnPridatRez.Margin = new System.Windows.Forms.Padding(2);
            this.btnPridatRez.Name = "btnPridatRez";
            this.btnPridatRez.Size = new System.Drawing.Size(90, 29);
            this.btnPridatRez.TabIndex = 1;
            this.btnPridatRez.Text = "Pridať rez";
            this.btnPridatRez.UseVisualStyleBackColor = true;
            this.btnPridatRez.Click += new System.EventHandler(this.btnPridatRez_Click);
            // 
            // btnVymazatRez
            // 
            this.btnVymazatRez.Location = new System.Drawing.Point(9, 44);
            this.btnVymazatRez.Margin = new System.Windows.Forms.Padding(2);
            this.btnVymazatRez.Name = "btnVymazatRez";
            this.btnVymazatRez.Size = new System.Drawing.Size(90, 29);
            this.btnVymazatRez.TabIndex = 2;
            this.btnVymazatRez.Text = "Vymazať rez";
            this.btnVymazatRez.UseVisualStyleBackColor = true;
            this.btnVymazatRez.Click += new System.EventHandler(this.btnVymazatRez_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(649, 271);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Zavrieť";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Tabulka_rezov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 306);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnVymazatRez);
            this.Controls.Add(this.btnPridatRez);
            this.Controls.Add(this.dataGridViewTabulkaRezov);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Tabulka_rezov";
            this.Text = "Tabuľka rezov";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tabulka_rezov_FormClosed);
            this.Load += new System.EventHandler(this.Tabulka_rezov_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabulkaRezov)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTabulkaRezov;
        private System.Windows.Forms.Button btnPridatRez;
        private System.Windows.Forms.Button btnVymazatRez;
        private System.Windows.Forms.Button btnClose;
    }
}