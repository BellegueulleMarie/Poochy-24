using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using IACryptOfTheNecroDancer.Metier.Cartes;

namespace IACryptOfTheNecroDancer.Metier.Algorithmes
{
    /// <summary>
    /// Implémente l'algorithme de parcours en largeur pour calculer les distances 
    /// sur une carte et retrouver le chemin optimal
    /// Hérite de <see cref="AlgorithmeCalculDistance"/>.
    /// </summary>
    public class ParcoursLargeur : AlgorithmeCalculDistance
    {
        #region --- Constructeurs --- 
        /// <summary>
        /// Initialise une nouvelle instance de l'algorithme de parcours en largeur.
        /// </summary>
        /// <param name="carte">La carte sur laquelle effectuer les calculs.</param>
        public ParcoursLargeur(Carte carte) : base(carte)
        {
        }
        #endregion

        #region --- Méthodes ---
        /// <summary>
        /// Calcule la distance de chaque case depuis une case de départ
        /// en utilisant un parcours en largeur.
        /// </summary>
        /// <param name="depart">La case de départ pour le calcul des distances.</param>
        public override void CalculerDistancesDepuis(Case depart)
        {
            // Remise à zero
            List<Case> aTraiter = new List<Case>();
            this.ReinitialisationDistances(); // on réintilise le dictionnaire

            // Initialisation
            aTraiter.Add(depart);
            SetDistance(depart,0);

            // Calcul
            while (aTraiter.Count > 0)
            {
                Case caseEnCours = aTraiter[0]; 
                aTraiter.RemoveAt(0); // on enlève la tête de liste
                foreach (Case v in caseEnCours.Voisins)
                {
                    if (GetDistance(v) == -1 && v.EstAccessible)
                    {
                        SetDistance(v, GetDistance(caseEnCours) + 1);
                        aTraiter.Add(v);
                    }
                }
            }
        }


        /// <summary>
        /// Récupère la liste des mouvements à effectuer pour atteindre une case cible depuis la source.
        /// </summary>
        /// <param name="arrivee">La case d'arrivée.</param>
        /// <returns>Une liste ordonnée des mouvements à effectuer pour atteindre la case cible.</returns>
        public override List<TypeMouvement> GetChemin(Case arrivee)
        {
            Case casePrecedente = null;

            // Initialisation
            List<TypeMouvement> resultat = new List<TypeMouvement>();
            Case caseEnCours = arrivee;

            // Calcul
            if (GetDistance(caseEnCours) != -1) // si la distance de la caseEnCours ne vaut pas -1
            {
                while (GetDistance(caseEnCours) > 0) // Tant que la distance de caseEnCours n'est pas vide
                {
                    foreach(Case v in caseEnCours.Voisins) // On trouve une case voisine de caseEnCours
                    {
                        if (GetDistance(v) == GetDistance(caseEnCours) - 1) // Si la distance est égale à la distance de caseEnCours
                        { 
                            casePrecedente = v;
                        }
                    }
                    if (casePrecedente != null)
                    {
                        TypeMouvement mouvement = casePrecedente.Coordonnees.GetMouvementPourAller(caseEnCours.Coordonnees); // Le mouvement à ajouter

                        for (int i = 0; i < caseEnCours.CoutDeplacement; i++) // ajouter systématiquement 1 mouvement à la liste des mouvements, on ajoute autant de copiede ce mouvement que la valeur de CoutDeplacement de la case en cours.

                        {
                                resultat.Add(mouvement);
                        }
                        caseEnCours = casePrecedente;
                    }
                }
            }
            resultat.Reverse();
            return resultat; 
        }

        #endregion
    }
}
