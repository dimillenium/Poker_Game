using Poker_game_approfondissement_prog.Models.Enumerations;
using Poker_game_approfondissement_prog.Models.Exceptions;
using System.Text.RegularExpressions;
using System.Windows;


namespace Poker_game_approfondissement_prog.Models
{
    /// <summary>
    /// Classe abstraite représentant un joueur dans le jeu de poker.
    /// </summary>
    public abstract class Joueur
    {

        #region CONSTANTES
        // Aucune constante définie dans cette classe.
        #endregion

        #region ATTRIBUTS
        // Expression régulière pour valider le pseudonyme.
        public Regex regexPseudonyme = new Regex("^[a-zA-Z0-9]+$");
        private string _pseudonyme;
        private List<Carte> cartesMains;
        private EMains mainActuel;
        private EAction actionActuel;
        private int jetons;
        #endregion

        #region PROPRIÉTÉS
        /// <summary>
        /// Obtient ou définit le pseudonyme du joueur.
        /// </summary>
        public abstract string GridName { get; }
        public abstract string JetonsName { get; }
        public abstract string Pseudonyme { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des cartes en main du joueur.
        /// </summary>
        public List<Carte> CartesMains
        {
            get { return this.cartesMains; }
            set { this.cartesMains = value; }
        }

        /// <summary>
        /// Obtient ou définit le type de main actuel du joueur.
        /// </summary>
        public EMains MainActuel
        {
            get { return this.mainActuel; }
            set { this.mainActuel = value; }
        }

        /// <summary>
        /// Obtient ou définit l'action actuelle du joueur.
        /// </summary>
        public EAction ActionActuel
        {
            get { return this.actionActuel; }
            set { this.actionActuel = value; }
        }

        /// <summary>
        /// Obtient ou définit le nombre de jetons du joueur.
        /// </summary>
        public int Jetons
        {
            get { return this.jetons; }
            set { this.jetons = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Constructeur de la classe Joueur.
        /// </summary>
        /// <param name="pPseudonyme">Le pseudonyme du joueur.</param>
        public Joueur(string pPseudonyme)
        {
            // Donne le pseudonyme au joueur.
            Pseudonyme = pPseudonyme;
            cartesMains = new List<Carte>();
            // Donne au joueur 10 000 jetons de base.
            Jetons = 10000;
            
        }
        #endregion

        #region MÉTHODES
        /// <summary>
        /// Ajoute des jetons au total de jetons du joueur.
        /// </summary>
        /// <param name="jetonAjouter">Le nombre de jetons à ajouter.</param>
        public void AjouterJeton(int jetonAjouter)
        {
            Jetons += jetonAjouter;
        }

        /// <summary>
        /// Retire des jetons au total de jetons du joueur.
        /// </summary>
        /// <param name="jetonRetirer">Le nombre de jetons à retirer.</param>
        public void RetirerJeton(int jetonRetirer)
        {
            Jetons -= jetonRetirer;
        }
        #endregion

    }
}
