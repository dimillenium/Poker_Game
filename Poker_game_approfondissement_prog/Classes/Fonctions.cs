using Poker_game_approfondissement_prog.Models;
using Poker_game_approfondissement_prog.Models.Enumerations;
using Poker_game_approfondissement_prog.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Poker_game_approfondissement_prog.Classes
{
    public class Fonctions
    {
        const string NOM_FICHIER = @".\Scores.json";

        public static Joueur Obtenir_Joueur_Humain()
        {
            foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
            {
                if (joueur is Humain)
                {
                    return joueur;
                }
            }
            return null;
        }
        public static Joueur ObtenirJoueurGangnantPartie()
        {
            if (ChercherGagnant.EstHumainEliminer())
            {
                if (!ChercherGagnant.EstPartieTerminer())
                {
                    TerminerPartie();
                }
                foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
                {
                    if (AJoueurJetons(joueur))
                    {
                        return joueur;
                    }
                }
            }
            else if (ChercherGagnant.EstPartieTerminer())
            {
                return Obtenir_Joueur_Humain();
            }

            return null;
        }
        public static bool EstJoueurEnJeu(Joueur joueur)
        {
            if (!AJoueurJetons(joueur))
            {
                return false;
            }
            if (EstJoueurCoucher(joueur))
            {
                return false;
            }
            return true;
        }
        public static bool AJoueurJetons(Joueur joueur)
        {
            if (joueur.Jetons <= 0)
            {
                return false;
            }
            return true;
        }
        public static bool EstJoueurCoucher(Joueur joueur)
        {
            if (joueur.ActionActuel == EAction.Coucher)
            {
                return true;
            }
            return false;
        }
        public static void TerminerPartie()
        {
            /*while (!ChercherGagnant.EstPartieTerminer())
            {
                Joueur joueurAvecMoinsJetons = null;
                foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
                {
                    if (EstJoueurEnJeu(joueur))
                    {
                        if (joueurAvecMoinsJetons == null)
                        {
                            joueurAvecMoinsJetons = joueur;
                        }
                        else if (joueurAvecMoinsJetons.Jetons > joueur.Jetons)
                        {
                            joueurAvecMoinsJetons = joueur;
                        }
                    }
                }
                Moteur_jeu.cartesJeuActif.MelangerCartes();
                Moteur_jeu.DistribuerCarte();
                foreach (Joueur joueur in Moteur_jeu.table.Joueurs)
                {
                    if (EstJoueurEnJeu(joueur))
                    {
                        Moteur_jeu.table.AjouterJeton(joueurAvecMoinsJetons.Jetons);
                        joueur.RetirerJeton(joueurAvecMoinsJetons.Jetons);
                    }
                }
                ChercherGagnant.ChercheGagnant();
            }*/
        }
        public static List<Score> ReadJson()
        {
            if (File.Exists(NOM_FICHIER))
            {
                using StreamReader jsonFile = new StreamReader(NOM_FICHIER);
                string jsonText = jsonFile.ReadToEnd();
                if (jsonText != "")
                {
                    return JsonSerializer.Deserialize<List<Score>>(jsonText);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                using StreamWriter jsonFileR = new StreamWriter(NOM_FICHIER);
                jsonFileR.Close();
                if (File.Exists(NOM_FICHIER))
                {
                    using StreamReader jsonFile = new StreamReader(NOM_FICHIER);
                    string jsonText = jsonFile.ReadToEnd();
                    if (jsonText != "")
                    {
                        return JsonSerializer.Deserialize<List<Score>>(jsonText);
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        public static void WriteJson(List<Score> json)
        {
            using StreamWriter jsonFile = new StreamWriter(NOM_FICHIER);
            string jsonText = JsonSerializer.Serialize(json);
            jsonFile.Write(jsonText);
        }
        public static void DeleteJson()
        {
            if (File.Exists(NOM_FICHIER))
            {
                using StreamWriter jsonFile = new StreamWriter(NOM_FICHIER);
                jsonFile.Flush();
            }
            else
            {
                using StreamWriter jsonFile = new StreamWriter(NOM_FICHIER);
            }
        }
    }
}
