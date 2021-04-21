using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Auto
    {
        public string Model { get; set; }
        public string Kleur { get; set; }

        public int Bouwjaar { get; set; }
        public int AantalKm { get; set; }
        public Brandstof Brandstof { get; set; }

        public static bool operator <(Auto left, Auto right)
        {
            return left.AantalKm < right.AantalKm;
        }
        public static bool operator >(Auto left, Auto right)
        {
            return left.AantalKm > right.AantalKm;
        }

        public override string ToString()
        {
            return $"{Model} (kleur: {Kleur}, bj:{Bouwjaar}, km:{AantalKm})";
        }
    }

    public enum Brandstof
    { 
        Benzine,
        Diesel,
        Electriciteit,
        Waterstof
    }

}
