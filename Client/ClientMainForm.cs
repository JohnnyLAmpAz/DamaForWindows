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

namespace Form
{
    public partial class ClientMainForm : System.Windows.Forms.Form
    {
        public ClientMainForm()
        {
            InitializeComponent();

            // Inserimento dei bottoni cella nella TableLayoutPanel
            damiera.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            for(int i=1;i<=32;i++)
            {
                Coordinate c = Posizioni.CoordFromPos(i);
                Button b = new Button()
                {
                    Name = "cella" + i,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(33,33,33),
                    Margin = new Padding(0)
                };
                b.FlatAppearance.BorderSize = 0;
                damiera.Controls.Add(b, c.X, c.Y);
            }
        }
            
    }
}
