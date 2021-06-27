
namespace kino
{
    partial class Choice
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
            this.btnREZERV = new System.Windows.Forms.Button();
            this.lbKINO = new System.Windows.Forms.Label();
            this.lbFILM = new System.Windows.Forms.Label();
            this.lbSEANS = new System.Windows.Forms.Label();
            this.lblCENA = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnREZERV
            // 
            this.btnREZERV.Location = new System.Drawing.Point(68, 163);
            this.btnREZERV.Name = "btnREZERV";
            this.btnREZERV.Size = new System.Drawing.Size(122, 44);
            this.btnREZERV.TabIndex = 1;
            this.btnREZERV.Text = "Zarezerwować";
            this.btnREZERV.UseVisualStyleBackColor = true;
            this.btnREZERV.Click += new System.EventHandler(this.btnREZERV_Click);
            // 
            // lbKINO
            // 
            this.lbKINO.AutoSize = true;
            this.lbKINO.Location = new System.Drawing.Point(65, 29);
            this.lbKINO.Name = "lbKINO";
            this.lbKINO.Size = new System.Drawing.Size(52, 17);
            this.lbKINO.TabIndex = 2;
            this.lbKINO.Text = "lbKINO";
            // 
            // lbFILM
            // 
            this.lbFILM.AutoSize = true;
            this.lbFILM.Location = new System.Drawing.Point(65, 64);
            this.lbFILM.Name = "lbFILM";
            this.lbFILM.Size = new System.Drawing.Size(49, 17);
            this.lbFILM.TabIndex = 3;
            this.lbFILM.Text = "lbFILM";
            // 
            // lbSEANS
            // 
            this.lbSEANS.AutoSize = true;
            this.lbSEANS.Location = new System.Drawing.Point(65, 99);
            this.lbSEANS.Name = "lbSEANS";
            this.lbSEANS.Size = new System.Drawing.Size(65, 17);
            this.lbSEANS.TabIndex = 4;
            this.lbSEANS.Text = "lbSEANS";
            // 
            // lblCENA
            // 
            this.lblCENA.AutoSize = true;
            this.lblCENA.Location = new System.Drawing.Point(65, 131);
            this.lblCENA.Name = "lblCENA";
            this.lblCENA.Size = new System.Drawing.Size(59, 17);
            this.lblCENA.TabIndex = 6;
            this.lblCENA.Text = "lblCENA";
            // 
            // Choice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 253);
            this.Controls.Add(this.lblCENA);
            this.Controls.Add(this.lbSEANS);
            this.Controls.Add(this.lbFILM);
            this.Controls.Add(this.lbKINO);
            this.Controls.Add(this.btnREZERV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Choice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choice";
            this.Load += new System.EventHandler(this.Choice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnREZERV;
        private System.Windows.Forms.Label lbKINO;
        private System.Windows.Forms.Label lbFILM;
        private System.Windows.Forms.Label lbSEANS;
        private System.Windows.Forms.Label lblCENA;
    }
}