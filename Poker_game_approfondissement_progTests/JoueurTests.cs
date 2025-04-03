using Poker_game_approfondissement_prog.Models;
using Poker_game_approfondissement_prog.Models.Exceptions;

namespace Poker_game_approfondissement_progTests
{
    public class JoueurTests
    {
        [Fact]
        public void Joueur_Humain_Devrait_Etre_Cree()
        {
            //Arange

            //Act

            //Assert
            Assert.NotNull(new Humain("Joueur1"));
        }
        [Fact]
        public void Joueur_Ordinateur_Devrait_Etre_Cree()
        {
            //Arange

            //Act

            //Assert
            Assert.NotNull(new Ordinateur("Ordinateur1"));
        }
        #region TestsPseudonyme
        [Fact]
        public void Joueur_Pseudonyme_Ne_Devrait_Pas_Etre_Null()
        {
            //Arange

            //Act


            //Assert
            Assert.Throws<ArgumentNullException>(() => new Humain(null));
        }
        [Fact]
        public void Joueur_Pseudonyme_Ne_Devrait_Pas_Etre_Vide()
        {
            //Arange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new Humain(""));
        }
        [Fact]
        public void Joueur_Pseudonyme_Devrait_Avoir_Longueur_Minimum_De_3()
        {
            //Arange

            //Act

            //Assert
            Assert.Throws<InvalidNameLengthException>(() => new Humain("12"));
        }
        [Fact]
        public void Joueur_Pseudonyme_Devrait_Avoir_Longueur_Maximum_De_21()
        {
            //Arange

            //Act

            //Assert
            Assert.Throws<InvalidNameLengthException>(() => new Humain("1234567890ABCDEFGHIJKL"));
        }
        [Fact]
        public void Joueur_Pseudonyme_Ne_Devrait_Pas_Contenir_Des_Charaters_Speciaux()
        {
            //Arange

            //Act

            //Assert
            Assert.Throws<InvalidNameCharacterException>(() => new Humain("Joueur21*"));
        }
        #endregion // TestsPseudonyme
    }
}