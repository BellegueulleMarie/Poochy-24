using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24h.Metier.Cartes.Objets
{
    public class Piocher
    {
        public int NumeroExpedition { get; }
        public int? NumeroJoueur { get; }

        public Piocher(int numeroExpedition, int? numeroJoueur = null)
        {
            NumeroExpedition = numeroExpedition;
            NumeroJoueur = numeroJoueur;
        }

        public string EnvoyerCommande()
        {
            if (NumeroJoueur.HasValue)
            {
                return $"PIOCHER|{NumeroExpedition}|{NumeroJoueur.Value}";
            }
            else
            {
                return $"PIOCHER|{NumeroExpedition}";
            }
        }

        public void RecevoirReponse(string reponse)
        {
            if (reponse == "OK")
            {
                Console.WriteLine("La carte a été piochée avec succès.");
            }
            else
            {
                Console.WriteLine($"Erreur lors du pioche : {reponse}");
            }
        }

        public static void Main(string[] args)
        {
            // Exemple d'utilisation
            Piocher piocherAction = new Piocher(numeroExpedition: 2, numeroJoueur: 1);
            string commande = piocherAction.EnvoyerCommande();
            Console.WriteLine($"Commande envoyée : {commande}");

            // Simulation de la réponse du serveur
            string reponseServeur = "OK";
            piocherAction.RecevoirReponse(reponseServeur);
        }
    }
}


