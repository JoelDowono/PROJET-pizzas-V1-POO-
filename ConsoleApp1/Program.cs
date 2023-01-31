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
            public float prix { get; private set; }
            public bool vegetarienne { get; private set; }
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

            //pizzas = pizzas.OrderByDescending(p => p.prix).ToList();

            /*Pizza pizzaPrixMin = null;
            Pizza pizzaPrixMax = null;;

            pizzaPrixMin = pizzas[0];
            pizzaPrixMax = pizzas[0];

            foreach(var pizza in pizzas)
            {
                if(pizza.prix < pizzaPrixMin.prix)
                {
                    pizzaPrixMin = pizza;
                }
                if (pizza.prix > pizzaPrixMax.prix)
                {
                    pizzaPrixMax = pizza;
                }
            }*/

            pizzas = pizzas.Where(p => !p.vegetarienne).ToList();

            foreach(var pizza in pizzas)
            {
                pizza.Afficher();
            }
            /*Console.WriteLine();
            Console.WriteLine("La pizza la moins chere est : ");
            pizzaPrixMin.Afficher();
            Console.WriteLine("La pizza la plus chere est : ");
            pizzaPrixMax.Afficher();*/
        }
    }
}