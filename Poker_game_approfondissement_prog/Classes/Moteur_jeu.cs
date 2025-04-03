using Poker_game_approfondissement_prog.Models;
using Poker_game_approfondissement_prog.Views;
using Poker_game_approfondissement_prog.Models.Enumerations;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Poker_game_approfondissement_prog.Classes
{
    /// <summary>
    /// Classe représentant le moteur du jeu de poker, gérant les différentes étapes du jeu.
    /// </summary>
    public static class Moteur_jeu
    {
        public static Table table;
        public static CartesJeuActif cartesJeuActif;
        /// <summary>
        /// Méthode principale du jeu, orchestrant les tours et les actions des joueurs.
        /// </summary>
        public static void Demarrer()
        {
            CartesJeu cartesJeu = new CartesJeu();
            cartesJeuActif = new CartesJeuActif(cartesJeu);

            // Création d'une nouvelle table.
            table = new Table();
            // Ajout d'un joueur humain et d'un joueur ordinateur à la table.
            table.Joueurs.Add(new Humain("Joueur1"));
            table.Joueurs.Add(new Ordinateur("Ordinateur1"));
            table.Joueurs.Add(new Ordinateur("Ordinateur2"));
            table.Joueurs.Add(new Ordinateur("Ordinateur3"));
            table.Joueurs.Add(new Ordinateur("Ordinateur4"));
        }

        /// <summary>
        /// Distribue les cartes aux joueurs et sur la table.
        /// </summary>
        public static void DistribuerCarte()
        {
            // Retire les cartes des mains de tout les Joueur
            foreach (Joueur joueur in table.Joueurs)
            {
                joueur.CartesMains.Clear();
            }
            // Retire les cartes de la table
            table.CartesTable.Clear();
            // Distribue les cartes à chaque joueur.
            foreach (Joueur joueur in table.Joueurs)
            {
                if (Fonctions.AJoueurJetons(joueur))
                {
                    joueur.ActionActuel = EAction.Verifier;
                    for (int i = 0; i < 2; i++)
                    {
                        joueur.CartesMains.Add(cartesJeuActif.Cartes.Peek());
                        cartesJeuActif.Cartes.Enqueue(cartesJeuActif.Cartes.Dequeue());
                    }
                }
            }

            // Distribue les cartes sur la table.
            for (int i = 0; i < 5; i++)
            {
                table.CartesTable.Add(cartesJeuActif.Cartes.Peek());
                cartesJeuActif.Cartes.Enqueue(cartesJeuActif.Cartes.Dequeue());
            }
        }
    }
}
