namespace Blastman
{
    partial class Copy
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
            this.cBoxCislaVykresov = new System.Windows.Forms.ComboBox();
            this.txtNazov = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnVytvorit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cBoxCislaVykresov
            // 
            this.cBoxCislaVykresov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCislaVykresov.FormattingEnabled = true;
            this.cBoxCislaVykresov.Items.AddRange(new object[] {
            "CV_2579",
            "CV_9875"});
            this.cBoxCislaVykresov.Location = new System.Drawing.Point(28, 43);
            this.cBoxCislaVykresov.MaxDropDownItems = 15;
            this.cBoxCislaVykresov.Name = "cBoxCislaVykresov";
            this.cBoxCislaVykresov.Size = new System.Drawing.Size(130, 21);
            this.cBoxCislaVykresov.TabIndex = 0;
            // 
            // txtNazov
            // 
            this.txtNazov.Location = new System.Drawing.Point(28, 130);
            this.txtNazov.Name = "txtNazov";
            this.txtNazov.Size = new System.Drawing.Size(130, 20);
            this.txtNazov.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(25, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(90, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Do čísla výkresu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Názov predpisu";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(25, 263);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 13);
            this.lblPath.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(10, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Zrušiť";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnVytvorit
            // 
            this.btnVytvorit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnVytvorit.Location = new System.Drawing.Point(179, 230);
            this.btnVytvorit.Name = "btnVytvorit";
            this.btnVytvorit.Size = new System.Drawing.Size(75, 23);
            this.btnVytvorit.TabIndex = 2;
            this.btnVytvorit.Text = "Vytvoriť";
            this.btnVytvorit.UseVisualStyleBackColor = true;
            this.btnVytvorit.Click += new System.EventHandler(this.btnVytvorit_Click);
            // 
            // Copy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(264, 263);
            this.Controls.Add(this.btnVytvorit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtNazov);
            this.Controls.Add(this.cBoxCislaVykresov);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Copy";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kopírovať Predpis kontroly";
            this.Load += new System.EventHandler(this.Novy_PK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxCislaVykresov;
        private System.Windows.Forms.TextBox txtNazov;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnVytvorit;
    }
}