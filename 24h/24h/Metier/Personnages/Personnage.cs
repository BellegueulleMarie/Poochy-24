using IACryptOfTheNecroDancer.Metier.Cartes.Terrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24h.Metier.Personnages
{
    public abstract class Personnage
    {
        #region --- Attributs ---
        
        #endregion
        #region --- Propriétés ---
        public abstract TypePersonnage Type { get; } // Obtient le type de personnage
        public abstract string Name { get; } // Obtient le nom du joueur
        public abstract int Life { get; } // Indique la vie du personnage
        public abstract int ScoreSavoir { get; } //  Obtient le score du savoir
        #endregion

    }
}
