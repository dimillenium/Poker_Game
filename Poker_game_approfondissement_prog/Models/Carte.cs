using Poker_game_approfondissement_prog.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Poker_game_approfondissement_prog.Models
{
    public class Carte
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        private ECouleursCartes couleur;
        private int valeur;
        private string cheminImage;


        #endregion

        #region PROPRIÉTÉS

        public string CheminImage
        {
            get { return cheminImage; }
            set { cheminImage = value; }
        }
        public int Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }
        public ECouleursCartes Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }

        #endregion

        #region CONSTRUCTEURS
        public Carte(ECouleursCartes pCouleur, int pValeur)
        {
            Couleur = pCouleur;
            Valeur = pValeur;
            CheminImage = $"/Ressources/Images/{Couleur}_{Valeur}.png"; // Chemin de l'image
        }
        #endregion

        #region MÉTHODES

        #endregion

    }
}
