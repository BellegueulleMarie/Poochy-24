using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using IACryptOfTheNecroDancer.Metier.Cartes;

namespace IACryptOfTheNecroDancer.Metier.Algorithmes
{
    // Algorithme de distance
    public abstract class AlgorithmeCalculDistance
    {
        #region --- Attributs ---
        private Carte carte;
        private Dictionary<Case, int> distances;

        #endregion

        #region --- Propriétés ---
        public Carte Carte { get { return carte; } }
        #endregion

        #region --- Constructeur ---
        // Initialise la carte et les distances
        public AlgorithmeCalculDistance(Carte carte)
        {
            this.carte = carte;
            this.distances = new Dictionary<Case, int>();
        }
        #endregion

        #region --- Méthodes ---
        /// <summary>
        /// Fixe la position en fonction de la valeur entrée en paramètre
        /// </summary>
        /// <param name="position"></param>
        /// <param name="valeur"></param>
        protected void SetDistance(Case position, int valeur)
        {
            distances[position] = valeur;
        }

        /// <summary>
        /// Renvoie -1 si position n’est pas présent (comme clé) dans le dictionnaire distances et distances[position] sinon.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int GetDistance(Case position)
        {
            int distance = -1;
            if (distances.ContainsKey(position))
            {
                distance = distances[position];
            }

            return distance ;
        }

        /// <summary>
        /// Permet de vider le dictionnaire
        /// </summary>
        protected void ReinitialisationDistances()
        {
            this.distances.Clear();
        }

        /// <summary>
        /// La méthode CalculerDistancesDepuis est abstraite (car tous les algorithmes ne calculent pas les distances de la même façon
        /// </summary>
        /// <param name="depart"></param>
        public abstract void CalculerDistancesDepuis(Case depart);

        public abstract List<TypeMouvement> GetChemin(Case arrivee);

        #endregion
    }
}
