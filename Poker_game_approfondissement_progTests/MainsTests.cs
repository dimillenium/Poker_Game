using Poker_game_approfondissement_prog.Classes;
using Poker_game_approfondissement_prog.Models;
using Poker_game_approfondissement_prog.Models.Enumerations;
using System.Windows.Controls;

namespace Poker_game_approfondissement_progTests
{
    public class MainsTests
    {
        #region Carte_Haute
        [Fact]
        public void Mains_Carte_Haute_Devrait_Retourner_La_Carte_La_Plus_Haute()
        {
            //Arange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Carreau, 7),
                new Carte(ECouleursCartes.Pique, 3),
                new Carte(ECouleursCartes.Trefle, 13)];

            EValeursCartes expected = EValeursCartes.CA;
            //Act
            Carte carteHaute = Mains.ObtenirCarteHaute(cartes);
            //Assert
            Assert.Equal((int)expected, carteHaute.Valeur);
        }
        #endregion

        #region Paire
        [Fact]
        public void Mains_Paire_Devrait_Retourner_Null_Si_Paire_Pas_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Carreau, 7),
                new Carte(ECouleursCartes.Pique, 3),
                new Carte(ECouleursCartes.Trefle, 13)];

            // Act
            Carte paire = Mains.ObtenirPaire(cartes);

            // Assert
            Assert.Null(paire);
        }
        [Fact]
        public void Mains_Paire_Devrait_Trouver_paire_Si_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Carreau, 7),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Trefle, 13)];

            EValeursCartes expected = EValeursCartes.CA;
            // Act
            Carte paire = Mains.ObtenirPaire(cartes);

            // Assert
            Assert.Equal((int)expected, paire.Valeur);
        }
        [Fact]
        public void Mains_Paire_Devrait_Retourner_Null_Si_Brelan_Present()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Carreau, 7),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Trefle, 1)];

            // Act
            Carte paire = Mains.ObtenirPaire(cartes);

            // Assert
            Assert.Null(paire);
        }
        [Fact]
        public void Mains_Paire_Devrait_Retourner_Null_Si_Carre_Present()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Coeur, 1),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Trefle, 1)];

            // Act
            Carte paire = Mains.ObtenirPaire(cartes);

            // Assert
            Assert.Null(paire);
        }
        #endregion // Paire

        #region Deux_Paire
        [Fact]
        public void Mains_Deux_Paire_Devrait_Retourner_Null_Si_Deux_Paire_Pas_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Carreau, 7),
                new Carte(ECouleursCartes.Pique, 3),
                new Carte(ECouleursCartes.Trefle, 13)];

            // Act
            Carte deuxPaire = Mains.ObtenirPaire(cartes);

            // Assert
            Assert.Null(deuxPaire);
        }
        [Fact]
        public void Mains_Deux_Paire_Devrait_Retourner_False_Si_Une_Paire_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Carreau, 7),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Trefle, 13)];

            // Act
            bool aDeuxPaire = Mains.ADeuxPaire(cartes);

            // Assert
            Assert.False(aDeuxPaire);
        }
        [Fact]
        public void Mains_Deux_Paire_Devrait_Retourner_True_Si_Deux_Paire_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Carreau, 7),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Trefle, 4)];

            // Act
            bool aDeuxPaire = Mains.ADeuxPaire(cartes);

            // Assert
            Assert.True(aDeuxPaire);
        }
        [Fact]
        public void Mains_Deux_Paire_Devrait_Retourner_Null_Si_Carre_Present()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Coeur, 1),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Trefle, 1)];

            // Act
            bool aDeuxPaire = Mains.ADeuxPaire(cartes);

            // Assert
            Assert.False(aDeuxPaire);
        }
        #endregion // Deux_Paire

        #region Brelan
        [Fact]
        public void Mains_Brelan_Devrait_Retourner_Null_Si_Brelan_Pas_Present()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Coeur, 3),
                new Carte(ECouleursCartes.Pique, 5),
                new Carte(ECouleursCartes.Trefle, 2)];

            // Act
            Carte brelan = Mains.ObtenirBrelan(cartes);

            // Assert
            Assert.Null(brelan);
        }
        [Fact]
        public void Mains_Brelan_Devrait_Retourner_Null_Si_Paire_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Coeur, 1),
                new Carte(ECouleursCartes.Pique, 5),
                new Carte(ECouleursCartes.Trefle, 2)];

            // Act
            Carte brelan = Mains.ObtenirBrelan(cartes);

            // Assert
            Assert.Null(brelan);
        }
        [Fact]
        public void Mains_Brelan_Devrait_Retourner_Brelan_Si_Present()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Coeur, 1),
                new Carte(ECouleursCartes.Pique, 5),
                new Carte(ECouleursCartes.Trefle, 1)];

            EValeursCartes expected = EValeursCartes.CA;
            // Act
            Carte brelan = Mains.ObtenirBrelan(cartes);

            // Assert
            Assert.Equal((int)expected, brelan.Valeur);
        }
        [Fact]
        public void Mains_Brelan_Devrait_Retourner_Null_Si_Carre_Present()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Coeur, 1),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Trefle, 1)];

            // Act
            Carte brelan = Mains.ObtenirBrelan(cartes);

            // Assert
            Assert.Null(brelan);
        }
        #endregion // Brelan

        #region Suite
        [Fact]
        public void Mains_Suite_Devrait_Retourner_Null_Si_Pas_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Coeur, 1),
                new Carte(ECouleursCartes.Pique, 4),
                new Carte(ECouleursCartes.Trefle, 2)];

            // Act
            Carte suite = Mains.ObtenirSuite(cartes);

            // Assert
            Assert.Null(suite);
        }
        [Fact]
        public void Mains_Suite_Devrait_Retourner_Suite_Si_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 2),
                new Carte(ECouleursCartes.Coeur, 3),
                new Carte(ECouleursCartes.Pique, 4),
                new Carte(ECouleursCartes.Trefle, 5)];

            EValeursCartes expected = EValeursCartes.C5;
            // Act
            Carte suite = Mains.ObtenirSuite(cartes);

            // Assert
            Assert.Equal((int)expected, suite.Valeur);
        }
        [Fact]
        public void Mains_Suite_Devrait_Retourner_Suite_Si_Suite_Royale_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 10),
                new Carte(ECouleursCartes.Coeur, 11),
                new Carte(ECouleursCartes.Pique, 12),
                new Carte(ECouleursCartes.Trefle, 13)];

            EValeursCartes expected = EValeursCartes.CA;
            // Act
            Carte suite = Mains.ObtenirSuite(cartes);

            // Assert
            Assert.Equal((int)expected, suite.Valeur);
        }
        #endregion // Suite

        #region Couleur
        [Fact]
        public void Mains_Couleur_Devrait_Retourner_Null_Si_Pas_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 13),
                new Carte(ECouleursCartes.Coeur, 12),
                new Carte(ECouleursCartes.Pique, 11),
                new Carte(ECouleursCartes.Trefle, 10)];

            // Act
            Carte couleur = Mains.ObtenirCouleur(cartes);

            // Assert
            Assert.Null(couleur);
        }
        [Fact]
        public void Mains_Couleur_Devrait_Retourner_Couleur_Si_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 13),
                new Carte(ECouleursCartes.Carreau, 12),
                new Carte(ECouleursCartes.Carreau, 11),
                new Carte(ECouleursCartes.Carreau, 10)];

            ECouleursCartes expected = ECouleursCartes.Carreau;
            // Act
            Carte couleur = Mains.ObtenirCouleur(cartes);

            // Assert
            Assert.Equal(expected, couleur.Couleur);
        }
        #endregion // Couleur

        #region Full
        [Fact]
        public void Mains_Full_Devrait_Retourner_False_Si_Pas_Present()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 13),
                new Carte(ECouleursCartes.Carreau, 12),
                new Carte(ECouleursCartes.Carreau, 11),
                new Carte(ECouleursCartes.Carreau, 10)];

            // Act
            bool aFull = Mains.AFull(cartes);

            // Assert
            Assert.False(aFull);
        }
        [Fact]
        public void Mains_Full_Devrait_Retourner_True_Si_Present()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 3),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Coeur, 1),
                new Carte(ECouleursCartes.Pique, 3)];

            // Act
            bool aFull = Mains.AFull(cartes);

            // Assert
            Assert.True(aFull);
        }
        #endregion // Full

        #region Carre
        [Fact]
        public void Mains_Carre_Devrait_Retourner_Null_Si_Pas_Present()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 3),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Coeur, 1),
                new Carte(ECouleursCartes.Pique, 3)];

            // Act
            Carte carre = Mains.ObtenirCarre(cartes);

            // Assert
            Assert.Null(carre);
        }
        [Fact]
        public void Mains_Carre_Devrait_Retourner_Carre_Si_Present()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 3),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Coeur, 1),
                new Carte(ECouleursCartes.Trefle, 1)];

            EValeursCartes expected = EValeursCartes.CA;
            // Act
            Carte carre = Mains.ObtenirCarre(cartes);

            // Assert
            Assert.Equal((int)expected, carre.Valeur);
        }
        #endregion // Carre

        #region QuinteFlush
        [Fact]
        public void Mains_Quinte_Flush_Devrait_Retourner_False_Si_Pas_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 3),
                new Carte(ECouleursCartes.Pique, 1),
                new Carte(ECouleursCartes.Coeur, 1),
                new Carte(ECouleursCartes.Trefle, 1)];

            // Act
            bool aQuinteFlush = Mains.AQuinteFlush(cartes);

            // Assert
            Assert.False(aQuinteFlush);
        }
        [Fact]
        public void Mains_Quinte_Flush_Devrait_Retourner_True_Si_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 2),
                new Carte(ECouleursCartes.Carreau, 3),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Carreau, 5)];

            // Act
            bool aQuinteFlush = Mains.AQuinteFlush(cartes);

            // Assert
            Assert.True(aQuinteFlush);
        }
        #endregion // QuinteFlush

        #region QuinteFlushRoyale
        [Fact]
        public void Mains_Quinte_Flush_Royale_Devrait_Retourner_False_Si_Pas_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 2),
                new Carte(ECouleursCartes.Carreau, 3),
                new Carte(ECouleursCartes.Pique, 4),
                new Carte(ECouleursCartes.Carreau, 5)];

            // Act
            bool aQuinteFlushRoyale = Mains.AQuinteFlushRoyale(cartes);

            // Assert
            Assert.False(aQuinteFlushRoyale);
        }
        [Fact]
        public void Mains_Quinte_Flush_Royale_Devrait_Retourner_False_Si_Quinte_Flush_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 2),
                new Carte(ECouleursCartes.Carreau, 3),
                new Carte(ECouleursCartes.Carreau, 4),
                new Carte(ECouleursCartes.Carreau, 5)];

            // Act
            bool aQuinteFlushRoyale = Mains.AQuinteFlushRoyale(cartes);

            // Assert
            Assert.False(aQuinteFlushRoyale);
        }
        [Fact]
        public void Mains_Quinte_Flush_Royale_Devrait_Retourner_True_Si_Presente()
        {
            // Arrange
            List<Carte> cartes = [new Carte(ECouleursCartes.Carreau, 1),
                new Carte(ECouleursCartes.Carreau, 10),
                new Carte(ECouleursCartes.Carreau, 11),
                new Carte(ECouleursCartes.Carreau, 12),
                new Carte(ECouleursCartes.Carreau, 13)];

            // Act
            bool aQuinteFlushRoyale = Mains.AQuinteFlushRoyale(cartes);

            // Assert
            Assert.True(aQuinteFlushRoyale);
        }
        #endregion // QuinteFlushRoyale
    }
}