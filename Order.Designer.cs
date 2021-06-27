
namespace kino
{
    partial class Order
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
            this.gridKINO = new System.Windows.Forms.DataGridView();
            this.gridSEANS = new System.Windows.Forms.DataGridView();
            this.lbKINO = new System.Windows.Forms.Label();
            this.lbSEANS = new System.Windows.Forms.Label();
            this.pnlREZERV = new System.Windows.Forms.Panel();
            this.btnREZERV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridKINO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSEANS)).BeginInit();
            this.SuspendLayout();
            // 
            // gridKINO
            // 
            this.gridKINO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKINO.Location = new System.Drawing.Point(12, 29);
            this.gridKINO.Name = "gridKINO";
            this.gridKINO.RowHeadersWidth = 51;
            this.gridKINO.RowTemplate.Height = 24;
            this.gridKINO.Size = new System.Drawing.Size(821, 160);
            this.gridKINO.TabIndex = 2;
            this.gridKINO.SelectionChanged += new System.EventHandler(this.gridKINO_SelectionChanged);
            // 
            // gridSEANS
            // 
            this.gridSEANS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSEANS.Location = new System.Drawing.Point(12, 218);
            this.gridSEANS.Name = "gridSEANS";
            this.gridSEANS.RowHeadersWidth = 51;
            this.gridSEANS.RowTemplate.Height = 24;
            this.gridSEANS.Size = new System.Drawing.Size(821, 150);
            this.gridSEANS.TabIndex = 4;
            this.gridSEANS.SelectionChanged += new System.EventHandler(this.gridSEANS_SelectionChanged);
            // 
            // lbKINO
            // 
            this.lbKINO.AutoSize = true;
            this.lbKINO.Location = new System.Drawing.Point(12, 9);
            this.lbKINO.Name = "lbKINO";
            this.lbKINO.Size = new System.Drawing.Size(36, 17);
            this.lbKINO.TabIndex = 5;
            this.lbKINO.Text = "Kino";
            // 
            // lbSEANS
            // 
            this.lbSEANS.AutoSize = true;
            this.lbSEANS.Location = new System.Drawing.Point(12, 197);
            this.lbSEANS.Name = "lbSEANS";
            this.lbSEANS.Size = new System.Drawing.Size(55, 17);
            this.lbSEANS.TabIndex = 6;
            this.lbSEANS.Text = "Seansy";
            // 
            // pnlREZERV
            // 
            this.pnlREZERV.AutoScroll = true;
            this.pnlREZERV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlREZERV.Location = new System.Drawing.Point(12, 418);
            this.pnlREZERV.Name = "pnlREZERV";
            this.pnlREZERV.Size = new System.Drawing.Size(820, 164);
            this.pnlREZERV.TabIndex = 8;
            // 
            // btnREZERV
            // 
            this.btnREZERV.Location = new System.Drawing.Point(12, 374);
            this.btnREZERV.Name = "btnREZERV";
            this.btnREZERV.Size = new System.Drawing.Size(149, 40);
            this.btnREZERV.TabIndex = 9;
            this.btnREZERV.Text = "Zamowienie";
            this.btnREZERV.UseVisualStyleBackColor = true;
            this.btnREZERV.Click += new System.EventHandler(this.btnREZERV_Click);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(853, 604);
            this.Controls.Add(this.btnREZERV);
            this.Controls.Add(this.pnlREZERV);
            this.Controls.Add(this.lbSEANS);
            this.Controls.Add(this.lbKINO);
            this.Controls.Add(this.gridSEANS);
            this.Controls.Add(this.gridKINO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.Activated += new System.EventHandler(this.Order_Activated);
            this.Load += new System.EventHandler(this.Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridKINO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSEANS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gridKINO;
        private System.Windows.Forms.DataGridView gridSEANS;
        private System.Windows.Forms.Label lbKINO;
        private System.Windows.Forms.Label lbSEANS;
        private System.Windows.Forms.Panel pnlREZERV;
        private System.Windows.Forms.Button btnREZERV;
    }
}