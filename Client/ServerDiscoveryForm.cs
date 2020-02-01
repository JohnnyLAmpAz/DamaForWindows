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

namespace Client
{
    public partial class ServerDiscoveryForm : System.Windows.Forms.Form
    {
        ClientDama client;
        public ServerDiscoveryForm(ClientDama client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();

            // Setto come destinatario indirizzo broadcast
            IPEndPoint server = new IPEndPoint(IPAddress.Broadcast, 55555);

            // Richiesta
            byte[] buff = Encoding.ASCII.GetBytes("DamaServerDiscoveryRequest");
            udpClient.Send(buff, buff.Length, server);

            // Catch risposta e mi salvo l'IP del server
            buff = udpClient.Receive(ref server);
            if (Encoding.ASCII.GetString(buff).Equals("HereIAm!"))
                client.Server = server.Address;
        }
    }
}
