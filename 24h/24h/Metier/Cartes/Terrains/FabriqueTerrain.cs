using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IACryptOfTheNecroDancer.Metier.Cartes.Terrains.Réalisations;

namespace IACryptOfTheNecroDancer.Metier.Cartes.Terrains
{
    /// <summary>
    /// Fabrique permet de créer des instances de terrains en fonction d'un caractère donné
    /// Utilise un pattern
    /// </summary>
    internal class FabriqueTerrain
    {
        #region --- Méthodes ---
        /// <summary>
        /// Crée un terrain correspondant au caractère spécifié
        /// </summary>
        /// <param name="caractere">Le caractère représentant le type de terrain</param>
        /// <returns>Une instance du terrain correspondant</returns>
        public static Terrain Creer(Char caractere)
        {
            Terrain res;
            switch (caractere)
            {
                case 'M':
                    res = new TerrainMur();
                    break;
                case 'I':
                    res = new TerrainMurPierre();
                    break;
                case 'X':
                    res = new TerrainSortie();
                    break;
                default:
                    res = new TerrainVide();
                    break;
            }
            return res;
        }
        #endregion
    }
}
