﻿using System;
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
            List<string> ingredients;

            public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
            {
                this.nom = nom;
                this.prix = prix;
                this.vegetarienne = vegetarienne;
                this.ingredients = ingredients;
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
                Console.WriteLine(string.Join(", ", ingredients));
                Console.WriteLine();
            }

            private static string FormatPremiereLettreMajuscules(string s)
            {
                if (string.IsNullOrEmpty(s))
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
                new Pizza("4 fromages", 11.2f, true, new List<string>{"cantal", "mozzarella", "fromage de chèvre", "gruyère"}),
                new Pizza("indienne", 10.5f, false, new List<string>{"curry", "mozzarella", "poulet", "poivron", "oignon", "coriandre"}),
                new Pizza("mexicaine", 13f, false, new List<string>{"boef", "mozzarella", "maïs", "tomates", "oignon", "coriandre"}),
                new Pizza("margarita", 8f, true, new List<string>{"sauce tomate", "mozzarella", "basilic"}),
                new Pizza("calzone", 12f, false, new List<string>{"tomate", "jambon", "persil", "fromage"}),
                new Pizza("complète", 9.5f, false, new List<string>{"jambon", "oeuf", "fromage"}),
            };

            foreach(var pizza in pizzas)
            {
                pizza.Afficher();
            }
            Console.Clear();
        }
    }
}