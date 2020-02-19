using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DamaLib.Models.BackEnd;
using DamaLib;

namespace Client
{
    public partial class ManageCreatedLobbyForm : System.Windows.Forms.Form
    {
        ClientDama client;
        string nomeLobby;
        bool deleted = false;

        public ManageCreatedLobbyForm(string nome, ClientDama client)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            nomeLobby = nome;
            lblNomeLobby.Text = nome;
            this.client = client;
            client.OtherLobbyPlayerJoined += Client_OtherLobbyPlayerJoined;
            client.OtherLobbyPlayerLeft += Client_OtherLobbyPlayerLeft;
        }

        private void Client_OtherLobbyPlayerLeft(object sender, EventArgs e)
        {
            lblGuestIP.Text = "In attesa che qualquno joini...";
            btnStartMatch.Enabled = false;
        }

        private void Client_OtherLobbyPlayerJoined(object sender, OtherLobbyPlayerJoinedEventArgs e)
        {
            lblGuestIP.Text = e.IpUnito;
            btnStartMatch.Enabled = true;
        }

        private void ManageCreatedLobbyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!deleted)
            {
                var window = MessageBox.Show(
                    "Sei siicuro di voler uscire? Procedendo la lobby verra eliminata",
                    "Chiudere la finestra?",
                    MessageBoxButtons.YesNo);

                e.Cancel = (window == DialogResult.No);
            }
        }

        private void ManageCreatedLobbyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!deleted)
                CloseLobby();
        }

        private void CloseLobby()
        {
            string res = client.DeleteLobby(nomeLobby);
            if (!res.Equals(Constants.Responses.Ok))
                MessageBox.Show(res, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                deleted = true;
        }

        private void btnDeleteLobby_Click(object sender, EventArgs e)
        {
            CloseLobby();
            Close();
        }
    }
}
