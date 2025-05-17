using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IACryptOfTheNecroDancer.Metier.Cartes.Terrains
{
    /// <summary>
    /// Classe abstraite représentant un terrain sur la carte
    /// Les terrains spécifiques doivent hériter de cette classe et implémenter ses propriétés
    /// </summary>
    public abstract class Terrain
    {
        #region --- Propriétés ---
        public abstract TypeTerrain Type { get; } // Obtient le type de terrain
        public abstract bool EstAccessible { get; } // Indique si le terrain est accessible aux déplacements
        public abstract int CoutDeplacement { get; } //  Obtient le coût de déplacement associé à ce terrain
        #endregion

        #region --- Méthodes ---

        #endregion
    }
}
