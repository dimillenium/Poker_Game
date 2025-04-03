using Poker_game_approfondissement_prog.Models;
using Poker_game_approfondissement_prog.Models.Enumerations;

namespace Poker_game_approfondissement_prog.Classes
{
    public class Mains
    {
        public const int NB_CARTES = 52;
        public const int NB_CARTES_PAR_COULEUR = 13;
        public const int NB_COULEUR = 4;
        public const int MIN_CARTE_NB_COEUR = 1;
        public const int MAX_CARTE_NB_COEUR = 13;
        public const int MIN_CARTE_NB_CARREAU = 14;
        public const int MAX_CARTE_NB_CAREAU = 26;
        public const int MIN_CARTE_NB_TREFLE = 27;
        public const int MAX_CARTE_NB_TREFLE = 39;
        public const int MIN_CARTE_NB_PIQUE = 40;
        public const int MAX_CARTE_NB_PIQUE = 52;


        public static EMains ObtenirMain(List<Carte> cartes)
        {
            EMains main;
            Sort(cartes);

            if (AQuinteFlushRoyale(cartes))
            {
                main = EMains.QuinteFlushRoyale;
            }
            else if (AQuinteFlush(cartes))
            {
                main = EMains.QuinteFlush;
            }
            else if (ObtenirCarre(cartes) != null)
            {
                main = EMains.Carre;
            }
            else if (AFull(cartes))
            {
                main = EMains.Full;
            }
            else if (ObtenirCarteHauteCouleur(cartes) != null)
            {
                main = EMains.Couleur;
            }
            else if (ObtenirSuite(cartes) != null)
            {
                main = EMains.Suite;
            }
            else if (ObtenirBrelan(cartes) != null)
            {
                main = EMains.Brelan;
            }
            else if (ADeuxPaire(cartes))
            {
                main = EMains.DeuxPaire;
            }
            else if (ObtenirPaire(cartes) != null)
            {
                main = EMains.Paire;
            }
            else
            {
                main = EMains.CarteHaute;
            }

            return main;
        }

        public static int CompteLeNombreDeMemeValeur(int valeurCarte, List<Carte> cartes)
        {
            int nbMemeValeur = 0;

            foreach (Carte carte in cartes)
            {
                if (valeurCarte == carte.Valeur)
                {
                    nbMemeValeur++;
                }
            }

            return nbMemeValeur;
        }

        public static Carte ObtenirCarteHaute(List<Carte> cartes)
        {
            Carte cartePlusHaute = cartes[0];
            foreach (Carte carte in cartes)
            {
                if (carte.Valeur == 1)
                {
                    return carte;
                }
                else if (carte.Valeur > cartePlusHaute.Valeur)
                {
                    cartePlusHaute = carte;
                }
            }

            return cartePlusHaute;
        }

        public static Carte ObtenirSecondeCarteHaute(List<Carte> cartes)
        {
            if (cartes[0].Valeur > cartes[1].Valeur)
            {
                return cartes[1];
            }
            return cartes[0];
        }
         public static Carte ObtenirPaire(List<Carte> cartes)
         {
            foreach (Carte carte in cartes)
            {
                if (CompteLeNombreDeMemeValeur(carte.Valeur, cartes) == 2)
                {
                    return carte;
                }
            }
            return null;
         }

        public static Carte ObtenirBrelan(List<Carte> cartes)
        {
            foreach (Carte carte in cartes)
            {
                if (CompteLeNombreDeMemeValeur(carte.Valeur, cartes) == 3)
                {
                    return carte;
                }
            }
            return null;
        }

        public static Carte ObtenirCarre(List<Carte> cartes)
        {
            foreach (Carte carte in cartes)
            {
                if (CompteLeNombreDeMemeValeur(carte.Valeur, cartes) == 4)
                {
                    return carte;
                }
            }
            return null;
        }

        public static bool ADeuxPaire(List<Carte> cartes)
        {
            int cartesPaire = 0;
            foreach (Carte carte in cartes)
            {
                if (CompteLeNombreDeMemeValeur(carte.Valeur, cartes) == 2)
                {
                    cartesPaire++;
                    if (cartesPaire == 4)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static Carte ObtenirPaireHaute(List<Carte> cartes)
        {
            List<Carte> cartesPaire = new List<Carte>();
            foreach (Carte carte in cartes)
            {
                if (CompteLeNombreDeMemeValeur(carte.Valeur, cartes) == 2)
                {
                    cartesPaire.Add(carte);
                    if (cartesPaire.Count == 4)
                    {
                        return ObtenirCarteHaute(cartesPaire);
                    }
                }
            }

            return null;
        }

        public static Carte ObtenirSecondePaireHaute(Carte paireHaute, List<Carte> cartes)
        {
            foreach (Carte carte in cartes)
            {
                if (carte.Valeur != paireHaute.Valeur)
                {
                    if (CompteLeNombreDeMemeValeur(carte.Valeur, cartes) == 2)
                    {
                        return carte;
                    }
                }
            }
            return null;
        }

        public static Carte ObtenirSuite(List<Carte> cartes)
        {
            int nbCarteSuite;
            for (int i = cartes.Count -1; i > 3; i--)
            {
                nbCarteSuite = 1;
                for (int j = cartes.Count - 1; j >= 0; j--)
                {
                    if ((cartes[i].Valeur - nbCarteSuite) == cartes[j].Valeur)
                    {
                        nbCarteSuite++;
                        if (nbCarteSuite == 5)
                        {
                            return cartes[i];
                        }
                    }
                }
            }
            if (cartes[0].Valeur == 1)
            {
                if (ASuiteRoyale(cartes))
                {
                    return cartes[0];
                }
            }

            return null;
        }

        public static bool ASuiteRoyale(List<Carte> cartes)
        {
            int nbCarteSuite = 1;

            if (cartes[0].Valeur != 1)
            {
                return false;
            }
            else
            {
                for (int i = 1; i < cartes.Count; i++)
                {
                    if (cartes[i].Valeur == 10 + nbCarteSuite)
                    {
                        nbCarteSuite++;
                        if (nbCarteSuite == 4)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static Carte ObtenirCouleur(List<Carte> cartes)
        {
            for (int i = 0; i < Mains.NB_COULEUR; i++)
            {
                int nbCarteMemeCouleur = 0;
                for (int j = 0; j < cartes.Count; j++)
                {
                    if (cartes[j].Couleur == (ECouleursCartes)i)
                    {
                        nbCarteMemeCouleur++;
                        if (nbCarteMemeCouleur == 5)
                        {
                            return cartes[j];
                        }
                    }
                }
            }
            return null;
        }

        public static Carte ObtenirCarteHauteCouleur(List<Carte> cartes)
        {
            Carte couleurCarte = ObtenirCouleur(cartes);
            if (couleurCarte != null)
            {
                for (int i = cartes.Count -1; i > 0; i--)
                {
                    if (cartes[i].Couleur == couleurCarte.Couleur)
                    {
                        return cartes[i];
                    }
                }
            }
            return null;
        }

        public static bool AFull(List<Carte> cartes)
        {
            if (ObtenirBrelan(cartes) != null)
            {
                if (ObtenirPaire(cartes) != null)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool AQuinteFlush(List<Carte> cartes)
        {
            if (ObtenirCouleur(cartes) != null)
            {
                if (ObtenirSuite(cartes) != null)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool AQuinteFlushRoyale(List<Carte> cartes)
        {
            if (ObtenirCouleur(cartes) != null)
            {
                if (ASuiteRoyale(cartes))
                {
                    return true;
                }
            }
            return false;
        }
        public static void Sort(List<Carte> cartes)
        {
            Stack<Carte> sortedList = new Stack<Carte>();
            Carte cartehaute;
            while (cartes.Count != 0)
            {
                cartehaute = ObtenirCarteHaute(cartes);
                sortedList.Push(cartehaute);
                cartes.Remove(cartehaute);
            }
            while (sortedList.Count != 0)
            {
                cartes.Add(sortedList.Pop());
            }
        }
    }
}
