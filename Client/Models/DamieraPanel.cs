using DamaLib.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form.Models
{
    public class DamieraPanel : TableLayoutPanel
    {
        CellButton[] celle;

        public DamieraPanel()
        {
            celle = new CellButton[32];
            for (int i = 0; i < 32; i++)
            {
                celle[i] = new CellButton(i+1);
                Coordinate c = Posizioni.CoordFromPos(i+1);
                Controls.Add(celle[i], c.X, c.Y);
            }

        }
    }
}
