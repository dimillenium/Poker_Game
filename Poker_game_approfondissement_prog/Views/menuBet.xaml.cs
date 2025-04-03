using Poker_game_approfondissement_prog.Classes;
using Poker_game_approfondissement_prog.Models.Enumerations;
using Poker_game_approfondissement_prog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Poker_game_approfondissement_prog.Views
{
    /// <summary>
    /// Logique d'interaction pour menuBet.xaml
    /// </summary>
    public partial class menuBet : Window
    {
        public Jeu JeuParent { get; set; }
        private TextBox textBox;
        
        public menuBet()
        {
            InitializeComponent();

            JetonRange.Text = $"Choisissez un nombre de jetons entre 1 et {Fonctions.Obtenir_Joueur_Humain().Jetons}:";

            Grid grid = new Grid(); // Création d'une nouvelle Grid

            DockPanel dockPanel = new DockPanel
            {
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(51, 100, 100, 0),
            };

            // Définition de la propriété Grid.Row sur le DockPanel
            Grid.SetRow(dockPanel, 2);

            Label label = new Label
            {
                Content = "G:",
                FontWeight = FontWeights.Bold
            };
            DockPanel.SetDock(label, Dock.Left);

            Slider slColorG = new Slider
            {
                Minimum = 1,
                Maximum = Fonctions.Obtenir_Joueur_Humain().Jetons,
                TickPlacement = TickPlacement.BottomRight,
                IsSnapToTickEnabled = true,
                Name = "slColorG"
            };

            textBox = new TextBox
            {
                Name = "txtjetons",
                TextAlignment = TextAlignment.Right,
                Width = 40
            };
            textBox.SetBinding(TextBox.TextProperty, new System.Windows.Data.Binding("Value") { Source = slColorG, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            DockPanel.SetDock(textBox, Dock.Right);


            // Ajout des éléments au DockPanel
            dockPanel.Children.Add(label);
            dockPanel.Children.Add(textBox);
            dockPanel.Children.Add(slColorG);

            // Obtention de la référence à la grille
            grid = FindName("mainGrid") as Grid;

            // Ajout du dock à la grille
            grid.Children.Add(dockPanel);
        }

        

       

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            int jetons = Convert.ToInt32(textBox.Text);

            Joueur J = Fonctions.Obtenir_Joueur_Humain();

            bool montantInsuffisant = false;


            foreach (Joueur j in Moteur_jeu.table.Joueurs)
            {
                if (jetons <= j.Jetons)
                {
                    JeuParent.Miser(jetons,j);
                }
                else
                {
                    j.ActionActuel = EAction.Coucher;
                }
            }
            Moteur_jeu.table.PasserAuTourSuivant();
            JeuParent.Tour();

            Close();
        }


    }
}
