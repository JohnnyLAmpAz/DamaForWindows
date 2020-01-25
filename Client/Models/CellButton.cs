using DamaLib.Models.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form.Models
{
    public class CellButton : Button
    {
        public CellButton(int posizione)
        {
            if (!Posizioni.IsValid(posizione))
                throw new Exception("Posizione non valida");
            Posizione = posizione;
            Name = "cella" + Posizione;
            Dock = DockStyle.Fill;
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.FromArgb(33, 33, 33);
            Margin = new Padding(0);
            FlatAppearance.BorderSize = 0;
        }

        public int Posizione { get; private set; }
    }
}
