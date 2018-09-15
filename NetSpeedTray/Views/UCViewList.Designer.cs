namespace Devoldere.NetSpeedTray.Views
{
    partial class UCViewList
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.niName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.niIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.niDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.niUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.State,
            this.niName,
            this.niIp,
            this.niDown,
            this.niUp});
            this.dataGrid.Location = new System.Drawing.Point(3, 3);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(514, 150);
            this.dataGrid.TabIndex = 15;
            // 
            // State
            // 
            this.State.DataPropertyName = "StateText";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // niName
            // 
            this.niName.DataPropertyName = "Name";
            this.niName.HeaderText = "Name";
            this.niName.Name = "niName";
            this.niName.ReadOnly = true;
            // 
            // niIp
            // 
            this.niIp.DataPropertyName = "Ip";
            this.niIp.HeaderText = "IP";
            this.niIp.Name = "niIp";
            this.niIp.ReadOnly = true;
            // 
            // niDown
            // 
            this.niDown.DataPropertyName = "TrafficeDown";
            this.niDown.HeaderText = "Down";
            this.niDown.Name = "niDown";
            this.niDown.ReadOnly = true;
            // 
            // niUp
            // 
            this.niUp.DataPropertyName = "TrafficeUp";
            this.niUp.HeaderText = "Up";
            this.niUp.Name = "niUp";
            this.niUp.ReadOnly = true;
            // 
            // UCNetInterfaceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGrid);
            this.Name = "UCNetInterfaceList";
            this.Size = new System.Drawing.Size(520, 160);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn niName;
        private System.Windows.Forms.DataGridViewTextBoxColumn niIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn niDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn niUp;
    }
}
