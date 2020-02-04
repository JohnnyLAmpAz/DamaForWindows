using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ManageCreatedLobbyForm : System.Windows.Forms.Form
    {
        public ManageCreatedLobbyForm(string nome)
        {
            InitializeComponent();
            lblNomeLobby.Text = nome;
        }

        private void ManageCreatedLobbyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var window = MessageBox.Show(
                "Chiudere la finestra?",
                "Sei siicuro di voler uscire? Procedendo la lobby verra eliminata",
                MessageBoxButtons.YesNo);

            e.Cancel = (window == DialogResult.No);
        }

        private void ManageCreatedLobbyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseLobby();
        }

        private void CloseLobby()
        {
            // TODO: implement
        }

        private void btnDeleteLobby_Click(object sender, EventArgs e) => CloseLobby();
    }
}
