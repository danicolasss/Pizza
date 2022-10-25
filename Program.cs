using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PizzaConsole
{
    class MainClass
    {
        private static void pizzaInt()
        {
            List<int> list = new List<int>();

            while (true)
            {
                Console.Write("Prix de l'article en euros , ou rien pour terminer la saisie: ");
                string prix = Console.ReadLine();
                int prixNum = 0;
                if (int.TryParse(prix, out prixNum))
                {
                    list.Add(prixNum);
                }
                else
                {
                    break;
                }
            }

            int somme = 0;
            foreach (int a in list)
            {
                somme += a;

            }
            Console.WriteLine("la somme totale est de " + somme + " euros " + list.Count + " articles");
            Console.WriteLine("");
            int i = 0;
            foreach (int a in list)
            {
                if (i == list.Count - 1)
                {
                    Console.Write(a);
                }
                else
                {
                    Console.Write(a + ", ");
                }
                i++;
            }
        }
        private static void pizzaString()
        {
            string[] nomPizzas = { "quatre formages", "Margherita", "indienne", "reine", "louisiane", "kebab", "chèvre et miel" };

            List<string> listePizzas = nomPizzas.ToList();
            listePizzas.Sort();

            for (int i = listePizzas.Count() - 1; i >= 0; i--)
            {
                string pizza = listePizzas[i];
                int longeur = pizza.Length;
                if (pizza[longeur - 1] == 'e')
                {
                    listePizzas.Remove(pizza);
                }
            }
            foreach (string pizza in listePizzas)
            {


                Console.WriteLine(pizza);
            }
        }
        
            class Pizza
        {

            private static Pizza dernierePizzaCree;
            private static Pizza pizzaLaMoinsChere;
            private static Pizza pizzaLaPlusChere;

            private string nom;
            private int prix;
            string[] ingredients;

            // Constructeur
            public Pizza(string nom, int prix, string[] ingredients)
            {
                this.nom = nom;
                this.prix = prix;
                this.ingredients = ingredients;

                dernierePizzaCree = this;

                if (pizzaLaMoinsChere == null)
                {
                    pizzaLaMoinsChere = this;
                }
                else
                {
                    if (prix < pizzaLaMoinsChere.Prix)
                    {
                        pizzaLaMoinsChere = this;
                    }
                }

                if (pizzaLaPlusChere == null)
                {
                    pizzaLaPlusChere = this;
                }
                else
                {
                    if (prix > pizzaLaPlusChere.Prix)
                    {
                        pizzaLaPlusChere = this;
                    }
                }
            }

            public void Afficher()
            {
                Console.WriteLine("Pizza: " + nom + " - " + prix + "€");
                //Console.WriteLine(String.Join(", ", ingredients));
                foreach (string s in ingredients)
                {
                    Console.Write(s + ", ");
                }
                Console.WriteLine("");
            }

            public int Prix
            {
                get { return prix; }
            }

            public static void AfficherDernierePizza()
            {
                if (dernierePizzaCree == null)
                {
                    Console.WriteLine("ERREUR: Vous n'avez pas crée de pizza");
                }
                else
                {
                    Console.WriteLine("** DERNIERE PIZZA CREE**");
                    dernierePizzaCree.Afficher();
                }
            }

            public static void AfficherPizzaMoisChereEtPlusChere()
            {
                if (pizzaLaMoinsChere != null)
                {
                    Console.WriteLine("** PIZZA LA MOINS CHERE **");
                    pizzaLaMoinsChere.Afficher();
                }
                if (pizzaLaPlusChere != null)
                {
                    Console.WriteLine("** PIZZA LA PLUS CHERE **");
                    pizzaLaPlusChere.Afficher();
                }
            }

        }


        public static void Main(string[] args)
        {


            List<Pizza> pizzas = new List<Pizza>();
            pizzas.Add(new Pizza("quatre fromages", 11, new string[] { "brie", "mozzarella", "gruyere", "emmental" }));
            pizzas.Add(new Pizza("norvegienne", 16, new string[] { "saumon fumé", "tomates" }));
            pizzas.Add(new Pizza("normande", 12, new string[] { "brie", "pommes", "oignons" }));
            pizzas.Add(new Pizza("montagnarde", 15, new string[] { "roblochon", "pommes de terre", "oignons" }));
            pizzas.Add(new Pizza("végétarienne", 9, new string[] { "tomates", "oignons", "poivrons", "olives" }));

            pizzas.Sort((Pizza x, Pizza y) => {
                return x.Prix.CompareTo(y.Prix);
            });

            foreach (Pizza p in pizzas)
            {
                p.Afficher();
            }

            Pizza.AfficherDernierePizza();

            Pizza.AfficherPizzaMoisChereEtPlusChere();
        }
    }
}
