using System.Windows;

namespace Poker_game_approfondissement_prog.Models
{
    public class Humain : Joueur
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        private string _pseudonyme;
        #endregion

        #region PROPRIÉTÉS
        public override string Pseudonyme
        {
            get { return this._pseudonyme; }
            set
            {
                /// <summary>
                /// Vérification de la validité du pseudonyme.
                /// </summary>
                // Valide si le pseudonyme n'est pas null ou vide.
                if (value == "" || value is null)
                {
                    this._pseudonyme = "";
                    MessageBox.Show("Le pseudonyme ne doit pas etre vide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // Valide si le pseudonyme à une longeur entre 3 et 9 character.
                else if (value.Length < 3 || value.Length > 9)
                {
                    this._pseudonyme = "";
                    MessageBox.Show("Le pseudonyme doit contenir entre 3 et 9 character.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // Valide si le pseudonyme match avec le regex.
                else if (!regexPseudonyme.IsMatch(value))
                {
                    this._pseudonyme = "";
                    MessageBox.Show("Le pseudonyme ne doit pas contenir autre que des lettres ou des nombres.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    this._pseudonyme = value;
                }
            }
        }
        public override string GridName
        {
            get { return "Humain"; }
        }
        public override string JetonsName
        {
            get { return "Jetons_Humain"; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Humain(string pPseudonyme) : base(pPseudonyme)
        {
            Pseudonyme = pPseudonyme;
        }

        #endregion

        #region MÉTHODES

        #endregion

    }
}
