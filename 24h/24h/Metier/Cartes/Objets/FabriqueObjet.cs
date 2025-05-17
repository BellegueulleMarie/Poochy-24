using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IACryptOfTheNecroDancer.Metier.Cartes.Objets
{
    /// <summary>
    /// Fabrique d'objets permettant de créer des instances de d'Objet en fonction d'un caractère
    /// Il s'agit d'un pattern
    /// </summary>
    internal class FabriqueObjet
    {
        #region --- Methode --- 
        /// <summary>
        /// Crée un objet en fonction du caractère spécifié
        /// </summary>
        /// <param name="caractere">Le caractère représentant l'objet</param>
        /// <param name="position">La position sur la carte où placer l'objet</param>
        /// <returns>Une instance d'<see cref="Objet"/> ou <c>null</c> si le caractère n'est pas reconnu</returns>
        public static Objet? Creer(Char caractere, Case position)
        {
            Objet res;
            switch (caractere)
            {
                case 'D':
                    res = new ObjetDiamant(position);
                    break;
                default:
                    res = null;
                    break;
            }
            return res;
        }
        #endregion
    }
}
