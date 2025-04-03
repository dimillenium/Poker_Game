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

namespace Poker_game_approfondissement_prog.Views
{
    /// <summary>
    /// Logique d'interaction pour Mains.xaml
    /// </summary>
    public partial class Mains : Window
    {
        public Mains()
        {
            InitializeComponent();
        }
        private void btn_Quitter_Click(object pSender, RoutedEventArgs pEvent)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}
