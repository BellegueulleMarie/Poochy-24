using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24h.Metier.Cartes.Objets
{
public class Personnage
    {
        public string Nom { get; }
        public int PointsDeVie { get; set; }
        public int ScoreDefense { get; set; }
        public int ScoreAttaque { get; set; }
        public int ScoreSavoir { get; set; }

        public Personnage(string nom, int pointsDeVie, int scoreDefense, int scoreAttaque, int scoreSavoir)
        {
            Nom = nom;
            PointsDeVie = pointsDeVie;
            ScoreDefense = scoreDefense;
            ScoreAttaque = scoreAttaque;
            ScoreSavoir = scoreSavoir;
        }

        public void AfficherInfos()
        {
            Console.WriteLine($"Nom: {Nom}");
            Console.WriteLine($"Points de Vie: {PointsDeVie}");
            Console.WriteLine($"Score de Défense: {ScoreDefense}");
            Console.WriteLine($"Score d'Attaque: {ScoreAttaque}");
            Console.WriteLine($"Score de Savoir: {ScoreSavoir}");
        }
    }

    public class Joueur
    {
        public string Nom { get; }
        public List<Personnage> Personnages { get; }

        public Joueur(string nom)
        {
            Nom = nom;
            Personnages = new List<Personnage>();
        }

        public void AjouterPersonnage(Personnage personnage)
        {
            Personnages.Add(personnage);
        }

        public void AfficherInfosPersonnages()
        {
            Console.WriteLine($"Joueur: {Nom}");
            foreach (var personnage in Personnages)
            {
                personnage.AfficherInfos();
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            // Exemple d'utilisation
            Joueur joueur1 = new Joueur("Joueur1");

            Personnage personnage1 = new Personnage("Guerrier", 100, 10, 15, 5);
            Personnage personnage2 = new Personnage("Mage", 80, 5, 10, 20);

            joueur1.AjouterPersonnage(personnage1);
            joueur1.AjouterPersonnage(personnage2);

            joueur1.AfficherInfosPersonnages();
        }
    }

}

