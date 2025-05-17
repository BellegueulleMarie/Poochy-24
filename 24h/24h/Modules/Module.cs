using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IACryptOfTheNecroDancer.Modules
{
    /// <summary>
    /// Classe abstraite de module. Un module est une partie de l'IA.
    /// </summary>
    public abstract class Module
    {
        #region --- Attributs ---
        private IA ia;  //L'IA dont ce module dépend
        #endregion

        #region --- Propriétés ---
        /// <summary>
        /// L'IA dont ce module dépend
        /// </summary>
        public IA IA => this.ia;
        #endregion

        #region --- Constructeurs ---
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="ia">L'IA dont dépend le module</param>
        public Module(IA ia)
        {
            this.ia = ia;
        }
        #endregion
    }
}
