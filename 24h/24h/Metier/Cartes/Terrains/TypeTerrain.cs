using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IACryptOfTheNecroDancer.Metier.Cartes.Terrains
{
    /// <summary>
    /// énumère le type de terrain, utilisé pour TerrainMur, TerrainMurPierre, TerrainVide et TerrainSortie
    /// </summary>
    public enum TypeTerrain
    {
        VIDE,
        MUR,
        MURPIERRE,
        SORTIE
    }
}
