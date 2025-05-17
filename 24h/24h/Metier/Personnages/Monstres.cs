using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24h.Metier.Personnages
{
    public class Monstres : Personnage
    {
        private string name;
        private int life;
        private int scoreSavoir;
        public override TypePersonnage Type => TypePersonnage.MONSTRES;// Type de personnage 
        public override string Name => this.name; // Le nom du personnage 
        public override int Life => this.life; // Indique la vie du personnage 
        public override int ScoreSavoir => this.scoreSavoir; //  Le score du savoir 

        public Monstres(string name, int life, int scoreSavoir, TypePersonnage type)
        {
            this.name = name;
            this.life = life;
            this.scoreSavoir = scoreSavoir;
        }
}
}
