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
    internal class TerrainMurPierre : Terrain
    {
        #region --- Attributs --- 
        // override de la classe abstraite : Terrain
        public override TypeTerrain Type => MURPIERRE; // Obtient le type de terrain : un mur en pierre
        public override bool EstAccessible => false; // Indique si le terrain est accessible (si Cadence peut "marcher" dessus)
        public override int CoutDeplacement => 0;  //  Obtient le coût de déplacement sur ce terrain | Un mur en pierre a un coût de déplacement de 0
        #endregion

    }
}
