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
using System.Threading;

namespace Form
{
    public partial class ClientMainForm : System.Windows.Forms.Form
    {
        ClientDama client;

        public ClientMainForm(ClientDama client)
        {
            InitializeComponent();
            this.client = client;

            // Attach panel to Damiera class
            Damiera damiera = new Damiera(damieraPanel);

            for (int i = 1; i < 33; i++)
                damiera[i].Click += CellaClick;
            timer1.Enabled = true;
          
            CheckForIllegalCrossThreadCalls = false;
        }
        
        private void CellaClick(object sender, EventArgs e)
        {
            // TODO: ONLY FOR TEST PURPOSE. REMOVE
            CellButton c = sender as CellButton;
            label1.Text = c.Posizione.ToString();
            c.Stato = (CellButton.Status)(((int)c.Stato + 1) % 5);
        }
       public static DateTime time = default;
       public static DateTime times;
       TimeSpan secondo = TimeSpan.FromSeconds(1);
         
        public void iniziaPartita()
        {
            timer1.Enabled = true;
        }
        private void drawButton_Click(object sender, EventArgs e)
        {

        }     

        private void timer1_Tick(object sender, EventArgs e)
        {
            int st = 00;
            int m = 00;

            string stime = "00:00";
            if (st == 60)
            {
                m++;
                st = 00;
            }
            else
            {
                st++;
            }
            if (m == 60)
            {
                m = 00;
            }
            if (st < 10)
            {
                st = 0 + st;
            }
            if (m < 10)
            {
                m = 0 + m;
            }
            stime = m.ToString() + ":" + st.ToString();
            label6.Text = stime;

            times = time.Add(secondo);
                label6.Text = times.ToLongTimeString();
            
        }
    }
}
