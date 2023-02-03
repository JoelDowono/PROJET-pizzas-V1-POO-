﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace projet_pizza
{
    internal class Program
    {
        static int nbPizzasPersonnalisee = 0;

        class PizzaPersonnalisee : Pizza
        {
            public PizzaPersonnalisee() : base("Personnalisée", 5, false, null)
            {
                nbPizzasPersonnalisee++;
                nom = "Personnalisée " + nbPizzasPersonnalisee;
                ingredients = new List<string>();

                while (true)
                {
                    Console.Write("Rentrez un ingredient pour la pizza personnalisée " + nbPizzasPersonnalisee + " (ENTRER pour terminer) : ");
                    var ingredient = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ingredient))
                    {
                        break;
                    }
                    if (ingredients.Contains(ingredient))
                    {
                        Console.WriteLine("Erreur : cet ingredient est déjà présent dans la pizza.");
                    }
                    else
                    {
                        ingredients.Add(ingredient);
                        Console.WriteLine(string.Join(", ", ingredients));
                    }                    
                    Console.WriteLine();
                }

                prix = 5 + ingredients.Count() * 1.5f;
            }
        }

        class Pizza
        {
            public string nom { get; protected  set; }
            public float prix { get; protected set; }
            public bool vegetarienne { get; private set; }
            public List<string> ingredients { get; protected set; }

            public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
            {
                this.nom = nom;
                this.prix = prix;
                this.vegetarienne = vegetarienne;
                this.ingredients = ingredients;
            }

            public void Afficher()
            {

                string badgeVegetarienne = vegetarienne ? " (V)" : "";

                string nomAfficher = FormatPremiereLettreMajuscules(nom);

                var ingredientsAfficher = ingredients.Select(i => FormatPremiereLettreMajuscules(i)).ToList();

                Console.WriteLine(nomAfficher + badgeVegetarienne + " - " + prix + "€");
                Console.WriteLine(string.Join(", ", ingredientsAfficher));
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

            public bool ContientIngredient(string ingredient)
            {
                return ingredients.Where(i => i.ToLower().Contains(ingredient)).ToList().Count > 0;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            /*var pizzas = new List<Pizza>() {
                new Pizza("4 fromages", 11.2f, true, new List<string>{"cantal", "mozzarella", "fromage de chèvre", "gruyère"}),
                new Pizza("indienne", 10.5f, false, new List<string>{"curry", "mozzarella", "poulet", "poivron", "oignon", "coriandre"}),
                new Pizza("mexicaine", 13f, false, new List<string>{"boef", "mozzarella", "maïs", "tomates", "oignon", "coriandre"}),
                new Pizza("margarita", 8f, true, new List<string>{"sauce tomate", "mozzarella", "basilic"}),
                new Pizza("calzone", 12f, false, new List<string>{"tomate", "jambon", "persil", "fromage"}),
                new Pizza("complète", 9.5f, false, new List<string>{"jambon", "oeuf", "fromage"}),
                //new PizzaPersonnalisee(),
                //new PizzaPersonnalisee()
            };

            string json = JsonConvert.SerializeObject(pizzas);
            File.WriteAllText("pizzas.json", json);*/

            string json = File.ReadAllText("pizzas.json");
            var pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);

            foreach(var pizza in pizzas)
            {
                pizza.Afficher();
            }
        }
    }
}