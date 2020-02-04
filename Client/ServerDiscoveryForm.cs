using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using DamaLib.Models.BackEnd;
using DamaLib;

namespace Client
{
    public partial class ServerDiscoveryForm : System.Windows.Forms.Form
    {
        ClientDama client;
        public ServerDiscoveryForm(ClientDama client)
        {
            InitializeComponent();
            this.client = client;

            DiscoverServer();
        }

        private void btnDiscover_Click(object sender, EventArgs e) => DiscoverServer();

        private void DiscoverServer()
        {
            if(client.DiscoverServer())
            {
                // Aggiorno la form
                lblOutput.Text = client.Server.ToString();
                btnCreateLobby.Enabled = true;
                btnJoinLobby.Enabled = true;
            }
            else
            {
                // Aggiorno la form
                lblOutput.Text = "Not Found";
                btnCreateLobby.Enabled = false;
                btnJoinLobby.Enabled = false;
            }

        }

        private void btnJoinLobby_Click(object sender, EventArgs e)
        {
            JoinLobbyForm joinLobbyForm = new JoinLobbyForm(client);
            joinLobbyForm.ShowDialog();
        }

        private void btnCreateLobby_Click(object sender, EventArgs e)
        {
            // invio richiesta
            string res = client.CreateLobby(tbNomeLobby.Text);

            // Se tutto è andato bene
            if (res.Equals(Constants.Responses.Ok))
            {
                // TODO: continua: fai nuova form per creatore lobby
            }
        }
    }
}
