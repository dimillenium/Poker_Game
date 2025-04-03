using Poker_game_approfondissement_prog.Classes;
using Poker_game_approfondissement_prog.Models;
using Poker_game_approfondissement_prog.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Poker_game_approfondissement_prog.Views
{
    /// <summary>
    /// Logique d'interaction pour Gagnant.xaml
    /// </summary>
    public partial class Gagnant : Window
    {
        public Gagnant()
        {
            InitializeComponent();

            Joueur winner = ChercherGagnant.ObtenirVainqueur();
            if (winner is Humain)
            {
                WinnerMsg.Text = "Félicitations, vous êtes le vainqueur !";
            }
            else if (winner == null)
            {
                WinnerMsg.Text = "Erreur, aucun gagnant";
            }
            else
            {
                WinnerMsg.Text = $"Dommage... Vous avez perdu face à {winner.Pseudonyme}. Meilleure chance la prochaine fois :)";
            }

            if (winner != null)
            {
                CreerScores(winner);
            }
        }
        private void btnRejouer(object pSender, RoutedEventArgs pEvent)
        {
            string pseudo = Fonctions.Obtenir_Joueur_Humain().Pseudonyme;
            Moteur_jeu.Demarrer();
            Joueur humain = Fonctions.Obtenir_Joueur_Humain();
            humain.Pseudonyme = pseudo;

            Jeu jeu = new Jeu();
            jeu.Show();

            Close();
        }
        private void btnRetourMenu(object pSender, RoutedEventArgs pEvent)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
        public void CreerScores(Joueur pWinner)
        {
            string tempsJouer = "";
            TimeSpan timePlay = DateTime.Now.Subtract(Moteur_jeu.table.Debut);
            if (timePlay.TotalHours > 24)
            {
                tempsJouer += $"{timePlay.Days} Jour ";
            }
            if (timePlay.TotalMinutes > 60)
            {
                tempsJouer += $"{timePlay.Hours} Heure";
            }
            if (timePlay.TotalSeconds < 60)
            {
                tempsJouer += $"{timePlay.Seconds} Secondes";
            }
            else
            {
                tempsJouer += $"{timePlay.Minutes} Minutes";
            }
            string winText;
            string winResult;
            if (pWinner is Humain)
            {
                winText = "Vous avez gagné la partie.";
                winResult = "Victoire";
            }
            else
            {
                winText = $"{pWinner.Pseudonyme} a gagné la partie";
                winResult = "Défaite";
            }
            List<Score> _score = new List<Score>();
            _score.Add(new Score()
            {
                TempsJouer = tempsJouer,
                Winner = winText,
                Resultat = winResult
            });
            List<Score> scores = Fonctions.ReadJson();
            if (scores != null)
            {
                foreach (Score score in scores)
                {
                    _score.Add(score);
                }
            }
            Fonctions.WriteJson(_score);
        }
    }
}
