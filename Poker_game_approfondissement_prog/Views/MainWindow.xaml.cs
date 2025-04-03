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
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Poker_game_approfondissement_prog.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void btn_Jouer_Click(object pSender, RoutedEventArgs pEvent)
        {
            Pseudonyme pseudonyme = new Pseudonyme();
            pseudonyme.Show();

            Close();
        }
        private void btn_Mains_Click(object pSender, RoutedEventArgs pEvent)
        {
            Mains mains = new Mains();
            mains.Show();

            Close();
        }
        private void btn_Tableau_Scores_Click(object pSender, RoutedEventArgs pEvent)
        {
            Scores scores = new Scores();
            scores.Show();

            Close();
        }
        private void btn_Quitter_Click(object pSender, RoutedEventArgs pEvent)
        {
            Close();
        }
    }
}
