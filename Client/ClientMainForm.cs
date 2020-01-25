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

namespace Form
{
    public partial class ClientMainForm : System.Windows.Forms.Form
    {
        public ClientMainForm()
        {
            InitializeComponent();

            // Attach panel to Damiera class
            Damiera damiera = new Damiera(damieraPanel);
        }   
    }
}
