
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IACryptOfTheNecroDancer.Modules.Realisations
{
    /// <summary>
    /// Ce module est en charge de prendre les décisions pour l'IA (que doit je faire ?)
    /// </summary>
    public class ModulePriseDeDecisions : Module
    {
        #region --- Attributs ---
        
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
            
        }
        #endregion

        #region --- Méthodes ---

        /// <summary>
        /// Méthode déterminant la prochaine action à réaliser
        /// </summary>
        /// <param name="messageRecuDuServeur">Le dernier message reçu du serveur</param>
        /// <returns>Le message à envoyer au serveur</returns>
        public static string DeterminerNouvelleAction(string messageRecuDuServeur)
        {
            string messageEnvoye = "";
           
            if (messageRecuDuServeur == "NOM_EQUIPE")
            {
                messageEnvoye = "POOCHY";
            }
            else if (messageRecuDuServeur.StartsWith("DEBUT_TOUR"))
            {
                string[] parties = messageRecuDuServeur.Split('|');
                int numeroTour = int.Parse(parties[1]);
                int numeroPhase = int.Parse(parties[2]);

                // Pour l’instant, on décide de piocher une carte de savoir sûre (expédition 2)
                messageEnvoye = "PIOCHER|0";
            }
            else if (messageRecuDuServeur == "FIN")
            {
                Console.WriteLine("Partie terminée.");
            }



            return messageEnvoye;
        }
    #endregion
}
}

