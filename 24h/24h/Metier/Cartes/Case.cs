using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IACryptOfTheNecroDancer.Metier.Cartes.Terrains;
using IACryptOfTheNecroDancer.Metier.Cartes;
using IACryptOfTheNecroDancer.Metier.Cartes.Objets;
using DefaultNamespace;
using IACryptOfTheNecroDancer.Metier.Cartes.Terrains.Réalisations;

namespace IACryptOfTheNecroDancer.Metier.Cartes
{
    /// <summary>
    /// Représente une case sur la carte, contenant un terrain, un objet éventuel et des voisins
    /// </summary>
    public class Case
    {
        #region --- Attributs ---
        private Coordonnees coordonnees;
        private Terrain terrain;
        private Objet? objet;
        private List<Case> voisins;

        #endregion

        #region --- Propriétés ---
        public Coordonnees Coordonnees {  get { return coordonnees; } } //  Obtient les coordonnées de la case
        public Terrain Terrains { get { return terrain; } set { terrain = value; } } // Obtient ou définit le type de terrain de la case
        public Objet Objet { get { return objet; } set { objet = value; } } // Obtient ou définit l'objet présent sur la case
        public List<Case> Voisins {  get { return voisins; } } // Obtient la liste des cases voisines
        public bool EstAccessible { get { return terrain.EstAccessible; } } // Indique si la case est accessible (en fonction de son terrain)
        public int CoutDeplacement { get { return terrain.CoutDeplacement; } } // Obtient le coût de déplacement sur cette case

        #endregion

        #region --- Constructeurs --- 
        /// <summary>
        /// Initialise une case avec des coordonnées spécifiées
        /// </summary>
        /// <param name="coordonnees">Coordonnées de la case.</param>
        public Case(Coordonnees coordonnees) 
        {
            this.coordonnees = coordonnees;
            this.voisins = new List<Case>();
        }
        #endregion

        #region --- Méthodes --- 
        /// <summary>
        /// Ajoute une case voisine à cette case
        /// </summary>
        /// <param name="voisin">La case voisine à ajouter.</param>
        public void AjouterVoisin(Case voisin)
        {
            voisins.Add(voisin);
        }

        /// <summary>
        /// Renvoie le mouvement à faire en fonction des voisins
        /// </summary>
        /// <param name="voisin"></param>
        /// <returns></returns>
        public TypeMouvement GetMouvementPourAller(Case voisin)
        {
            return this.coordonnees.GetMouvementPourAller(voisin.Coordonnees);
        }

        /// <summary>
        /// Transforme la case en terrain vide
        /// </summary>
        public void Creuser()
        {
            this.terrain = new TerrainVide();
        }
        #endregion
    }
}
