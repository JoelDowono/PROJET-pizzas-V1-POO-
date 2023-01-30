using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp 
{
    internal class Program
    {
        class Pizza
        {
            string nom;
            float prix;
            bool vegetarienne;

            public Pizza(string nom, float prix, bool vegetarienne)
            {
                this.nom = nom;
                this.prix = prix;
                this.vegetarienne = vegetarienne;
            }

            public void Afficher()
            {
                /*string badgeVegetarienne = " (V)";
                if (!vegetarienne)
                {
                    badgeVegetarienne = "";
                }*/

                string badgeVegetarienne = vegetarienne ? " (V)" : "";

                string nomAfficher = FormatPremiereLettreMajuscules(nom);

                Console.WriteLine(nomAfficher + badgeVegetarienne + " - " + prix + "€");
            }

            private static string FormatPremiereLettreMajuscules(string s)
            {
                if ((s == null) || (s.Length == 0))
                    return s;
                string minuscules = s.ToLower();
                string majuscules = s.ToUpper();

                string resultat = majuscules[0] + minuscules.Substring(1);

                return resultat;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var pizzas = new List<Pizza>() {
                new Pizza("4 fromages", 11.2f, true),
                new Pizza("indienne", 10.5f, false),
                new Pizza("mexicaine", 13f, false),
                new Pizza("margarita", 8f, true),
                new Pizza("calzone", 12f, false),
                new Pizza("complète", 9.5f, false),
            };

            foreach(var pizza in pizzas)
            {
                pizza.Afficher();
            }
        }
    }
}