using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DamaLib.Models;
using DamaLib.Models.Core;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Scacchiera s = new Scacchiera();

            Console.WriteLine("Mosse disponibili del giocatore " + (s.Turno ? "bianco" : "nero"));
            var ls = s.FindPossiblePlayerMooves();
            foreach (var m in ls)
            {
                Console.WriteLine($"({m.From})->({m.To})");
            }

            Console.ReadKey();
        }
    }
}
