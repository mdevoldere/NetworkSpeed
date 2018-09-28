namespace Devoldere.NetSpeedTray.Views
{
    partial class UCViewMini
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblTrafficeUp = new System.Windows.Forms.Label();
            this.lblTrafficeDown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.Info;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(180, 16);
            this.lblName.TabIndex = 30;
            this.lblName.Text = "Network";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrafficeUp
            // 
            this.lblTrafficeUp.BackColor = System.Drawing.SystemColors.Info;
            this.lblTrafficeUp.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrafficeUp.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTrafficeUp.Location = new System.Drawing.Point(0, 18);
            this.lblTrafficeUp.Name = "lblTrafficeUp";
            this.lblTrafficeUp.Size = new System.Drawing.Size(86, 16);
            this.lblTrafficeUp.TabIndex = 29;
            this.lblTrafficeUp.Text = "0";
            this.lblTrafficeUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrafficeDown
            // 
            this.lblTrafficeDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrafficeDown.BackColor = System.Drawing.SystemColors.Info;
            this.lblTrafficeDown.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrafficeDown.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTrafficeDown.Location = new System.Drawing.Point(94, 18);
            this.lblTrafficeDown.Name = "lblTrafficeDown";
            this.lblTrafficeDown.Size = new System.Drawing.Size(86, 16);
            this.lblTrafficeDown.TabIndex = 31;
            this.lblTrafficeDown.Text = "0";
            this.lblTrafficeDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCViewMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.lblTrafficeDown);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTrafficeUp);
            this.Name = "UCViewMini";
            this.Size = new System.Drawing.Size(180, 36);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTrafficeUp;
        private System.Windows.Forms.Label lblTrafficeDown;
    }
}
