
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using IACryptOfTheNecroDancer.Metier.Algorithmes;
using IACryptOfTheNecroDancer.Metier.Cartes;
using IACryptOfTheNecroDancer.Metier.Cartes.Objets;


namespace IACryptOfTheNecroDancer.Modules.Realisations
{
    /// <summary>
    /// Ce module est en charge de prendre les décisions pour l'IA (que doit je faire ?)
    /// </summary>
    public class ModulePriseDeDecisions : Module
    {
        #region --- Attributs ---
        private List<TypeMouvement> mouvements;
        #endregion

        #region --- Propriétés ---
        #endregion

        #region --- Constructeurs ---
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="ia">Ia dont dépend le module</param>
        public ModulePriseDeDecisions(IA ia) : base(ia)
        { 
            this.mouvements = new List<TypeMouvement>();
        }
        #endregion

        #region --- Méthodes ---

        /// <summary>
        /// Méthode déterminant la prochaine action à réaliser
        /// </summary>
        /// <param name="messageRecuDuServeur">Le dernier message reçu du serveur</param>
        /// <returns>Le message à envoyer au serveur</returns>
        public string DeterminerNouvelleAction(string messageRecuDuServeur)
        {
            return "POOCHY";
        }
    #endregion
}
}

