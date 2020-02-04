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
using DamaLib.Models.BackEnd.Core;

namespace Client
{
    public partial class JoinLobbyForm : System.Windows.Forms.Form
    {
        ClientDama client;
        public JoinLobbyForm(ClientDama client)
        {
            this.client = client;
            InitializeComponent();
            lvLobbies.FullRowSelect = true;
        }

        private void JoinLobbyForm_Load(object sender, EventArgs e)
        {
            RefreshLobbies();
        }

        private void RefreshLobbies()
        {
            lvLobbies.Items.Clear();
            List<Lobby> lobbies = client.GetListAvailableLobbies();
            foreach (var lobby in lobbies)
                lvLobbies.Items.Add(new ListViewItem(new string[] { lobby.Nome, lobby.Creatore }));
        }

        private void btnRefresh_Click(object sender, EventArgs e) => RefreshLobbies();
    }
}
