﻿namespace Client
{
    partial class JoinLobbyForm
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
            this.lvLobbies = new System.Windows.Forms.ListView();
            this.chNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCreatore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnJoinLobby = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvLobbies
            // 
            this.lvLobbies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLobbies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNome,
            this.chCreatore});
            this.lvLobbies.HideSelection = false;
            this.lvLobbies.Location = new System.Drawing.Point(13, 13);
            this.lvLobbies.Name = "lvLobbies";
            this.lvLobbies.Size = new System.Drawing.Size(224, 284);
            this.lvLobbies.TabIndex = 0;
            this.lvLobbies.UseCompatibleStateImageBehavior = false;
            this.lvLobbies.View = System.Windows.Forms.View.Details;
            // 
            // chNome
            // 
            this.chNome.Text = "Nome";
            this.chNome.Width = 120;
            // 
            // chCreatore
            // 
            this.chCreatore.Text = "Creatore";
            this.chCreatore.Width = 100;
            // 
            // btnJoinLobby
            // 
            this.btnJoinLobby.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJoinLobby.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoinLobby.Location = new System.Drawing.Point(103, 304);
            this.btnJoinLobby.Name = "btnJoinLobby";
            this.btnJoinLobby.Size = new System.Drawing.Size(134, 57);
            this.btnJoinLobby.TabIndex = 1;
            this.btnJoinLobby.Text = "Joina";
            this.btnJoinLobby.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(13, 304);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 57);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // JoinLobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 373);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnJoinLobby);
            this.Controls.Add(this.lvLobbies);
            this.Name = "JoinLobbyForm";
            this.Text = "JoinLobbyForm";
            this.Load += new System.EventHandler(this.JoinLobbyForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLobbies;
        private System.Windows.Forms.ColumnHeader chNome;
        private System.Windows.Forms.ColumnHeader chCreatore;
        private System.Windows.Forms.Button btnJoinLobby;
        private System.Windows.Forms.Button btnRefresh;
    }
}