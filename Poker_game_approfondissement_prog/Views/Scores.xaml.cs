using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Poker_game_approfondissement_prog.Models;
using System.IO;
using Poker_game_approfondissement_prog.Classes;

namespace Poker_game_approfondissement_prog.Views
{
    /// <summary>
    /// Logique d'interaction pour Scores.xaml
    /// </summary>
    public partial class Scores : Window
    {

        public Scores()
        {
            InitializeComponent();

            AfficherScores();
        }
        private void btn_Quitter_Click(object pSender, RoutedEventArgs pEvent)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
        private void btn_SupprimerScores_Click(object pSender, RoutedEventArgs pEvent)
        {
            ConfirmationDialog confirmationDialog = new ConfirmationDialog("Êtes-vous sûr de vouloir supprimer l'historique des parties ?",
                "L'historique de ces parties sera supprimée définitivement.",
                "Supprimer");
            if (confirmationDialog.ShowDialog() == true)
            {
                Fonctions.DeleteJson();

                Scores scores = new Scores();
                scores.Show();

                Close();
            }
        }
        private void AfficherScores()
        {

            Grid mainGrid = new Grid();
            mainGrid = FindName("ScoresTab") as Grid;
            int i = 0;
            List<Score> scores = Fonctions.ReadJson();
            if (scores != null)
            {
                foreach (Score score in scores)
                {
                    mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                    // Création du conteneur Grid
                    Grid grid = new Grid();
                    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                    // Définition des colonnes
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175) });

                    Brush bg;
                    if (score.Resultat == "Victoire")
                    {
                        bg = Brushes.ForestGreen;
                    }
                    else
                    {
                        bg = Brushes.Red;
                    }
                    // Création des TextBox
                    TextBox textBox1 = new TextBox
                    {
                        Text = score.Resultat,
                        Padding = new Thickness(10),
                        Background = bg
                    };
                    TextBox textBox2 = new TextBox
                    {
                        Text = score.Winner,
                        Padding = new Thickness(10),
                        Background = Brushes.DodgerBlue
                    };
                    TextBox textBox3 = new TextBox
                    {
                        Text = score.Jouer.ToString(),
                        Padding = new Thickness(10),
                        Background = Brushes.DodgerBlue
                    };
                    TextBox textBox4 = new TextBox
                    {
                        Text = score.TempsJouer,
                        Padding = new Thickness(10),
                        Background = Brushes.DodgerBlue
                    };

                    // Ajout des TextBox au Grid
                    grid.Children.Add(textBox1);
                    grid.Children.Add(textBox2);
                    grid.Children.Add(textBox3);
                    grid.Children.Add(textBox4);

                    // Définition des positions des TextBox dans le Grid
                    Grid.SetColumn(textBox1, 0);
                    Grid.SetColumn(textBox2, 1);
                    Grid.SetColumn(textBox3, 2);
                    Grid.SetColumn(textBox4, 3);
                    Grid.SetRow(grid, i);

                    // Ajout du Grid au contenu de la fenêtre
                    mainGrid.Children.Add(grid);
                    i++;
                }
            }
        }
    }
}
