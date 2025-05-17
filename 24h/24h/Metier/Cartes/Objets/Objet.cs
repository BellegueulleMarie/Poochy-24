using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IACryptOfTheNecroDancer.Metier.Cartes.Objets
{
    /// <summary>
    /// Classe abstraite représentant un objet placé sur une case de la carte
    /// </summary>
    public abstract class Objet
    {
        #region --- Attributs ---

        #endregion

        #region --- Propriétés --- 

        public abstract TypeObjet Type { get; } // Obtient le type d'objet spécifique (défini dans les classes dérivées)
        #endregion

        #region --- Constructeurs --- 
        /// <summary>
        /// Initialise un nouvel objet sur une case qu'on précise
        /// </summary>
        /// <param name="position">La case où placer l'objet.</param>

        #endregion
    }
}
