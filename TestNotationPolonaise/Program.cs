/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
        /// <summary>
        ///  Retourner la réponse à une formule Polonaise
        /// </summary>
        /// <param name="laFormule">Formule Polonaise à calculer</param> 
        /// <returns></returns>
        static float Polonaise(String laFormule)
        {
            try
            {
                // Attribuer caractères formule dans les cases du tableau tab
                string[] tab = laFormule.Split(' ');
                int nbCases = tab.Length;

                // chercher signer d'operation
                while(nbCases > 1)
                {
                    int k = nbCases - 1;
                    while (k > 0 && tab[k] != "+" && tab[k] != "-" && tab[k] != "*" && tab[k] != "/")
                    {
                        k--;
                    }
                    // Récuperer valeurs des deux cases précédents l'opérateur
                    float a = float.Parse(tab[k + 1]);
                    float b = float.Parse(tab[k + 2]);

                    //faire le calcul
                    float result = 0;
                    switch(tab[k])
                    {
                        case "+":
                            result = a + b;
                            break;
                        case "-":
                            result = a - b;
                            break;
                        case "*":
                            result = a * b;
                            break;
                        case "/":
                            if (b == 0)
                            {
                                return float.NaN;
                            }
                            result = a / b;
                            break;
                    }

                    // Ranger resultat dans tableau
                    tab[k] = result.ToString();

                    // Décaler valeurs restants dans tableau
                    for (int j = k+1; j < nbCases -2; j++)
                    {
                        tab[j] = tab[j + 2];
                    }

                    // Effacer valeurs des dernières cases
                    for (int j = nbCases -2; j < nbCases; j++)
                    {
                        tab[j] = " ";
                    }
                    nbCases -= 2;
                }
                return float.Parse(tab[0]);
            }
            catch
            {
                return float.NaN;
            }
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
