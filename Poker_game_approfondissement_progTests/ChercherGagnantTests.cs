using Poker_game_approfondissement_prog.Classes;
using Poker_game_approfondissement_prog.Models;
using Poker_game_approfondissement_prog.Models.Enumerations;

namespace Poker_game_approfondissement_progTests
{
    public class ChercherGagnantTests
    {
        // TODO : suprimer le Model
        [Fact]
        public void Model()
        {
            //Arange
            Table table = new Table();
            table.Joueurs.Add(new Humain("joueur1"));
            table.Joueurs.Add(new Ordinateur("ordinateur1"));

            table.Joueurs[0].CartesMains = [];
            table.Joueurs[1].CartesMains = [];
            table.CartesTable = [];
            //Act

            //Assert

        }
        #region Carte_Haute
        [Fact]
        public void Chercher_Gagnant_Devrait_Retourner_Ordinateur_Gagnant_Avec_Carte_Haute()
        {
            //Arange
            Table table = new Table();
            table.Joueurs.Add(new Humain("joueur1"));
            table.Joueurs.Add(new Ordinateur("ordinateur1"));

            table.Joueurs[0].CartesMains = [new Carte(ECouleursCartes.Carreau, 3), new Carte(ECouleursCartes.Carreau, 4)];
            table.Joueurs[1].CartesMains = [new Carte(ECouleursCartes.Carreau, 1), new Carte(ECouleursCartes.Carreau, 2)];
            table.CartesTable = [new Carte(ECouleursCartes.Pique, 10),
                new Carte(ECouleursCartes.Pique, 9),
                new Carte(ECouleursCartes.Coeur, 8),
                new Carte(ECouleursCartes.Carreau, 6),
                new Carte(ECouleursCartes.Trefle, 5)];

            List<Joueur> expected = new List<Joueur>();
            expected.Add(table.Joueurs[1]);

            //Act
            List<Joueur> gagnant = ChercherGagnant.ChercheGagnant();
            //Assert
            Assert.Equal(expected, gagnant);
        }
        [Fact]
        public void Chercher_Gagnant_Devrait_Retourner_Ordinateur_Et_Humain_Gagnant_Avec_Carte_Haute_Egalite()
        {
            //Arange
            Table table = new Table();
            table.Joueurs.Add(new Humain("joueur1"));
            table.Joueurs.Add(new Ordinateur("ordinateur1"));

            table.Joueurs[0].CartesMains = [new Carte(ECouleursCartes.Carreau, 2), new Carte(ECouleursCartes.Carreau, 1)];
            table.Joueurs[1].CartesMains = [new Carte(ECouleursCartes.Pique, 1), new Carte(ECouleursCartes.Pique, 2)];
            table.CartesTable = [new Carte(ECouleursCartes.Pique, 10),
                new Carte(ECouleursCartes.Pique, 9),
                new Carte(ECouleursCartes.Coeur, 8),
                new Carte(ECouleursCartes.Carreau, 6),
                new Carte(ECouleursCartes.Trefle, 5)];

            List<Joueur> expected = new List<Joueur>();
            expected.Add(table.Joueurs[0]);
            expected.Add(table.Joueurs[1]);

            //Act
            List<Joueur> gagnant = ChercherGagnant.ChercheGagnant();
            //Assert
            Assert.Equal(expected, gagnant);
        }
        #endregion

        #region Paire
        [Fact]
        public void Chercher_Gagnant_Devrait_Retourner_Humain_Gagnant_Avec_Paire()
        {
            Table table = new Table();
            table.Joueurs.Add(new Humain("joueur1"));
            table.Joueurs.Add(new Ordinateur("ordinateur1"));

            table.Joueurs[0].CartesMains = [new Carte(ECouleursCartes.Carreau, 2), new Carte(ECouleursCartes.Carreau, 4)];
            table.Joueurs[1].CartesMains = [new Carte(ECouleursCartes.Pique, 1), new Carte(ECouleursCartes.Pique, 3)];
            table.CartesTable = [new Carte(ECouleursCartes.Pique, 10),
                new Carte(ECouleursCartes.Pique, 2),
                new Carte(ECouleursCartes.Coeur, 8),
                new Carte(ECouleursCartes.Carreau, 6),
                new Carte(ECouleursCartes.Trefle, 5)];

            List<Joueur> expected = new List<Joueur>();
            expected.Add(table.Joueurs[0]);

            //Act
            List<Joueur> gagnant = ChercherGagnant.ChercheGagnant();
            //Assert
            Assert.Equal(expected, gagnant);
        }
        [Fact]
        public void Chercher_Gagnant_Devrait_Retourner_Humain_Gagnant_Avec_Paire_Si_Ordinateur_A_Paire_Moins_Forte()
        {
            Table table = new Table();
            table.Joueurs.Add(new Humain("joueur1"));
            table.Joueurs.Add(new Ordinateur("ordinateur1"));

            table.Joueurs[0].CartesMains = [new Carte(ECouleursCartes.Carreau, 6), new Carte(ECouleursCartes.Carreau, 4)];
            table.Joueurs[1].CartesMains = [new Carte(ECouleursCartes.Pique, 1), new Carte(ECouleursCartes.Pique, 2)];
            table.CartesTable = [new Carte(ECouleursCartes.Pique, 10),
                new Carte(ECouleursCartes.Pique, 2),
                new Carte(ECouleursCartes.Coeur, 8),
                new Carte(ECouleursCartes.Carreau, 6),
                new Carte(ECouleursCartes.Trefle, 5)];

            List<Joueur> expected = new List<Joueur>();
            expected.Add(table.Joueurs[0]);

            //Act
            List<Joueur> gagnant = ChercherGagnant.ChercheGagnant();
            //Assert
            Assert.Equal(expected, gagnant);
        }
        [Fact]
        public void Chercher_Gagnant_Devrait_Retourner_Humain_Gagnant_Avec_Carte_Haute_Si_Ordinateur_A_Meme_Paire()
        {
            Table table = new Table();
            table.Joueurs.Add(new Humain("joueur1"));
            table.Joueurs.Add(new Ordinateur("ordinateur1"));

            table.Joueurs[0].CartesMains = [new Carte(ECouleursCartes.Carreau, 4), new Carte(ECouleursCartes.Carreau, 2)];
            table.Joueurs[1].CartesMains = [new Carte(ECouleursCartes.Pique, 2), new Carte(ECouleursCartes.Pique, 3)];
            table.CartesTable = [new Carte(ECouleursCartes.Pique, 10),
                new Carte(ECouleursCartes.Pique, 2),
                new Carte(ECouleursCartes.Coeur, 8),
                new Carte(ECouleursCartes.Carreau, 6),
                new Carte(ECouleursCartes.Trefle, 5)];

            List<Joueur> expected = new List<Joueur>();
            expected.Add(table.Joueurs[0]);

            //Act
            List<Joueur> gagnant = ChercherGagnant.ChercheGagnant();
            //Assert
            Assert.Equal(expected, gagnant);
        }
        [Fact]
        public void Chercher_Gagnant_Devrait_Retourner_Humain_Et_ordinatuer_Gagnant_Avec_Egalite_Si_Ordinateur_A_Meme_Paire()
        {
            Table table = new Table();
            table.Joueurs.Add(new Humain("joueur1"));
            table.Joueurs.Add(new Ordinateur("ordinateur1"));

            table.Joueurs[0].CartesMains = [new Carte(ECouleursCartes.Carreau, 3), new Carte(ECouleursCartes.Carreau, 2)];
            table.Joueurs[1].CartesMains = [new Carte(ECouleursCartes.Pique, 2), new Carte(ECouleursCartes.Pique, 3)];
            table.CartesTable = [new Carte(ECouleursCartes.Pique, 10),
                new Carte(ECouleursCartes.Pique, 2),
                new Carte(ECouleursCartes.Coeur, 8),
                new Carte(ECouleursCartes.Carreau, 6),
                new Carte(ECouleursCartes.Trefle, 5)];

            List<Joueur> expected = new List<Joueur>();
            expected.Add(table.Joueurs[0]);
            expected.Add(table.Joueurs[1]);

            //Act
            List<Joueur> gagnant = ChercherGagnant.ChercheGagnant();
            //Assert
            Assert.Equal(expected, gagnant);
        }
        #endregion // Paire

        #region Deux_Paire
        [Fact]
        public void Chercher_Gagnant_Devrait_Retourner_Humain_Gagnant_Avec_Deux_Paire()
        {
            Table table = new Table();
            table.Joueurs.Add(new Humain("joueur1"));
            table.Joueurs.Add(new Ordinateur("ordinateur1"));

            table.Joueurs[0].CartesMains = [new Carte(ECouleursCartes.Carreau, 3), new Carte(ECouleursCartes.Carreau, 2)];
            table.Joueurs[1].CartesMains = [new Carte(ECouleursCartes.Pique, 9), new Carte(ECouleursCartes.Pique, 6)];
            table.CartesTable = [new Carte(ECouleursCartes.Pique, 10),
                new Carte(ECouleursCartes.Pique, 2),
                new Carte(ECouleursCartes.Coeur, 3),
                new Carte(ECouleursCartes.Carreau, 6),
                new Carte(ECouleursCartes.Trefle, 5)];

            List<Joueur> expected = new List<Joueur>();
            expected.Add(table.Joueurs[0]);

            //Act
            List<Joueur> gagnant = ChercherGagnant.ChercheGagnant();
            //Assert
            Assert.Equal(expected, gagnant);
        }
        #endregion // Deux_Paire

        #region Brelan
        #endregion // Brelan

        #region Suite
        #endregion // Suite

        #region Couleur
        #endregion // Couleur

        #region Full
        #endregion // Full

        #region Carre
        #endregion // Carre

        #region QuinteFlush
        #endregion // QuinteFlush

        #region QuinteFlushRoyale
        #endregion // QuinteFlushRoyale
    }
}
