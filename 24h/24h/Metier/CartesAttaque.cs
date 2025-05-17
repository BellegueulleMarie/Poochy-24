using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24h.Metier;

class CartesAttaque : Cartes
{
    public override TypeCartes type => TypeCartes.ATTAQUE;

    public override string description => "Carte d'attaque";


}
