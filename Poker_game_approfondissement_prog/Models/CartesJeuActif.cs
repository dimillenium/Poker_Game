using Poker_game_approfondissement_prog.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Poker_game_approfondissement_prog.Models
{
    public class CartesJeuActif
    {
        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        private Queue<Carte> cartes;

        #endregion

        #region PROPRIÉTÉS

        public Queue<Carte> Cartes
        {
            get { return cartes; }
            set { cartes = value; }
        }

        #endregion

        #region CONSTRUCTEURS
        public CartesJeuActif(CartesJeu pCartesJeu)
        {
            Cartes = new Queue<Carte>();
            foreach (Carte carte in pCartesJeu.Cartes)
            {
                Cartes.Enqueue(carte);
            }
        }
        #endregion

        #region MÉTHODES
        public void MelangerCartes()
        {
            // Générateur de nombres aléatoires.
            Random aleatoire = new Random();

            List<Carte> cartes = new List<Carte>();
            // Distribue les cartes aléatoirement.
            for (int i = 0; i < 100; i++)
            {
                cartes.Add(Cartes.Dequeue());
                int j = aleatoire.Next(0, 10);
                if (Cartes.Count == 0 || j == 0)
                {
                    foreach (Carte carte in cartes)
                    {
                        Cartes.Enqueue(carte);
                        Cartes.Enqueue(Cartes.Dequeue());
                    }
                    cartes.Clear();
                }
                Cartes.Enqueue(Cartes.Dequeue());
            }
            foreach (Carte carte in cartes)
            {
                Cartes.Enqueue(carte);
                Cartes.Enqueue(Cartes.Dequeue());
            }
        }
        #endregion

    }
}
