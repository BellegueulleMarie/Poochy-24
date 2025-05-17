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
            string reponse = "SORTIR";
            if (!this.IA.ModuleMemoire.HasCarte()) reponse = "CARTE";
            else
            {
                if (this.IA.ModuleMemoire.Diamants.Count > 0 && this.mouvements.Count == 0)
                {
                    AlgorithmeCalculDistance parcours = new ParcoursLargeur(this.IA.ModuleMemoire.Carte); // On crée un algorithme de parcours en largeur à partir de la carte du module mémoire.
                    Case depart = this.IA.ModuleMemoire.Carte.GetCaseAt(this.IA.ModuleMemoire.Joueur.Coordonnees); // On demande à la carte la case de "départ" (où se trouve le joueur)
                    parcours.CalculerDistancesDepuis(depart); // On lance les calculs du parcours en largeur à partir de cette case.
                    int distanceMin = -1;
                    Objet diamantLePlusProche = null;

                    foreach (Objet o in this.IA.ModuleMemoire.Diamants) // Pour tout les objets de la liste des diamants
                    {
                        // Calculer la distance jusqu'au diamant
                        int distance = parcours.GetDistance(o.Position); // On calcule la distance jusqu'au diamant

                        if (distanceMin == -1 || distance < distanceMin) // Si "distanceMin" vaut -1 ou si la distance jusqu 'à "distance" est plus petite que "distanceMin"
                        {
                            distanceMin = distance;
                            diamantLePlusProche = o;
                        }
                    }
                    this.mouvements = parcours.GetChemin(diamantLePlusProche.Position);
                    
                }


                //
                else if (this.mouvements.Count == 0)
                {
                    AlgorithmeCalculDistance parcours = new ParcoursLargeur(this.IA.ModuleMemoire.Carte);
                    Case depart = this.IA.ModuleMemoire.Carte.GetCaseAt(this.IA.ModuleMemoire.Joueur.Coordonnees);
                    Case sortie = this.IA.ModuleMemoire.Carte.GetCaseAt(
                    this.IA.ModuleMemoire.Carte.CoordonneesSortie);
                    parcours.CalculerDistancesDepuis(depart);
                    this.mouvements = parcours.GetChemin(sortie);
                }

                if (this.mouvements.Count > 0)
                {
                    switch (this.mouvements[0])
                    {
                        case TypeMouvement.HAUT: reponse = "BOUGER|HAUT"; break;
                        case TypeMouvement.GAUCHE: reponse = "BOUGER|GAUCHE"; break;
                        case TypeMouvement.DROITE: reponse = "BOUGER|DROITE"; break;
                        case TypeMouvement.BAS: reponse = "BOUGER|BAS"; break;
                    }
                    this.mouvements.RemoveAt(0);
                }
            }
            if (reponse == "SORTIR")
            {
                this.IA.ArreterLaCommunication();
            }
            return reponse;
        }
    #endregion
}
}

