using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IACryptOfTheNecroDancer.Metier.Cartes.Terrains;
using static IACryptOfTheNecroDancer.Metier.Cartes.Objets.TypeObjet;

namespace IACryptOfTheNecroDancer.Metier.Cartes.Objets
{
    /// <summary>
    /// Représente un objet de type diamant placé sur une case de la carte
    /// Hérite de la classe Objet
    /// </summary>
    public class ObjetDiamant : Objet
    {
        #region --- Attributs --- 
        public override TypeObjet Type => DIAMANT; // Obtient le type de l'objet : un diamant
        #endregion

        #region --- Constructeur --- 
        /// <summary>
        /// Initialise un diamant à une position précise sur la carte
        /// </summary>
        /// <param name="position">La case où se trouve le diamant.</param>
        public ObjetDiamant(Case position) : base(position) {}
        #endregion

    }
}
