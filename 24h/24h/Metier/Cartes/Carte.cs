using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using IACryptOfTheNecroDancer.Metier.Cartes.Objets;
using IACryptOfTheNecroDancer.Metier.Cartes.Terrains;

namespace IACryptOfTheNecroDancer.Metier.Cartes
{
    /// <summary>
    /// Représente la carte du jeu contenant les différentes cases, les objets et les coordonnées importantes
    /// </summary>
    public class Carte
    {
        #region --- Attributs --- 
        private int taille;
        private Dictionary<Coordonnees, Case> cases;
        private Coordonnees coordonneesDepart;
        private List<Objet> diamants;
        public Coordonnees coordonneesSortie;
        #endregion

        #region --- Propriétés ---
        public int Taille { get { return taille; } } // Obtient la taille de la carte (assumée carrée)
        public Coordonnees CoordonneesDepart { get { return coordonneesDepart; } } // Obtient les coordonnées de départ du joueur
        public List<Objet> Diamants { get { return diamants; } } // Obtient la liste des diamants présents sur la carte
        public Coordonnees CoordonneesSortie { get {  return coordonneesSortie; } } // Obtient les coordonnées de la sortie
        #endregion

        #region --- Constructeur ---
        public Carte(string messageRecu)
        {
            this.diamants = new List<Objet>();  
            this.cases = new Dictionary<Coordonnees, Case>();
            this.taille = (int)Math.Sqrt(messageRecu.Length);
            for (int i = 0; i < this.taille; i++)
                for (int j = 0; j < this.taille; j++)
                    this.AjouterCase(messageRecu[j + this.taille * i],
                    new Coordonnees(i, j));

            for (int i = 0; i < this.taille; i++)
            {
                for (int j = 0; j < this.taille; j++)
                {
                    Coordonnees cooCase = new Coordonnees(i, j);
                    foreach (TypeMouvement mouvement in
                    (TypeMouvement[])Enum.GetValues(typeof(TypeMouvement)))
                    {
                        Coordonnees cooVoisin = cooCase.GetVoisin(mouvement);
                        if (this.cases.ContainsKey(cooVoisin))
                        {
                            this.cases[cooCase].AjouterVoisin(this.cases[cooVoisin]);
                        }
                    }
                }
            }
        }
        #endregion

        #region --- Méthodes --- 
        /// <summary>
        /// Ajoute une case à la carte en fonction du caractère fourni
        /// </summary>
        /// <param name="caractere">Le caractère représentant la case</param>
        /// <param name="coordonnees">Les coordonnées de la case sur la carte</param>
        private void AjouterCase(char caractere, Coordonnees coordonnees)
        {
            /* if (caractere == 'J')
             {
                 coordonneesDepart = coordonnees;
             }
             Case nouvelleCase = FabriqueCase.Creer(caractere, coordonnees);
             this.cases[coordonnees] = nouvelleCase;

             if (caractere == 'X')
             {
                 coordonneesSortie = coordonnees;
             }

             if (caractere == 'D') 
             {
                 this.diamants.Add(nouvelleCase.Objet);
             } */

            this.cases[coordonnees] = FabriqueCase.Creer(caractere, coordonnees);

            switch (caractere)
            {
                case 'J':
                    coordonneesDepart = coordonnees;
                    break;

                case 'X':
                    coordonneesSortie = coordonnees;
                    break;

                case 'D':
                    this.diamants.Add(this.cases[coordonnees].Objet);
                    break;
            }
        }

        /// <summary>
        /// Affiche la carte dans la console sous forme de grille
        /// </summary>
        private void AffichageConsole()
        {
            Console.WriteLine();
            Console.WriteLine("---- AFFICHAGE DE LA CARTE ----");
            Console.WriteLine();
            for (int i = 0; i < this.taille; i++)
            {
                for (int j = 0; j < this.taille; j++)
                {
                    String affichage = "";
                    Case c = this.cases[new Coordonnees(i, j)];
                    switch (c.Terrains.Type)
                    {
                        case TypeTerrain.MUR: affichage = "M"; break;
                        case TypeTerrain.MURPIERRE: affichage = "P"; break;
                        case TypeTerrain.SORTIE: affichage = "S"; break;
                        case TypeTerrain.VIDE:
                            if (c.Objet == null) affichage = " ";
                            else
                            {
                                switch (c.Objet.Type)
                                {
                                    case TypeObjet.DIAMANT:
                                        affichage = "D";
                                        break;
                                }
                            }
                            break;
                    }
                    Console.Write(affichage);
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Retourne la case correspondant aux coordonnées données
        /// </summary>
        /// <param name="coordonnees">Coordonnées de la case</param>
        /// <returns>La case correspondante</returns>
        public Case GetCaseAt(Coordonnees coordonnees)
        {
            Case resultat = null;

            if (cases.ContainsKey(coordonnees))
            {
                resultat = cases[coordonnees];
            }

            return resultat;
        }

        /// <summary>
        /// Ramasse un diamant situé sur une case donnée, si elle en contient un
        /// </summary>
        /// <param name="coordonnees">Les coordonnées de la case où le diamant doit être ramassé</param>
        public void RamasserDiamant(Coordonnees coordonnees)
        {
            Case? caseNullableDiamant = GetCaseAt(coordonnees);

            if (caseNullableDiamant == null && caseNullableDiamant.Objet.Type == TypeObjet.DIAMANT)
            {
                this.diamants.Remove(caseNullableDiamant.Objet);
                caseNullableDiamant = null;
            }
        }

        #endregion

    }
}
