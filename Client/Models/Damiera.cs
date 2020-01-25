using DamaLib.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form.Models
{
    public class Damiera
    {
        CellButton[] celle;
        public TableLayoutPanel Panel { get; private set; }

        public Damiera(TableLayoutPanel panel)
        {
            Panel = panel;

            // Setup
            Panel.ColumnCount = 8;
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            Panel.Location = new System.Drawing.Point(24, 24);
            Panel.Name = "damiera";
            Panel.RowCount = 8;
            Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            Panel.Size = new System.Drawing.Size(500, 500);
            Panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            Panel.TabIndex = 0;

            // Popolamento delle celle con i CellButton
            celle = new CellButton[32];
            for (int i = 0; i < 32; i++)
            {
                celle[i] = new CellButton(i+1);
                Coordinate c = Posizioni.CoordFromPos(i+1);
                Panel.Controls.Add(celle[i], c.X, c.Y);
            }
        }
    }
}
