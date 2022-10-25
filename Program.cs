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
            string[] nomPizzas = { "quatre formages", "Margherita", "indienne" ,"reine","louisiane","kebab","chèvre et miel"};

            List<string> listePizzas = nomPizzas.ToList();
            listePizzas.Sort();
            
            for (int i = listePizzas.Count()-1; i >=0; i--)
            {
                string pizza = listePizzas[i];  
                int longeur = pizza.Length;
                 if (pizza[longeur - 1] == 'e')
                 {
                    listePizzas.Remove(pizza);
                 }
            }
            foreach (string pizza  in listePizzas)
            {
                
               
                Console.WriteLine(pizza);
            }
        }

        public static void Main(string[] args)
        {
            pizzaString();


        }
    }
}