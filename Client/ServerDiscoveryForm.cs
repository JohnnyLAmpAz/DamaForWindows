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

namespace Client
{
    public partial class ServerDiscoveryForm : System.Windows.Forms.Form
    {
        public ServerDiscoveryForm()
        {
            InitializeComponent();
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            UdpClient client = new UdpClient();

            // Setto come destinatario indirizzo broadcast
            IPEndPoint server = new IPEndPoint(IPAddress.Broadcast, 55555);

            // Richiesta
            byte[] buff = Encoding.ASCII.GetBytes("DamaServerDiscoveryRequest");
            client.Send(buff, buff.Length, server);

            // Catch risposta
            buff = client.Receive(ref server);
            if (Encoding.ASCII.GetString(buff).Equals("HereIAm!"))
                lblOutput.Text = server.Address.ToString();
        }
    }
}
