using Poker_game_approfondissement_prog.Classes;
using Poker_game_approfondissement_prog.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Poker_game_approfondissement_prog.Models.Enumerations;
using System.Media;

namespace Poker_game_approfondissement_prog.Views
{
    /// <summary>
    /// Logique d'interaction pour Jeu.xaml
    /// </summary>
    public partial class Jeu : Window
    {

        public Jeu()
        {
            InitializeComponent();

            Nom.Content = Fonctions.Obtenir_Joueur_Humain().Pseudonyme;
            Tour();
        }

        private void btn_Check_Click(object pSender, RoutedEventArgs pEvent)
        {
            if (!Application.Current.Windows.OfType<menuBet>().Any())
            {
                Fonctions.Obtenir_Joueur_Humain().ActionActuel = EAction.Verifier;
                Moteur_jeu.table.PasserAuTourSuivant();
                Tour();
            }
        }
        private void btn_Quitter_Click(object pSender, RoutedEventArgs pEvent)
        {
            ConfirmationDialog confirmationDialog = new ConfirmationDialog("Êtes-vous sûr de vouloir quitter ?", "Vous perdrez la partie et la partie se terminera automatiquement.", "Quitter");
            if (confirmationDialog.ShowDialog() == true)
            {
                // Code pour quitter le jeu si "Continuer" est sélectionné
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                Close();
            }
        }
        private void btn_Fold_Click(object pSender, RoutedEventArgs pEvent)
        {
            if (!Application.Current.Windows.OfType<menuBet>().Any())
            {
                Fonctions.Obtenir_Joueur_Humain().ActionActuel = EAction.Coucher;
                Coucher();
            }
        }

        private void btn_Bet_Click(object pSender, RoutedEventArgs pEvent)
        {
            if (!Application.Current.Windows.OfType<menuBet>().Any())
            {
                if (!Fonctions.AJoueurJetons(Fonctions.Obtenir_Joueur_Humain()))
                {
                    MessageBoxResult result = MessageBox.Show("Imposible de miser, vous n'avez pas asssez de jetons.",
                                                                 "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    menuBet menu = new menuBet();
                    menu.JeuParent = this;
                    menu.Show();
                    Fonctions.Obtenir_Joueur_Humain().ActionActuel = EAction.Miser;
                }
            }
        }
        private void btn_Continuer_Click(object pSender, RoutedEventArgs pEvent)
        {
            Tour();
        }
        public void Tour()
        {
            // Début du pré-flop.
            if (Moteur_jeu.table.Tour == ETour.Pre_flop)
            {
                EffacerBouton();
                Moteur_jeu.cartesJeuActif.MelangerCartes();
                // Distribution des cartes aux joueurs.
                Moteur_jeu.DistribuerCarte();
                // Parcourir chaque joueur dans la table
                AfficherGagnant(0, new List<Joueur>());
                AfficherImageJoueur();
                JouerSonCarte();
                AfficherImageTable(5);
                JouerSonCarte();
                AfficherJetons();
            }
            // Flop 1.
            else if (Moteur_jeu.table.Tour == ETour.Flop_1)
            {
                // TODO: Actions du joueur pendant le flop 1.
                JouerSonCarte();
                AfficherImageTable(3);
                JouerSonCarte();
                AfficherImageJoueur();

            }
            // Flop 2.
            else if (Moteur_jeu.table.Tour == ETour.Flop_2)
            {
                // TODO: Actions du joueur pendant le flop 2.
                JouerSonCarte();
                AfficherImageTable(4);
                JouerSonCarte();
                AfficherImageJoueur();
            }
            // Turn.
            else if (Moteur_jeu.table.Tour == ETour.Tour)
            {
                // TODO: Actions du joueur pendant le tour.
                JouerSonCarte();
                AfficherImageTable(5);
                JouerSonCarte();
                AfficherImageJoueur();
            }
            // River ou fin du jeu.
            else if (Moteur_jeu.table.Tour == ETour.Riviere)
            {
                // Recherche des gagnants à la fin du jeu
                AfficherBouton();
                JouerSonCarte();
                AfficherImageTable(5);
                JouerSonCarte();
                AfficherImageJoueur();
                // TODO: Actions à effectuer à la fin du jeu.
                AfficherGagnant(Moteur_jeu.table.Jetons, ChercherGagnant.ChercheGagnant());
                Moteur_jeu.table.PasserAuTourSuivant();

            }
            else
            {
                RenitialliserAction();
                EffacerBouton();
                AfficherImageTable(5);
                AfficherImageJoueur();
                AfficherPerdant();
                Moteur_jeu.table.PasserAuTourSuivant();
                if (Fonctions.ObtenirJoueurGangnantPartie() != null)
                {
                    Gagnant gagnant = new Gagnant();
                    gagnant.Show();

                    Close();
                }
                Tour();
            }
        }
        public void AfficherGagnant(int jetonsTable, List<Joueur> gagnants)
        {
            if (gagnants.Count == 0)
            {
                AfficherText("gagnantMessage", "");
            }
            else if (gagnants.Count == 1)
            {
                AfficherText("gagnantMessage", $"{gagnants[0].Pseudonyme} remporte la manche avec {gagnants[0].MainActuel} et gagne {jetonsTable} jetons.");
            }
            else if (gagnants.Count >= 2)
            {
                string nomGagnant = "";
                for (int i = 1; i < gagnants.Count; i++)
                {
                    nomGagnant += $", {gagnants[i].Pseudonyme}";
                }
                AfficherText("gagnantMessage", $"{gagnants[0].Pseudonyme + nomGagnant} remportent la manche avec {gagnants[0].MainActuel} et gagnent chacun {jetonsTable / gagnants.Count} jetons.");
            }
        }
        public void AfficherPerdant()
        {
            foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
            {
                if (joueur is Humain)
                {
                    if (Fonctions.EstJoueurEnJeu(joueur))
                    {
                        joueur.ActionActuel = EAction.Verifier;
                    }
                }
                else if (!Fonctions.EstJoueurEnJeu(joueur))
                {
                    Grid loser = FindName($"{joueur.Pseudonyme}_loser") as Grid;
                    if (loser.Children.Count == 0)
                    {
                        Canvas canvas1 = new Canvas
                        {
                            Background = Brushes.Gray,
                            Opacity = 0.5
                        };
                        // Définition de la propriété Grid.Row sur le Canvas
                        Grid.SetRow(canvas1, 2);
                        // Définition de la propriété Grid.ColumnSpan sur le Canvas
                        Grid.SetColumnSpan(canvas1, 5);

                        // Création du deuxième Canvas
                        Canvas canvas2 = new Canvas
                        {
                            Background = Brushes.Red,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Width = 178,
                            Height = 20
                        };
                        // Définition de la propriété Grid.Row sur le Canvas
                        Grid.SetRow(canvas2, 2);
                        // Définition de la propriété Grid.ColumnSpan sur le Canvas
                        Grid.SetColumnSpan(canvas2, 5);

                        // Création du TextBox à l'intérieur du deuxième Canvas
                        TextBox textBox = new TextBox
                        {
                            BorderThickness = new Thickness(0),
                            Background = Brushes.Transparent,
                            FontStyle = FontStyles.Oblique,
                            FontSize = 14,
                            FontWeight = FontWeights.Bold,
                            Foreground = Brushes.White,
                            Margin = new Thickness(57, 0, 0, 0),
                            Text = "Eliminé"
                        };

                        // Ajout du TextBox au deuxième Canvas
                        canvas2.Children.Add(textBox);

                        // Ajout des Canvases à la grille de la fenêtre
                        // Assurez-vous que la grille est nommée "votreGrid" dans votre XAML
                        loser.Children.Add(canvas1);
                        loser.Children.Add(canvas2);
                    }
                }
            }
        }
        public void AfficherJetons()
        {
            foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
            {
                AfficherText(joueur.JetonsName, joueur.Jetons.ToString());
            }
            AfficherText("Jetons_Table", Moteur_jeu.table.Jetons.ToString());
        }
        public void EffacerBouton()
        {
            // Obtention de la référence à la grille parent du bouton
            Grid grid = FindName("Grid_Actions") as Grid; // Remplacez VotreGrille par le nom de votre grille parent

            // Parcours des enfants de la grille pour trouver et supprimer le bouton
            for (int i = 0; i < grid.Children.Count; i++)
            {
                if (grid.Children[i] is Button && ((Button)grid.Children[i]).Content.ToString() == "Prochain tour")
                {
                    grid.Children.RemoveAt(i);
                    return; // Sortie de la boucle après avoir supprimé le bouton
                }
            }
        }
        public void AfficherBouton()
        {
            // Création du bouton
            Button continuer = new Button();
            continuer.Content = "Prochain tour"; // Texte du bouton
            continuer.Background = System.Windows.Media.Brushes.White; // Fond blanc
            continuer.FontWeight = FontWeights.Bold; // Poids de police en gras

            // Ajout du gestionnaire d'événements de clic
            continuer.Click += btn_Continuer_Click;

            // Obtention de la référence à la grille où ajouter le bouton
            Grid grid = FindName("Grid_Actions") as Grid; // Remplacez VotreGrille par le nom de votre grille dans votre interface utilisateur

            // Configuration des propriétés de disposition du bouton dans la grille
            Grid.SetColumn(continuer, 1); // Colonne 1
            Grid.SetColumnSpan(continuer, 3); // Colspan de 3
            continuer.Margin = new System.Windows.Thickness(2, 0, 2, 40); // Marge spécifiée

            // Ajout du bouton à la grille
            grid.Children.Add(continuer);
        }
        public void AfficherImageJoueur()
        {
            // Parcourir chaque joueur dans la table
            Joueur humain = Fonctions.Obtenir_Joueur_Humain();
            foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
            {
                int i = 1;
                foreach (Carte carte in joueur.CartesMains)
                {
                    if (Fonctions.EstJoueurCoucher(humain))
                    {
                        if (Fonctions.EstJoueurCoucher(joueur))
                        {
                            AfficherImage("/Ressources/Images/Back.png", $"Carte_{joueur.GridName}_{i}");
                        }
                        else
                        {
                            // Créer un contrôle Image pour afficher l'image de la carte
                            AfficherImage(carte.CheminImage, $"Carte_{joueur.GridName}_{i}");
                        }
                    }
                    else if (Moteur_jeu.table.Tour == ETour.Riviere || joueur is Humain)
                    {
                        if (Fonctions.EstJoueurCoucher(joueur))
                        {
                            AfficherImage("/Ressources/Images/Back.png", $"Carte_{joueur.GridName}_{i}");
                        }
                        else
                        {
                            // Créer un contrôle Image pour afficher l'image de la carte
                            AfficherImage(carte.CheminImage, $"Carte_{joueur.GridName}_{i}");
                        }
                    }
                    else
                    {
                        AfficherImage("/Ressources/Images/Back.png", $"Carte_{joueur.GridName}_{i}");
                    }
                    i++;
                }
            }
        }
        public void AfficherImageTable(int pNbCarte)
        {
            if (Moteur_jeu.table.Tour == ETour.Pre_flop)
            {
                for (int i = 0; i < pNbCarte; i++)
                {
                    AfficherImage("/Ressources/Images/Back.png", $"Carte_Table_{i}");
                }
            }
            else
            {
                for (int i = 0; i < pNbCarte; i++)
                {
                    AfficherImage(Moteur_jeu.table.CartesTable[i].CheminImage, $"Carte_Table_{i}");
                }
            }
        }
        private void AfficherImage(string chemin, string name)
        {
            Grid carteGrid = FindName(name) as Grid;
            Image imageCarte = new Image();
            BitmapImage bitmapImage = new BitmapImage(new Uri(chemin, UriKind.RelativeOrAbsolute));
            imageCarte.Source = bitmapImage;
            carteGrid.Children.Add(imageCarte);
        }
        private void AfficherText(string chemin, string message)
        {
            TextBlock textBlock = FindName(chemin) as TextBlock;
            textBlock.Text = message;
        }
        public void Coucher()
        {
            foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
            {
                if (Fonctions.EstJoueurEnJeu(joueur))
                {
                    joueur.ActionActuel = EAction.Verifier;
                }
            }
            Moteur_jeu.table.Tour = ETour.Riviere;
            Tour();
        }
        public virtual void Miser(int mise, Joueur joueur)
        {
            if (Fonctions.EstJoueurEnJeu(joueur))
            {

                if (mise > joueur.Jetons)
                {
                    joueur.ActionActuel = EAction.Coucher;
                }
                else
                {
                    Moteur_jeu.table.AjouterJeton(mise);
                    joueur.RetirerJeton(mise);
                }

            }

            AfficherJetons();
        }
        public void RenitialliserAction()
        {
            foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
            {
                if (joueur.ActionActuel != EAction.Verifier)
                {
                    if (Fonctions.AJoueurJetons(joueur))
                    {
                        joueur.ActionActuel = EAction.Verifier;
                    }
                    else
                    {
                        joueur.ActionActuel = EAction.Coucher;
                    }
                }
            }
        }
        public void JouerSonCarte()
        {
            // Replace "sound.wav" with the path to your sound file
            string soundFilePath = @"Ressources/Sons/CarteDrop.wav";

            // Check if the file exists
            if (System.IO.File.Exists(soundFilePath))
            {
                // Create SoundPlayer object
                SoundPlayer player = new SoundPlayer(soundFilePath);

                // Play the sound
                player.Play();
            }
        }
    }
}

