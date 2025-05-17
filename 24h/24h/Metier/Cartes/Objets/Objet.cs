using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IACryptOfTheNecroDancer.Metier.Cartes.Terrains;

namespace IACryptOfTheNecroDancer.Metier.Cartes.Objets
{
    /// <summary>
    /// Classe abstraite représentant un objet placé sur une case de la carte
    /// </summary>
    public abstract class Objet
    {
        #region --- Attributs ---
        private Case position; // La position de l'objet sur la carte
        #endregion

        #region --- Propriétés --- 
        public Case Position {  get { return position; } } // Obtient la case où se trouve l'objet
        public abstract TypeObjet Type { get; } // Obtient le type d'objet spécifique (défini dans les classes dérivées)
        #endregion

        #region --- Constructeurs --- 
        /// <summary>
        /// Initialise un nouvel objet sur une case qu'on précise
        /// </summary>
        /// <param name="position">La case où placer l'objet.</param>
        public Objet(Case position)
        {
            this.position = position;
        }
        #endregion
    }
}
