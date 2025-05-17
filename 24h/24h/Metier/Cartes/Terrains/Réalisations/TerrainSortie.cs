using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IACryptOfTheNecroDancer.Metier.Cartes.Terrains.TypeTerrain;

namespace IACryptOfTheNecroDancer.Metier.Cartes.Terrains.Réalisations
{
    /// <summary>
    /// Représente un terrain de type mur sur la carte
    /// Hérite de la classe Terrain
    /// </summary>
    internal class TerrainSortie : Terrain
    {
        #region --- Attributs --- 
        public override TypeTerrain Type => SORTIE; // Obtient le type de terrain : la sortie, qui est vide
        public override bool EstAccessible => true; // Indique si le terrain est accessible (si Cadence peut "marcher" dessus)
        public override int CoutDeplacement => 1; //  Obtient le coût de déplacement sur ce terrain | La sortie a un coût de déplacement de 1
        #endregion

    }
}
