using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using IACryptOfTheNecroDancer.Metier.Cartes;

namespace _24h.Metier.Personnages
{
    public class Joueur : Personnage
    {
        #region --- Attributs ---
        // Attributs privé pour stocker les coordonnées du joueur
        private Coordonnees coordonnees;
        #endregion

        #region --- Propriétés ---
        // Propriétés en lecture seule pour accéder aux coordonées du joueur
        public Coordonnees Coordonnees { get { return coordonnees; } }
        #endregion

        #region --- Constructeur ---
        public Joueur(Coordonnees coordonnees)
        {
            this.coordonnees = coordonnees;
        }
        #endregion

        #region --- Méthodes ---
        /// <summary>
        /// Déplace le joueur en fonction du mouvement fourni
        /// </summary>
        /// <param name="mouvement">Le type de mouvement à effectuer.</param>
        public void Deplacer(TypeMouvement mouvement)
        {
            coordonnees = coordonnees.GetVoisin(mouvement);
        }
        #endregion
    }
}
