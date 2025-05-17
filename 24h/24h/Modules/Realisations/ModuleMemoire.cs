using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24h.Metier.Personnages;
using IACryptOfTheNecroDancer.Metier.Cartes;
using IACryptOfTheNecroDancer.Metier.Cartes.Objets;

namespace IACryptOfTheNecroDancer.Modules.Realisations
{
    /// <summary>
    /// Module en charge de mémoriser les informations dont l'IA a besoin pour fonctionner
    /// </summary>
    public class ModuleMemoire : Module
    {
        #region --- Attributs ---
        private Carte carte;
        private Joueur joueur; 
        #endregion

        #region --- Propriétés ---
        public Joueur Joueur { get { return joueur; } }
        public List<Objet> Diamants { get { return carte.Diamants; } }
        public Carte Carte { get { return carte; } }
        #endregion

        #region --- Constructeurs ---
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="ia">L'IA dont dépend le module</param>
        public ModuleMemoire(IA ia) : base(ia) { }
        #endregion

        #region --- Méthodes ---
        public void GenererCarte(string messageRecu)
        {
            this.carte = new Carte(messageRecu);
            GenererJoueur(this.carte.CoordonneesDepart);
        }

        /// <summary>
        /// Renvoie si la carte a été crée ou non
        /// </summary>
        /// <returns></returns>
        public bool HasCarte()
        {
            bool carteCreate = false;
            if (this.carte != null)
            {
                carteCreate = true;
            }
            return carteCreate;
        }

        /// <summary>
        /// Renvoie true si l’attribut joueur est non null.
        /// </summary>
        /// <returns></returns>
        public bool HasJoueur()
        {
            bool HasAJoueur = false;
            if (this.joueur != null)
            {
                HasAJoueur = true;
            }
            return HasAJoueur;
        }

        /// <summary>
        /// Génère le joueur à partir des coordonnées données en paramètre.
        /// </summary>
        /// <param name="coordonnees"></param>
        public void GenererJoueur(Coordonnees coordonnees)
        {
            this.joueur = new Joueur(coordonnees);
        }
        #endregion
    }
}
