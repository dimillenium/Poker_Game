using Poker_game_approfondissement_prog.Classes;
using Poker_game_approfondissement_prog.Models.Enumerations;

namespace Poker_game_approfondissement_prog.Models
{
    public class Table
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        private List<Carte> cartesTable;
        private List<Joueur> joueurs;
        private ETour tour;
        private int jetons;
        private DateTime debut;

        #endregion

        #region PROPRIÉTÉS
        public List<Carte> CartesTable
        {
            get { return this.cartesTable; }
            set { this.cartesTable = value; }
        }
        public List<Joueur> Joueurs
        {
            get { return this.joueurs; }
            set { this.joueurs = value; }
        }
        public ETour Tour
        {
            get { return this.tour; }
            set { this.tour = value; }
        }
        public int Jetons
        {
            get { return this.jetons; }
            set { this.jetons = value; }
        }
        public DateTime Debut
        {
            get { return this.debut; }
            set { this.debut = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Table()
        {
            Joueurs = new List<Joueur>();
            CartesTable = new List<Carte>();
            Tour = ETour.Pre_flop;
            Jetons = 0;
            Debut = DateTime.Now;
        }

        #endregion

        #region MÉTHODES
        public void PasserAuTourSuivant()
        {
            Tour++;
            if ((int)Tour == 6)
            {
                Tour = ETour.Pre_flop;
            }
        }

        public void AjouterJeton( int jetonAjouter)
        {
            Jetons += jetonAjouter;
        }
        public void DistribuerJeton(List<Joueur> pJoueurs)
        {
            if (Jetons > 0)
            {
                int qte = Jetons / pJoueurs.Count;
                foreach (Joueur joueur in pJoueurs)
                {
                    joueur.AjouterJeton(qte);
                }
            }
            Jetons = 0;
        }
        #endregion

    }
}
