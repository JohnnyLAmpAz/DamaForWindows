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
            var lsMosse = s.FindPossiblePlayerMooves();
            lsMosse.Contains(lsMosse[0]);
            lsMosse.Contains(new Mossa(new List<Coordinate>() { new Coordinate(lsMosse[0].From), new Coordinate(lsMosse[0].To) },new List<Coordinate>()));

            foreach (var m in lsMosse)
            {
                Console.WriteLine($"({m.From})->({m.To})");
            }

            s.Play(lsMosse[2]);

            Console.WriteLine("Mosse disponibili del giocatore " + (s.Turno ? "bianco" : "nero"));
            lsMosse = s.FindPossiblePlayerMooves();
            foreach (var m in lsMosse)
            {
                Console.WriteLine($"({m.From})->({m.To})");
            }

            s.Play(lsMosse[0]);

            Console.WriteLine("Mosse disponibili del giocatore " + (s.Turno ? "bianco" : "nero"));
            lsMosse = s.FindPossiblePlayerMooves();
            foreach (var m in lsMosse)
            {
                Console.WriteLine($"({m.From})->({m.To})");
            }


            Console.ReadKey();
        }
    }
}
