
namespace kino
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.cmdOrder = new System.Windows.Forms.Button();
            this.btnLoadFILM = new System.Windows.Forms.Button();
            this.brnLoadKINO = new System.Windows.Forms.Button();
            this.btnLoadMESTO = new System.Windows.Forms.Button();
            this.btnLoadSEANS = new System.Windows.Forms.Button();
            this.btnLoadPRICE = new System.Windows.Forms.Button();
            this.btnLoadCHAIR = new System.Windows.Forms.Button();
            this.btnLoadCATEGORY = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDATABASE = new System.Windows.Forms.Panel();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnLOGIN = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOrder
            // 
            this.cmdOrder.Location = new System.Drawing.Point(22, 208);
            this.cmdOrder.Name = "cmdOrder";
            this.cmdOrder.Size = new System.Drawing.Size(208, 52);
            this.cmdOrder.TabIndex = 1;
            this.cmdOrder.Text = "Order";
            this.cmdOrder.UseVisualStyleBackColor = true;
            this.cmdOrder.Click += new System.EventHandler(this.cmdOrder_Click);
            // 
            // btnLoadFILM
            // 
            this.btnLoadFILM.Location = new System.Drawing.Point(559, 89);
            this.btnLoadFILM.Name = "btnLoadFILM";
            this.btnLoadFILM.Size = new System.Drawing.Size(163, 40);
            this.btnLoadFILM.TabIndex = 2;
            this.btnLoadFILM.Text = "Load Film";
            this.btnLoadFILM.UseVisualStyleBackColor = true;
            this.btnLoadFILM.Click += new System.EventHandler(this.btnLoadFILM_Click);
            // 
            // brnLoadKINO
            // 
            this.brnLoadKINO.Location = new System.Drawing.Point(559, 133);
            this.brnLoadKINO.Name = "brnLoadKINO";
            this.brnLoadKINO.Size = new System.Drawing.Size(163, 40);
            this.brnLoadKINO.TabIndex = 3;
            this.brnLoadKINO.Text = "Load Kino";
            this.brnLoadKINO.UseVisualStyleBackColor = true;
            this.brnLoadKINO.Click += new System.EventHandler(this.brnLoadKINO_Click);
            // 
            // btnLoadMESTO
            // 
            this.btnLoadMESTO.Location = new System.Drawing.Point(559, 179);
            this.btnLoadMESTO.Name = "btnLoadMESTO";
            this.btnLoadMESTO.Size = new System.Drawing.Size(163, 40);
            this.btnLoadMESTO.TabIndex = 4;
            this.btnLoadMESTO.Text = "Load Miejsce";
            this.btnLoadMESTO.UseVisualStyleBackColor = true;
            this.btnLoadMESTO.Click += new System.EventHandler(this.btnLoadMESTO_Click);
            // 
            // btnLoadSEANS
            // 
            this.btnLoadSEANS.Location = new System.Drawing.Point(559, 317);
            this.btnLoadSEANS.Name = "btnLoadSEANS";
            this.btnLoadSEANS.Size = new System.Drawing.Size(163, 40);
            this.btnLoadSEANS.TabIndex = 5;
            this.btnLoadSEANS.Text = "Load Seans";
            this.btnLoadSEANS.UseVisualStyleBackColor = true;
            this.btnLoadSEANS.Click += new System.EventHandler(this.btnLoadSEANS_Click);
            // 
            // btnLoadPRICE
            // 
            this.btnLoadPRICE.Location = new System.Drawing.Point(559, 363);
            this.btnLoadPRICE.Name = "btnLoadPRICE";
            this.btnLoadPRICE.Size = new System.Drawing.Size(163, 40);
            this.btnLoadPRICE.TabIndex = 6;
            this.btnLoadPRICE.Text = "Load Price";
            this.btnLoadPRICE.UseVisualStyleBackColor = true;
            this.btnLoadPRICE.Click += new System.EventHandler(this.btnLoadPRICE_Click);
            // 
            // btnLoadCHAIR
            // 
            this.btnLoadCHAIR.Location = new System.Drawing.Point(559, 225);
            this.btnLoadCHAIR.Name = "btnLoadCHAIR";
            this.btnLoadCHAIR.Size = new System.Drawing.Size(163, 40);
            this.btnLoadCHAIR.TabIndex = 7;
            this.btnLoadCHAIR.Text = "Load Chair";
            this.btnLoadCHAIR.UseVisualStyleBackColor = true;
            this.btnLoadCHAIR.Click += new System.EventHandler(this.btnLoadCHAIR_Click);
            // 
            // btnLoadCATEGORY
            // 
            this.btnLoadCATEGORY.Location = new System.Drawing.Point(559, 271);
            this.btnLoadCATEGORY.Name = "btnLoadCATEGORY";
            this.btnLoadCATEGORY.Size = new System.Drawing.Size(163, 40);
            this.btnLoadCATEGORY.TabIndex = 8;
            this.btnLoadCATEGORY.Text = "Load Category";
            this.btnLoadCATEGORY.UseVisualStyleBackColor = true;
            this.btnLoadCATEGORY.Click += new System.EventHandler(this.btnLoadCATEGORY_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(295, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "Projekt \"Kino\" w61765";
            // 
            // pnlDATABASE
            // 
            this.pnlDATABASE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDATABASE.Location = new System.Drawing.Point(552, 83);
            this.pnlDATABASE.Name = "pnlDATABASE";
            this.pnlDATABASE.Size = new System.Drawing.Size(176, 327);
            this.pnlDATABASE.TabIndex = 10;
            // 
            // pnlLogin
            // 
            this.pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogin.Controls.Add(this.btnLOGIN);
            this.pnlLogin.Controls.Add(this.btnRegister);
            this.pnlLogin.Location = new System.Drawing.Point(22, 83);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(208, 85);
            this.pnlLogin.TabIndex = 11;
            // 
            // btnLOGIN
            // 
            this.btnLOGIN.Location = new System.Drawing.Point(4, 3);
            this.btnLOGIN.Name = "btnLOGIN";
            this.btnLOGIN.Size = new System.Drawing.Size(200, 35);
            this.btnLOGIN.TabIndex = 0;
            this.btnLOGIN.Text = "Zaloguj się (ACCOUNT)";
            this.btnLOGIN.UseVisualStyleBackColor = true;
            this.btnLOGIN.Click += new System.EventHandler(this.btnLOGIN_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(4, 44);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(200, 35);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Zarejestrować się";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(740, 485);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadCATEGORY);
            this.Controls.Add(this.btnLoadCHAIR);
            this.Controls.Add(this.btnLoadPRICE);
            this.Controls.Add(this.btnLoadSEANS);
            this.Controls.Add(this.btnLoadMESTO);
            this.Controls.Add(this.brnLoadKINO);
            this.Controls.Add(this.btnLoadFILM);
            this.Controls.Add(this.cmdOrder);
            this.Controls.Add(this.pnlDATABASE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kino w61765";
            this.Activated += new System.EventHandler(this.mainForm_Activated);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.pnlLogin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdOrder;
        private System.Windows.Forms.Button btnLoadFILM;
        private System.Windows.Forms.Button brnLoadKINO;
        private System.Windows.Forms.Button btnLoadMESTO;
        private System.Windows.Forms.Button btnLoadSEANS;
        private System.Windows.Forms.Button btnLoadPRICE;
        private System.Windows.Forms.Button btnLoadCHAIR;
        private System.Windows.Forms.Button btnLoadCATEGORY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDATABASE;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btnLOGIN;
        private System.Windows.Forms.Button btnRegister;
    }
}