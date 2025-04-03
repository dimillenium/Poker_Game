using Poker_game_approfondissement_prog.Models.Enumerations;
using Poker_game_approfondissement_prog.Views;

namespace Poker_game_approfondissement_prog.Models
{
    /// <summary>
    /// Classe représentant un joueur contrôlé par l'ordinateur dans le jeu de poker.
    /// </summary>
    public class Ordinateur : Joueur
    {

        #region CONSTANTES
        // Aucune constante spécifique définie dans cette classe.


        #endregion

        #region ATTRIBUTS
        private string _pseudonyme;
        #endregion

        #region PROPRIÉTÉS
        public override string GridName
        {
            get { return Pseudonyme; }
        }
        public override string JetonsName
        {
            get { return $"Jetons_{Pseudonyme}"; }
        }

        public override string Pseudonyme 
        {
            get { return this._pseudonyme; }
            set { this._pseudonyme = value; }
        }

        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Constructeur de la classe Ordinateur.
        /// </summary>
        /// <param name="pPseudonyme">Le pseudonyme de l'ordinateur joueur.</param>
        public Ordinateur(string pPseudonyme) : base(pPseudonyme)
        {
            // L'appel au constructeur de la classe de base (Joueur) est effectué avec le pseudonyme fourni.
            Pseudonyme = pPseudonyme;
        }

        #endregion

        #region MÉTHODES
        // Aucune méthode spécifique définie dans cette classe.
        #endregion

    }
}
