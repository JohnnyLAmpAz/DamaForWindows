namespace Client
{
    partial class ServerDiscoveryForm
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
            this.btnDiscover = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnJoinLobby = new System.Windows.Forms.Button();
            this.btnCreateLobby = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNomeLobby = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDiscover
            // 
            this.btnDiscover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscover.Location = new System.Drawing.Point(12, 252);
            this.btnDiscover.Name = "btnDiscover";
            this.btnDiscover.Size = new System.Drawing.Size(263, 36);
            this.btnDiscover.TabIndex = 0;
            this.btnDiscover.Text = "Refresh";
            this.btnDiscover.UseVisualStyleBackColor = true;
            this.btnDiscover.Click += new System.EventHandler(this.btnDiscover_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(12, 42);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(263, 123);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "Not Found";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJoinLobby
            // 
            this.btnJoinLobby.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJoinLobby.Enabled = false;
            this.btnJoinLobby.Location = new System.Drawing.Point(12, 210);
            this.btnJoinLobby.Name = "btnJoinLobby";
            this.btnJoinLobby.Size = new System.Drawing.Size(263, 36);
            this.btnJoinLobby.TabIndex = 0;
            this.btnJoinLobby.Text = "Joina Lobby";
            this.btnJoinLobby.UseVisualStyleBackColor = true;
            this.btnJoinLobby.Click += new System.EventHandler(this.btnJoinLobby_Click);
            // 
            // btnCreateLobby
            // 
            this.btnCreateLobby.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateLobby.Enabled = false;
            this.btnCreateLobby.Location = new System.Drawing.Point(200, 168);
            this.btnCreateLobby.Name = "btnCreateLobby";
            this.btnCreateLobby.Size = new System.Drawing.Size(75, 36);
            this.btnCreateLobby.TabIndex = 0;
            this.btnCreateLobby.Text = "Crea Lobby";
            this.btnCreateLobby.UseVisualStyleBackColor = true;
            this.btnCreateLobby.Click += new System.EventHandler(this.btnCreateLobby_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server:";
            // 
            // tbNomeLobby
            // 
            this.tbNomeLobby.Location = new System.Drawing.Point(12, 177);
            this.tbNomeLobby.Name = "tbNomeLobby";
            this.tbNomeLobby.Size = new System.Drawing.Size(182, 20);
            this.tbNomeLobby.TabIndex = 2;
            // 
            // ServerDiscoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 300);
            this.Controls.Add(this.tbNomeLobby);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnCreateLobby);
            this.Controls.Add(this.btnJoinLobby);
            this.Controls.Add(this.btnDiscover);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerDiscoveryForm";
            this.Text = "ServerDiscoveryForm";
            this.Shown += new System.EventHandler(this.ServerDiscoveryForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDiscover;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnJoinLobby;
        private System.Windows.Forms.Button btnCreateLobby;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNomeLobby;
    }
}