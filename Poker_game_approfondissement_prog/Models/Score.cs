using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_game_approfondissement_prog.Models
{
    public class Score
    {
        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        private string jouerLe { get; set; }
        private string tempsJouer { get; set; }
        private string resultat { get; set; }
        private string winner { get; set; }

        #endregion

        #region PROPRIÉTÉS
        public string Winner
        {
            get { return winner; }
            set { winner = value; }
        }

        public string Resultat
        {
            get { return resultat; }
            set { resultat = value; }
        }

        public string TempsJouer
        {
            get { return tempsJouer; }
            set { tempsJouer = value; }
        }

        public string Jouer
        {
            get { return jouerLe; }
            set { jouerLe = value; }
        }

        #endregion

        #region CONSTRUCTEURS
        public Score()
        {
            Jouer = DateTime.Now.ToString("dd MMMM yyyy");
        }
        #endregion

        #region MÉTHODES
        public override string ToString()
        {
            return "";
        }
        #endregion

    }
}
