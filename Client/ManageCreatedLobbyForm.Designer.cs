namespace Client
{
    partial class ManageCreatedLobbyForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblNomeLobby = new System.Windows.Forms.Label();
            this.btnDeleteLobby = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartMatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome lobby:";
            // 
            // lblNomeLobby
            // 
            this.lblNomeLobby.AutoSize = true;
            this.lblNomeLobby.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeLobby.Location = new System.Drawing.Point(117, 16);
            this.lblNomeLobby.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeLobby.Name = "lblNomeLobby";
            this.lblNomeLobby.Size = new System.Drawing.Size(194, 25);
            this.lblNomeLobby.TabIndex = 0;
            this.lblNomeLobby.Text = "<NOME_LOBBY>";
            // 
            // btnDeleteLobby
            // 
            this.btnDeleteLobby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteLobby.Location = new System.Drawing.Point(235, 94);
            this.btnDeleteLobby.Name = "btnDeleteLobby";
            this.btnDeleteLobby.Size = new System.Drawing.Size(132, 68);
            this.btnDeleteLobby.TabIndex = 1;
            this.btnDeleteLobby.Text = "Elimina lobby";
            this.btnDeleteLobby.UseVisualStyleBackColor = true;
            this.btnDeleteLobby.Click += new System.EventHandler(this.btnDeleteLobby_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP sfidante:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(110, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "In attesa che qualquno joini...";
            // 
            // btnStartMatch
            // 
            this.btnStartMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartMatch.Enabled = false;
            this.btnStartMatch.Location = new System.Drawing.Point(12, 94);
            this.btnStartMatch.Name = "btnStartMatch";
            this.btnStartMatch.Size = new System.Drawing.Size(217, 68);
            this.btnStartMatch.TabIndex = 1;
            this.btnStartMatch.Text = "Starta partita";
            this.btnStartMatch.UseVisualStyleBackColor = true;
            // 
            // ManageCreatedLobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 174);
            this.Controls.Add(this.btnStartMatch);
            this.Controls.Add(this.btnDeleteLobby);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNomeLobby);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ManageCreatedLobbyForm";
            this.Text = "ManageCreatedForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageCreatedLobbyForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageCreatedLobbyForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNomeLobby;
        private System.Windows.Forms.Button btnDeleteLobby;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartMatch;
    }
}