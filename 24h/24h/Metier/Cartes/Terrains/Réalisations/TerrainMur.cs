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
    internal class TerrainMur : Terrain
    {
        #region --- Attributs --- 
        public override TypeTerrain Type => MUR; // Obtient le type de terrain : un mur
        public override bool EstAccessible => true; // Indique si le terrain est accessible (si Cadence peut "marcher" dessus)
        public override int CoutDeplacement => 2; //  Obtient le coût de déplacement sur ce terrain | Un mur a un coût de déplacement de 2
        #endregion
    }
}
