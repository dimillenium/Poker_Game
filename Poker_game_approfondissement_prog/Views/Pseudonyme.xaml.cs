using Poker_game_approfondissement_prog.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Poker_game_approfondissement_prog.Models;
using Poker_game_approfondissement_prog.Classes;
using System.Reflection.Emit;

namespace Poker_game_approfondissement_prog.Views
{
    /// <summary>
    /// Logique d'interaction pour Pseudonyme.xaml
    /// </summary>
    public partial class Pseudonyme : Window
    {
        public Pseudonyme()
        {
            InitializeComponent();
            Moteur_jeu.Demarrer();
        }
        private void btn_Continuer_Click(object sender, RoutedEventArgs e)
        {
            Joueur humain = Fonctions.Obtenir_Joueur_Humain();
            humain.Pseudonyme = pseudonyme.Text;
            if (humain.Pseudonyme != "")
            {
                Jeu jeu = new Jeu();
                jeu.Show();


                Close();
            }
        }
        private void btn_Annuler_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}
