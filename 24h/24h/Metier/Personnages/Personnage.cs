using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IACryptOfTheNecroDancer.Metier.Cartes.Terrains;

namespace _24h.Metier.Personnages
{
    public abstract class Personnage
    {
        #region --- Attributs ---
        
        #endregion
        #region --- Propriétés ---
        public abstract TypePersonnage Type { get; } // Type de personnage 
        public abstract string Name { get; } // Le nom du personnage 
        public abstract int Life { get; } // Indique la vie du personnage 
        public abstract int ScoreSavoir { get; } //  Le score du savoir 
        #endregion



    }
}
