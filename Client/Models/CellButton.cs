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
        private Dictionary<Status, Bitmap> immagini = new Dictionary<Status, Bitmap>()
        {
            { Status.Vuota, new Bitmap(Client.Properties.Resources.empty) },
            { Status.PedinaBianca, new Bitmap(Client.Properties.Resources.ped_white) },
            { Status.PedinaNera, new Bitmap(Client.Properties.Resources.ped_black) },
            { Status.DamaBianca, new Bitmap(Client.Properties.Resources.dama_white) },
            { Status.DamaNera, new Bitmap(Client.Properties.Resources.dama_black) },
        };

        private Status stato;
        public int Posizione { get; private set; }
        public Status Stato
        {
            get => stato;
            set
            {
                BackgroundImage = immagini[value];
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
