using IACryptOfTheNecroDancer.Modules.Realisations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IACryptOfTheNecroDancer
{
    /// <summary>
    /// Cette classe représente le coeur de l'IA. Elle joue un rôle de "médiateur" entre les différents modules.
    /// </summary>
    public class IA
    {
        #region --- Attributs ---
        private readonly ModuleCommunication moduleCommunication;           //Module de communication
        private readonly ModuleMemoire moduleMemoire;                       //Module mémoire
        private readonly ModulePriseDeDecisions modulePriseDeDecisions;     //Module de prise de décision
        private readonly ModuleReaction moduleReaction;                     //Module de réaction
        private bool aFiniDeCommuniquer;                                    //La communication est-elle terminée ?
        #endregion

        #region --- Propriétés ---
        /// <summary>
        /// Module en charge de la communication avec le serveur
        /// </summary>
        public ModuleCommunication ModuleCommunication => moduleCommunication;
        /// <summary>
        /// Module en charge de mémoriser les informations nécessaires au fonctionnement de l'IA
        /// </summary>
        public ModuleMemoire ModuleMemoire => moduleMemoire;
        /// <summary>
        /// Module en charge de prendre les décisions
        /// </summary>
        public ModulePriseDeDecisions ModulePriseDeDecisions => modulePriseDeDecisions;
        /// <summary>
        /// Module en charge de réagir aux réponses du serveur
        /// </summary>
        public ModuleReaction ModuleReaction => moduleReaction;
        #endregion

        #region --- Constructeurs ---
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public IA()
        {
            this.moduleCommunication = new ModuleCommunication(this);
            this.moduleMemoire = new ModuleMemoire(this);
            this.modulePriseDeDecisions = new ModulePriseDeDecisions(this);
            this.moduleReaction = new ModuleReaction(this);
            this.aFiniDeCommuniquer = false;
        }
        #endregion

        #region --- Méthodes ---
        /// <summary>
        /// Démarre l'IA
        /// </summary>
        public void Start()
        {
            //Initialisation
            this.aFiniDeCommuniquer = false;
            string messageRecu = "";
            string messageEnvoye = "";
            bool initialiser = false;

            //Mise en place de la connexion au serveur
            this.ModuleCommunication.EtablirConnexion();
            
            messageRecu = this.ModuleCommunication.RecevoirMessage();
            while (!messageRecu.StartsWith("Bonjour"))
            {
                //Détermination de la prochaine action
                messageEnvoye = ModulePriseDeDecisions.DeterminerNouvelleAction(messageRecu);
                this.ModuleCommunication.EnvoyerMessage(messageEnvoye);
                messageRecu = this.ModuleCommunication.RecevoirMessage();
            }
            // Ne rien faire tant qu'on n'est pas dans un tour de jeu
            while (!messageRecu.StartsWith("DEBUT_TOUR") && !this.aFiniDeCommuniquer) 
            { 
                messageRecu = this.ModuleCommunication.RecevoirMessage();

                if (messageRecu == "FIN")
                {
                    this.aFiniDeCommuniquer = true;
                }

                //Détermination de la prochaine action
                messageEnvoye = ModulePriseDeDecisions.DeterminerNouvelleAction(messageRecu);

                //Envoi du message au serveur
                this.moduleCommunication.EnvoyerMessage(messageEnvoye);
                //Réception du message du serveur
                messageRecu = this.ModuleCommunication.RecevoirMessage();
                //Réaction au message 
                this.ModuleReaction.ReagirAuMessageRecu(messageEnvoye, messageRecu);
            }
            //Fermeture de la connexion
            this.ModuleCommunication.FermerConnexion();
        }

        /// <summary>
        /// Méthode appelée quand on souhaite arrêter la communication avec le serveur
        /// </summary>
        public void ArreterLaCommunication()
        {
            this.aFiniDeCommuniquer = true;
        }
        #endregion



    }
}

