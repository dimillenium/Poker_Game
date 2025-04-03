using Poker_game_approfondissement_prog.Classes;
using Poker_game_approfondissement_prog.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_game_approfondissement_prog.Models
{
    public class CartesJeu
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        private List<Carte> cartes;

        #endregion

        #region PROPRIÉTÉS

        public List<Carte> Cartes
        {
            get { return cartes; }
            set { cartes = value; }
        }

        #endregion

        #region CONSTRUCTEURS
        public CartesJeu()
        {
            Cartes = new List<Carte>();
            for (int i = 0; i < Mains.NB_COULEUR; i++)
            {
                for (int j = 1; j <= Mains.NB_CARTES_PAR_COULEUR; j++)
                {
                    Cartes.Add(new Carte((ECouleursCartes)i, j));
                }
            }
        }
        #endregion

        #region MÉTHODES

        #endregion

    }
}
