using Poker_game_approfondissement_prog.Models;
using Poker_game_approfondissement_prog.Models.Enumerations;

namespace Poker_game_approfondissement_prog.Classes
{
    public class ChercherGagnant
    {
        public static List<Joueur> ChercheGagnant()
        {
            RegardeLaMainDesJoueurs();

            List<Joueur> joueursGagnant = new List<Joueur>();
            Stack<Joueur> joueursMainsHaute = ObtenirJoueursAvecMainsHaute();
            joueursGagnant.Add(joueursMainsHaute.Pop());
            while (joueursMainsHaute.Count != 0)
            {
                if (!Fonctions.EstJoueurCoucher(joueursMainsHaute.Peek()))
                {
                    Joueur gagnant = ChercheGagnantSiEgaliter(joueursGagnant[0], joueursMainsHaute.Peek());
                    if (gagnant == null)
                    {
                        joueursGagnant.Add(joueursMainsHaute.Pop());
                    }
                    else if (gagnant == joueursMainsHaute.Peek())
                    {
                        joueursGagnant.Clear();
                        joueursGagnant.Add(joueursMainsHaute.Pop());
                    }
                    else
                    {
                        joueursMainsHaute.Pop();
                    }
                }
                else
                {
                    joueursMainsHaute.Pop();
                }
            }
            Moteur_jeu.table.DistribuerJeton(joueursGagnant);
            return joueursGagnant;
        }
        public static Stack<Joueur> ObtenirJoueursAvecMainsHaute()
        {
            EMains mainHaute = EMains.CarteHaute;
            Stack<Joueur> joueursMainsHaute = new Stack<Joueur>();
            foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
            {
                if (joueur.MainActuel > mainHaute)
                {
                    joueursMainsHaute.Clear();
                    joueursMainsHaute.Push(joueur);
                    mainHaute = joueur.MainActuel;
                }
                else if (joueur.MainActuel == mainHaute)
                {
                    joueursMainsHaute.Push(joueur);
                }
            }
            return joueursMainsHaute;
        }
        public static Joueur ChercheGagnantSiEgaliter(Joueur joueur1, Joueur joueur2)
        {
            EMains main = joueur1.MainActuel;


            switch (main)
            {
                case EMains.CarteHaute:
                    return CarteHauteSiEgaliter(joueur1, joueur2);
                case EMains.Paire:
                    return PaireSiEgaliter(joueur1, joueur2);
                case EMains.DeuxPaire:
                    return DeuxPaireSiEgaliter(joueur1, joueur2);
                case EMains.Brelan:
                    return BrelanSiEgaliter(joueur1, joueur2);
                case EMains.Suite:
                    return SuiteSiEgaliter(joueur1, joueur2);
                case EMains.Couleur:
                    return CouleurSiEgaliter(joueur1, joueur2);
                case EMains.Full:
                    return FullSiEgaliter(joueur1, joueur2);
                case EMains.Carre:
                    return CarreSiEgaliter(joueur1, joueur2); ;
                default:
                    return null;
            }
        }
        public static Joueur CarteHauteSiEgaliter(Joueur joueur1, Joueur joueur2)
        {
            Carte carteHauteJ1 = Mains.ObtenirCarteHaute(joueur1.CartesMains);
            Carte carteHauteJ2 = Mains.ObtenirCarteHaute(joueur2.CartesMains);

            Joueur joueurGagnant = JoueurGagnant(joueur1, joueur2, carteHauteJ1, carteHauteJ2);
            if (joueurGagnant == null)
            {
                Carte secondeCarteHauteJ1 = Mains.ObtenirSecondeCarteHaute(joueur1.CartesMains);
                Carte secondeCarteHauteJ2 = Mains.ObtenirSecondeCarteHaute(joueur2.CartesMains);

                return JoueurGagnant(joueur1, joueur2, secondeCarteHauteJ1, secondeCarteHauteJ2);
            }
            else
            {
                return joueurGagnant;
            }
        }
        public static Joueur PaireSiEgaliter(Joueur joueur1, Joueur joueur2)
        {
            Carte paireJ1 = Mains.ObtenirPaire(AppendCartesJoueurEtTable(joueur1));
            Carte paireJ2 = Mains.ObtenirPaire(AppendCartesJoueurEtTable(joueur2));

            Joueur joueurGagnant = JoueurGagnant(joueur1, joueur2, paireJ1, paireJ2);

            if (joueurGagnant == null)
            {
                return CarteHauteSiEgaliter(joueur1, joueur2);
            }
            else
            {
                return joueurGagnant;
            }
        }
        public static Joueur DeuxPaireSiEgaliter(Joueur joueur1, Joueur joueur2)
        {
            Carte paireHauteJ1 = Mains.ObtenirPaireHaute(AppendCartesJoueurEtTable(joueur1));
            Carte paireHauteJ2 = Mains.ObtenirPaireHaute(AppendCartesJoueurEtTable(joueur2));

            Joueur joueurGagnant = JoueurGagnant(joueur1, joueur2, paireHauteJ1, paireHauteJ2);

            if (joueurGagnant == null)
            {
                Carte secondePaireHauteJ1 = Mains.ObtenirSecondePaireHaute(paireHauteJ1, AppendCartesJoueurEtTable(joueur1));
                Carte secondePaireHauteJ2 = Mains.ObtenirSecondePaireHaute(paireHauteJ2, AppendCartesJoueurEtTable(joueur2));

                joueurGagnant = JoueurGagnant(joueur1, joueur2, secondePaireHauteJ1, secondePaireHauteJ2);

                if (joueurGagnant == null)
                {
                    return CarteHauteSiEgaliter(joueur1, joueur2);
                }
                else
                {
                    return joueurGagnant;
                }
            }
            else
            {
                return joueurGagnant;
            }
        }
        public static Joueur BrelanSiEgaliter(Joueur joueur1, Joueur joueur2)
        {
            Carte brelanJ1 = Mains.ObtenirBrelan(AppendCartesJoueurEtTable(joueur1));
            Carte brelanJ2 = Mains.ObtenirBrelan(AppendCartesJoueurEtTable(joueur2));

            Joueur joueurGagnant = JoueurGagnant(joueur1, joueur2, brelanJ1, brelanJ2);

            if (joueurGagnant == null)
            {
                return CarteHauteSiEgaliter(joueur1, joueur2);
            }
            else
            {
                return joueurGagnant;
            }
        }

        public static Joueur CarreSiEgaliter(Joueur joueur1, Joueur joueur2)
        {
            Carte carreJ1 = Mains.ObtenirCarre(AppendCartesJoueurEtTable(joueur1));
            Carte carreJ2 = Mains.ObtenirCarre(AppendCartesJoueurEtTable(joueur2));

            Joueur joueurGagnant = JoueurGagnant(joueur1, joueur2, carreJ1, carreJ2);

            if (joueurGagnant == null)
            {
                return CarteHauteSiEgaliter(joueur1, joueur2);
            }
            else
            {
                return joueurGagnant;
            }
        }

        public static Joueur SuiteSiEgaliter(Joueur joueur1, Joueur joueur2)
        {
            List<Carte> cartesJoueur1 = AppendCartesJoueurEtTable(joueur1);
            List<Carte> cartesJoueur2 = AppendCartesJoueurEtTable(joueur2);
            Mains.Sort(cartesJoueur1);
            Mains.Sort(cartesJoueur2);
            Carte suiteJ1 = Mains.ObtenirSuite(cartesJoueur1);
            Carte suiteJ2 = Mains.ObtenirSuite(cartesJoueur2);

            Joueur joueurGagnant = JoueurGagnant(joueur1, joueur2, suiteJ1, suiteJ2);

            if (joueurGagnant == null)
            {
                return CarteHauteSiEgaliter(joueur1, joueur2);
            }
            else
            {
                return joueurGagnant;
            }
        }
        public static Joueur CouleurSiEgaliter(Joueur joueur1, Joueur joueur2)
        {
            Carte couleurJ1 = Mains.ObtenirCarteHauteCouleur(AppendCartesJoueurEtTable(joueur1));
            Carte couleurJ2 = Mains.ObtenirCarteHauteCouleur(AppendCartesJoueurEtTable(joueur2));

            Joueur joueurGagnant = JoueurGagnant(joueur1, joueur2, couleurJ1, couleurJ2);

            if (joueurGagnant == null)
            {
                return CarteHauteSiEgaliter(joueur1, joueur2);
            }
            else
            {
                return joueurGagnant;
            }
        }

        public static Joueur FullSiEgaliter(Joueur joueur1, Joueur joueur2)
        {
            Carte fullJ1 = Mains.ObtenirBrelan(AppendCartesJoueurEtTable(joueur1));
            Carte fullJ2 = Mains.ObtenirBrelan(AppendCartesJoueurEtTable(joueur2));

            Joueur joueurGagnant = JoueurGagnant(joueur1, joueur2, fullJ1, fullJ2);

            if (joueurGagnant == null)
            {
                return PaireSiEgaliter(joueur1, joueur2);
            }
            else
            {
                return joueurGagnant;
            }
        }

        public static void RegardeLaMainDesJoueurs()
        {
            foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
            {
                if (!Fonctions.EstJoueurCoucher(joueur))
                {
                    joueur.MainActuel = Mains.ObtenirMain(AppendCartesJoueurEtTable(joueur));
                }
            }
        }
        public static List<Carte> AppendCartesJoueurEtTable(Joueur joueur)
        {
            List<Carte> cartes = new List<Carte>();

            foreach (Carte carte in Moteur_jeu.table.CartesTable)
            {
                cartes.Add(carte);
            }
            foreach (Carte carte in joueur.CartesMains)
            {
                cartes.Add(carte);
            }
            return cartes;
        }

        public static Joueur JoueurGagnant(Joueur J1, Joueur J2, Carte carteJ1, Carte carteJ2)
        {
            if (carteJ1 == null || carteJ2 == null)
            {
                return null;
            }
            else if (carteJ1.Valeur == carteJ2.Valeur)
            {
                return null;
            }
            else if (carteJ1.Valeur == (int)EValeursCartes.CA)
            {
                return J1;
            }
            else if (carteJ2.Valeur == (int)EValeursCartes.CA)
            {
                return J2;
            }
            else if (carteJ1.Valeur > carteJ2.Valeur)
            {
                return J1;
            }
            else
            {
                return J2;
            }
        }
        public static bool EstPartieTerminer()
        {
            int joueurPerdue = 0;
            foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
            {
                if (!Fonctions.AJoueurJetons(joueur))
                {
                    joueurPerdue++;
                }
            }

            return joueurPerdue == Moteur_jeu.table.Joueurs.Count - 1;
        }
        public static bool EstHumainEliminer()
        {
            return !Fonctions.AJoueurJetons(Fonctions.Obtenir_Joueur_Humain());
        }
        public static Joueur ObtenirVainqueur()
        {
            foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
            {
                if (Fonctions.EstJoueurEnJeu(joueur))
                {
                    return joueur;
                }
            }

            return null;
        }
    }

}
