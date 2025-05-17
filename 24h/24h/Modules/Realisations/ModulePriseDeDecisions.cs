
    using System;
using System.Collections.Generic;
using System.IO;
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
        private static Queue<string> actionsEnCours = new Queue<string>();
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
                string nomEquipe = parties[1];
                int numeroPhase = int.Parse(parties[2]);

                actionsEnCours.Clear(); // Nouvelle phase : on réinitialise la fil
                if (numeroPhase == 15) // Juste avant la lune de sang
                {
                    actionsEnCours.Enqueue("UTILISER|DEFENSE");
                    actionsEnCours.Enqueue("PIOCHER|0");
                }
                else
                {
                    actionsEnCours.Enqueue("PIOCHER|0");
                }
            }
            else if (messageRecuDuServeur.StartsWith("OK"))
            {
                // On continue les actions prévues
            }
            else if (messageRecuDuServeur.StartsWith("NOK"))
            {
                // On annule toutes les autres actions si erreur
                actionsEnCours.Clear();
            }
            else if (messageRecuDuServeur == "FIN")
            {
                Console.WriteLine("Partie terminée.");
            }

            // On retourne la prochaine action s'il y en a une
            if (actionsEnCours.Count > 0)
            {
                messageEnvoye = actionsEnCours.Dequeue();
            }

            return messageEnvoye;
        }

        #endregion
    }
}

