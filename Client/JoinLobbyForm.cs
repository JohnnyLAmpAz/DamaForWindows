using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DamaLib;
using DamaLib.Models.BackEnd;
using DamaLib.Models.BackEnd.Core;
using Newtonsoft.Json;

namespace Client
{
    public partial class JoinLobbyForm : System.Windows.Forms.Form
    {
        ClientDama client;
        private string nomeLobby;
        private bool joined = false;

        public JoinLobbyForm(ClientDama client)
        {
            this.client = client;
            InitializeComponent();
            lvLobbies.FullRowSelect = true;
            lvLobbies.MultiSelect = false;
        }

        private void JoinLobbyForm_Load(object sender, EventArgs e)
        {
            RefreshLobbies();
        }

        private void SetJoinedStatus(bool status)
        {
            if (status != joined)
            {
                if (status)
                {
                    lvLobbies.Enabled = false;
                    btnRefresh.Enabled = false;
                    btnJoinLobby.Text = "Abbandona";
                    label1.Text = $"Joinata la lobby {nomeLobby}\n" +
                        $"In attesa dell'host...";
                }
                else
                {
                    lvLobbies.Enabled = true;
                    btnRefresh.Enabled = true;
                    btnJoinLobby.Text = "Joina";
                    label1.Text = $"Elenco lobby:";
                }
                joined = status;
            }
        }

        private void RefreshLobbies()
        {
            lvLobbies.Items.Clear();
            List<Lobby> lobbies = client.GetListAvailableLobbies();
            foreach (var lobby in lobbies)
                lvLobbies.Items.Add(new ListViewItem(new string[] { lobby.Nome, lobby.Creatore, lobby.Unito == default ? "Sì" : "No" }));
        }

        private void btnRefresh_Click(object sender, EventArgs e) => RefreshLobbies();

        private void btnJoinLobby_Click(object sender, EventArgs e)
        {
            if (joined)
            {
                string res = client.LeaveLobby(nomeLobby);
                if(res.Equals(Constants.Responses.Ok))
                    SetJoinedStatus(false);
                else
                    MessageBox.Show(res,"Errore, risposta server:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Controllo che sia stata selezionata una lobby disponibile da una lista
                if (lvLobbies.SelectedItems.Count != 1 || lvLobbies.SelectedItems[0].SubItems[2].Text.Equals("No"))
                    MessageBox.Show("è necessario selezionare una ed una sola lobby DISPONIBILE");
                else
                {
                    string res = client.JoinLobby(lvLobbies.SelectedItems[0].SubItems[0].Text);
                    try
                    {
                        Lobby l = JsonConvert.DeserializeObject<Lobby>(res);

                        // Transform form into waiting the host to start
                        nomeLobby = l.Nome;
                        SetJoinedStatus(true);
                    }
                    catch (JsonException)
                    {
                        MessageBox.Show(res,"Errore, risposta server:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
