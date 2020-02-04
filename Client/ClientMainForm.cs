using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DamaLib.Models;
using DamaLib.Models.Core;
using Form.Models;
using DamaLib.Models.BackEnd;
using Client;

namespace Form
{
    public partial class ClientMainForm : System.Windows.Forms.Form
    {
        ClientDama client;

        public ClientMainForm()
        {
            InitializeComponent();
            client = new ClientDama();

            // Attach panel to Damiera class
            Damiera damiera = new Damiera(damieraPanel);

            for (int i = 1; i < 33; i++)
                damiera[i].Click += CellaClick;
        }

        private void CellaClick(object sender, EventArgs e)
        {
            CellButton c = sender as CellButton;
            label1.Text = c.Posizione.ToString();
            c.Stato = (CellButton.Status)(((int)c.Stato + 1) % 5);
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            // Apro form delle lobby
            ServerDiscoveryForm discoveryForm = new ServerDiscoveryForm(client);
            discoveryForm.ShowDialog();
        }
    }
}
