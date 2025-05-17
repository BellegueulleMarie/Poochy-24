using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IACryptOfTheNecroDancer.Metier.Cartes.Objets;
using IACryptOfTheNecroDancer.Metier.Cartes.Terrains;

namespace IACryptOfTheNecroDancer.Metier.Cartes
{
    public class FabriqueCase
    {
        #region --- Méthodes --- 

        /// <summary>
        /// Crée un objet Case en fonction du caractère et des coordonnées spécifiées
        /// </summary>
        /// <param name="caractere">Le caractère représentant le type de terrain et d'objet</param>
        /// <param name="coordonnees">Les coordonnées de la case</param>
        /// <returns>La case créée</returns>
        public static Case Creer(Char caractere, Coordonnees coordonnees)
        {
            Case resultat = new Case(coordonnees);
            resultat.Terrains = FabriqueTerrain.Creer(caractere);
            resultat.Objet = FabriqueObjet.Creer(caractere, resultat);

            return resultat;
        }
        #endregion
    }
}
