using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using IACryptOfTheNecroDancer.Metier.Cartes;

namespace IACryptOfTheNecroDancer.Modules.Realisations
{
    /// <summary>Module en charge de gérer les réactions de l'IA à une réponse du serveur</summary>
    public class ModuleReaction : Module
    {
        #region --- Attributs ---
        #endregion

        #region --- Propriétés ---
        #endregion

        #region --- Constructeurs ---
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="ia">L'IA dont dépend le module</param>
        public ModuleReaction(IA ia) : base(ia) { }
        #endregion

        #region --- Méthodes ---

        /// <summary>
        /// Méthode réagissant à la réponse du serveur
        /// </summary>
        /// <param name="messageEnvoye">Dernier message envoyé au serveur par l'IA</param>
        /// <param name="messageRecu">Réponse du serveur à ce message</param>
        public void ReagirAuMessageRecu(string messageEnvoye,
        string messageRecu)
        {
            switch (messageEnvoye)
            {
                case "CARTE":
                    ReactionCarte(messageRecu); 
                    break;

                case "BOUGER|HAUT":
                    ReactionMouvement(TypeMouvement.HAUT);
                    break;

                case "BOUGER|BAS":
                    ReactionMouvement(TypeMouvement.BAS);
                    break;

                case "BOUGER|GAUCHE":
                    ReactionMouvement(TypeMouvement.GAUCHE);
                    break;

                case "BOUGER|DROITE":
                    ReactionMouvement(TypeMouvement.DROITE);
                    break;
            }
        }
        private void ReactionCarte(string messageRecu)
        {
            this.IA.ModuleMemoire.GenererCarte(messageRecu);
        }

        private void ReactionMouvement(TypeMouvement mouvement)
        {
            Coordonnees destination = this.IA.ModuleMemoire.Joueur.Coordonnees.GetVoisin(mouvement);
            if (this.IA.ModuleMemoire.Carte.GetCaseAt(destination).CoutDeplacement > 1)
                this.IA.ModuleMemoire.Carte.GetCaseAt(destination).Creuser();
            else
            {
                this.IA.ModuleMemoire.Joueur.Deplacer(mouvement);
                this.IA.ModuleMemoire.Carte.RamasserDiamant(this.IA.ModuleMemoire.Joueur.Coordonnees);
            }
        }
        #endregion
    }
}
