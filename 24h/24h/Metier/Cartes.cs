using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace _24h.Metier
{
    abstract class Cartes
    {
        private int score;

        #region --- Propriétés ---
        public abstract TypeCartes type { get; }
        public abstract string description { get; }
        public int Score { get; set; }
        #endregion

        public Cartes()
        {
            this.score = 0;
        }
    }
}
