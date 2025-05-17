using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;

namespace IACryptOfTheNecroDancer.Metier.Cartes
{
    /// <summary>
    /// Représente les coordonnées d'une case sur la carte
    /// </summary>
    public class Coordonnees
    {
        #region --- Attributs --- 
        private int ligne;
        private int colonne;
        #endregion

        #region --- Propriétés --- 
        public int Ligne { get { return ligne; } } // Obtient la ligne des coordonnées
        public int Colonne { get { return colonne; } } // Obtient la colonne des coordonnées
        #endregion

        #region --- Constructeurs ---
        /// <summary>
        /// Initialise une instance de Coordonnees avec la ligne et la colonne spécifiées
        /// </summary>
        /// <param name="ligne">La ligne des coordonnées.</param>
        /// <param name="colonne">La colonne des coordonnées.</param>
        public Coordonnees(int ligne, int colonne)
        {
            this.ligne = ligne;
            this.colonne = colonne;
        }
        #endregion

        #region --- Methods ---
        /// <summary>
        /// Vérifie l'égalité entre deux objets
        /// </summary>
        /// <param name="obj">L'objet à comparer</param>
        /// <returns>True si les objets sont égaux, sinon False</returns>
        public override bool Equals(object? obj)
        {
            return obj is Coordonnees coordonnees &&
                   ligne == coordonnees.ligne &&
                   colonne == coordonnees.colonne;
        }

        /// <summary>
        /// Obtient le code de hachage des coordonnées
        /// </summary>
        /// <returns>Le code de hachage des coordonnées</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(ligne, colonne);
        }

        /// <summary>
        /// Renvoie les coordonnées de la case obtenue en effectuant le mouvement donné en 
        /// paramètre à partir de la case en cours.
        /// </summary>
        /// <param name="mouvement"></param>
        /// <returns></returns>
        public Coordonnees GetVoisin(TypeMouvement mouvement)
        {
            return mouvement switch
            {
                TypeMouvement.HAUT => new Coordonnees(ligne - 1, colonne),
                TypeMouvement.BAS => new Coordonnees(ligne + 1, colonne),
                TypeMouvement.GAUCHE => new Coordonnees(ligne, colonne - 1),
                TypeMouvement.DROITE => new Coordonnees(ligne, colonne + 1),
                _ => this
            };
        }

        /// <summary>
        /// Renvoie le mouvement à réaliser pour passer des coordonnées courantes aux coordonnées destination
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public TypeMouvement GetMouvementPourAller(Coordonnees destination)
        {
            if (destination.ligne == this.ligne - 1 && destination.colonne == this.colonne)
                return TypeMouvement.HAUT;
            if (destination.ligne == this.ligne + 1 && destination.colonne == this.colonne)
                return TypeMouvement.BAS;
            if (destination.ligne == this.ligne && destination.colonne == this.colonne - 1)
                return TypeMouvement.GAUCHE;
            if (destination.ligne == this.ligne && destination.colonne == this.colonne + 1)
                return TypeMouvement.DROITE;

            throw new ArgumentException("Les coordonnées fournies ne sont pas voisines.");
        }
        #endregion
    }
}
