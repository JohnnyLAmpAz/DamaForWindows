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
        public enum Status
        {
            Vuota,
            PedinaBianca,
            PedinaNera,
            DamaBianca,
            DamaNera
        }
        private Dictionary<Status, string> immagini = new Dictionary<Status, string>()
        {
            { Status.Vuota, "PATH" },
            { Status.PedinaBianca, "PATH" },
            { Status.PedinaNera, "PATH" },
            { Status.DamaBianca, "PATH" },
            { Status.DamaNera, "PATH" },
        };

        private Status stato;
        public int Posizione { get; private set; }
        public Status Stato
        {
            get => stato;
            set
            {
                BackgroundImage = Bitmap.FromFile(immagini[value]);
                BackgroundImageLayout = ImageLayout.Zoom;
                stato = value;
            }
        }

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
            Stato = Status.Vuota;
        }
    }
}
