namespace Devoldere.NetSpeedTray.Views
{
    partial class UCNetInterface
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
            this.LblBytesLbl = new System.Windows.Forms.Label();
            this.lblBytesUp = new System.Windows.Forms.Label();
            this.lblBytesDown = new System.Windows.Forms.Label();
            this.lblSpace = new System.Windows.Forms.Label();
            this.lblSpeedLbl = new System.Windows.Forms.Label();
            this.lblSrDown = new System.Windows.Forms.Label();
            this.lblUl = new System.Windows.Forms.Label();
            this.lblDl = new System.Windows.Forms.Label();
            this.lblUlLbl = new System.Windows.Forms.Label();
            this.lblDlLbl = new System.Windows.Forms.Label();
            this.lblSrUp = new System.Windows.Forms.Label();
            this.lblSrLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.BackColor = System.Drawing.SystemColors.Control;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.DimGray;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(205, 75);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Network";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblBytesLbl
            // 
            this.LblBytesLbl.BackColor = System.Drawing.SystemColors.Info;
            this.LblBytesLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBytesLbl.Location = new System.Drawing.Point(3, 109);
            this.LblBytesLbl.Name = "LblBytesLbl";
            this.LblBytesLbl.Size = new System.Drawing.Size(44, 16);
            this.LblBytesLbl.TabIndex = 30;
            this.LblBytesLbl.Text = "Bytes";
            this.LblBytesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBytesUp
            // 
            this.lblBytesUp.BackColor = System.Drawing.SystemColors.Info;
            this.lblBytesUp.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytesUp.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblBytesUp.Location = new System.Drawing.Point(48, 109);
            this.lblBytesUp.Name = "lblBytesUp";
            this.lblBytesUp.Size = new System.Drawing.Size(80, 16);
            this.lblBytesUp.TabIndex = 29;
            this.lblBytesUp.Text = "0";
            this.lblBytesUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBytesDown
            // 
            this.lblBytesDown.BackColor = System.Drawing.SystemColors.Info;
            this.lblBytesDown.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytesDown.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBytesDown.Location = new System.Drawing.Point(129, 109);
            this.lblBytesDown.Name = "lblBytesDown";
            this.lblBytesDown.Size = new System.Drawing.Size(80, 16);
            this.lblBytesDown.TabIndex = 28;
            this.lblBytesDown.Text = "0";
            this.lblBytesDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSpace
            // 
            this.lblSpace.BackColor = System.Drawing.SystemColors.Info;
            this.lblSpace.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpace.Location = new System.Drawing.Point(3, 75);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(44, 16);
            this.lblSpace.TabIndex = 27;
            this.lblSpace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSpeedLbl
            // 
            this.lblSpeedLbl.BackColor = System.Drawing.SystemColors.Info;
            this.lblSpeedLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedLbl.Location = new System.Drawing.Point(3, 126);
            this.lblSpeedLbl.Name = "lblSpeedLbl";
            this.lblSpeedLbl.Size = new System.Drawing.Size(44, 16);
            this.lblSpeedLbl.TabIndex = 26;
            this.lblSpeedLbl.Text = "Speed";
            this.lblSpeedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSrDown
            // 
            this.lblSrDown.BackColor = System.Drawing.SystemColors.Info;
            this.lblSrDown.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrDown.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSrDown.Location = new System.Drawing.Point(129, 92);
            this.lblSrDown.Name = "lblSrDown";
            this.lblSrDown.Size = new System.Drawing.Size(80, 16);
            this.lblSrDown.TabIndex = 25;
            this.lblSrDown.Text = "0";
            this.lblSrDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUl
            // 
            this.lblUl.BackColor = System.Drawing.SystemColors.Info;
            this.lblUl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUl.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblUl.Location = new System.Drawing.Point(48, 126);
            this.lblUl.Name = "lblUl";
            this.lblUl.Size = new System.Drawing.Size(80, 16);
            this.lblUl.TabIndex = 24;
            this.lblUl.Text = "0";
            this.lblUl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDl
            // 
            this.lblDl.BackColor = System.Drawing.SystemColors.Info;
            this.lblDl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDl.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDl.Location = new System.Drawing.Point(129, 126);
            this.lblDl.Name = "lblDl";
            this.lblDl.Size = new System.Drawing.Size(80, 16);
            this.lblDl.TabIndex = 23;
            this.lblDl.Text = "0";
            this.lblDl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUlLbl
            // 
            this.lblUlLbl.BackColor = System.Drawing.SystemColors.Info;
            this.lblUlLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUlLbl.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblUlLbl.Location = new System.Drawing.Point(48, 75);
            this.lblUlLbl.Name = "lblUlLbl";
            this.lblUlLbl.Size = new System.Drawing.Size(80, 16);
            this.lblUlLbl.TabIndex = 22;
            this.lblUlLbl.Text = "Up";
            this.lblUlLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDlLbl
            // 
            this.lblDlLbl.BackColor = System.Drawing.SystemColors.Info;
            this.lblDlLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDlLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDlLbl.Location = new System.Drawing.Point(129, 75);
            this.lblDlLbl.Name = "lblDlLbl";
            this.lblDlLbl.Size = new System.Drawing.Size(80, 16);
            this.lblDlLbl.TabIndex = 21;
            this.lblDlLbl.Text = "Down";
            this.lblDlLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSrUp
            // 
            this.lblSrUp.BackColor = System.Drawing.SystemColors.Info;
            this.lblSrUp.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrUp.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSrUp.Location = new System.Drawing.Point(48, 92);
            this.lblSrUp.Name = "lblSrUp";
            this.lblSrUp.Size = new System.Drawing.Size(80, 16);
            this.lblSrUp.TabIndex = 20;
            this.lblSrUp.Text = "0";
            this.lblSrUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSrLbl
            // 
            this.lblSrLbl.BackColor = System.Drawing.SystemColors.Info;
            this.lblSrLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrLbl.Location = new System.Drawing.Point(3, 92);
            this.lblSrLbl.Name = "lblSrLbl";
            this.lblSrLbl.Size = new System.Drawing.Size(44, 16);
            this.lblSrLbl.TabIndex = 19;
            this.lblSrLbl.Text = "Packets";
            this.lblSrLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCNetInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblBytesLbl);
            this.Controls.Add(this.lblBytesUp);
            this.Controls.Add(this.lblBytesDown);
            this.Controls.Add(this.lblSpace);
            this.Controls.Add(this.lblSpeedLbl);
            this.Controls.Add(this.lblSrDown);
            this.Controls.Add(this.lblUl);
            this.Controls.Add(this.lblDl);
            this.Controls.Add(this.lblUlLbl);
            this.Controls.Add(this.lblDlLbl);
            this.Controls.Add(this.lblSrUp);
            this.Controls.Add(this.lblSrLbl);
            this.Controls.Add(this.lblName);
            this.Name = "UCNetInterface";
            this.Size = new System.Drawing.Size(211, 155);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label LblBytesLbl;
        private System.Windows.Forms.Label lblBytesUp;
        private System.Windows.Forms.Label lblBytesDown;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Label lblSpeedLbl;
        private System.Windows.Forms.Label lblSrDown;
        private System.Windows.Forms.Label lblUl;
        private System.Windows.Forms.Label lblDl;
        private System.Windows.Forms.Label lblUlLbl;
        private System.Windows.Forms.Label lblDlLbl;
        private System.Windows.Forms.Label lblSrUp;
        private System.Windows.Forms.Label lblSrLbl;
    }
}
