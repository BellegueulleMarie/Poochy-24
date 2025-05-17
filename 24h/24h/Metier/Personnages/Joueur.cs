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
        private string name; // Nom du joueur
        private int life; // Vie du joueur
        private int scoreSavoir; // Score de savoir du joueur
        private int scoreDefense; // Score de défense du joueur
        private int scoreAttaque; // Score d'attaque du joueur
        #endregion

        #region --- Propriétés ---

        public override TypePersonnage Type => TypePersonnage.JOUEUR;
        public override string Name => name; // Nom du joueur
        public override int Life => life; // Vie du joueur
        public override int ScoreSavoir => scoreSavoir; // Score de savoir du joueur

        // Propriétés en lecture seule pour accéder aux coordonées du joueur
        //public Coordonnees Coordonnees { get { return coordonnees; } }
        #endregion

        #region --- Constructeur ---
        public Joueur(string name,int life,int scoreSavoir, int scoreDefense,int scoreAttaque)
        {
            this.name = name; // Initialise le nom du joueur
            this.life = life; // Initialise la vie du joueur
            this.scoreSavoir = scoreSavoir; // Initialise le score de savoir du joueur
            this.scoreDefense = scoreDefense; // Initialise le score de défense du joueur
            this.scoreAttaque = scoreAttaque; // Initialise le score d'attaque du joueur
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
