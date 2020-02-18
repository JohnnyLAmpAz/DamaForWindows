using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;
using DamaLib.Models;
using DamaLib.Models.Core;
using Form.Models;
using DamaLib.Models.BackEnd;
namespace Form
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // DEBUG ONLY! DELETE
            Application.Run(new ClientMainForm(new ClientDama()));
            //Application.Run(new ServerDiscoveryForm());
        
        }
    }
}
