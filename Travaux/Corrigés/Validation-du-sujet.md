# Validation du sujet

Membres de l'équipe
* Lavoie-Tremblay Justin
* Dimitri Fondjo Teguem

Sujet: Jeu de poker

Le but du produit est de permettre à un joueur de jouer au poker contre un ordinateur. Chaque participant aura deux cartes en main, et cinq cartes seront placées sur la table. L'objectif est d'obtenir une main plus forte que l'ordinateur.

Il existe plusieurs mains possibles, chacune avec sa probabilité et son nom associé :

1. **Quinte flush royale | Royal flush**
   - Suite du 10 à l'as de même symbole
   - Exemple : 10♥ J♥ Q♥ K♥ A♥
   - Probabilité : <0.01%

2. **Quinte flush | Straight flush**
   - Suite de même symbole
   - Exemple : 4♥ 5♥ 6♥ 7♥ 8♥
   - Probabilité : 0.03%

3. **Carré | 4-of-a-kind**
   - Quatre cartes de même rang
   - Exemple : 10♥ 10♠ 10♦ 10♣ 4♣
   - Probabilité : 0.17%

4. **Full | Full house**
   - Trois cartes de même rang et une paire
   - Exemple : 10♥ 10♠ 10♦ 4♣ 4♥
   - Probabilité : 2.60%

5. **Couleur | Flush**
   - Cinq cartes de même symbole                                       
   - Exemple : 10♥ 3♥ 6♥ A♥ 9♥                                       
   - Probabilité : 3.03%
   
6. **Suite / Quinte | Straight**
   - Suite de symboles différents
   - Exemple : 4♣ 5♥ 6♠ 7♥ 8♦
   - Probabilité : 4.62%

7. **Brelan | 3-of-a-kind**
   - Trois cartes de même rang
   - Exemple : 4♥ 4♦ 4♣ 7♣ K♥
   - Probabilité : 4.83%

8. **Double paire | Two pair**
   - Deux paires
   - Exemple : 2♥ 2♦ 6♠ 6♣ 8♥
   - Probabilité : 23.5%

9. **Paire | One pair**
   - Deux cartes de même rang
   - Exemple : 10♠ 10♦ 6♥ K♥ J♦
   - Probabilité : 43.8%

10. **Carte haute | High card**
   - Carte la plus haute de la main
   - Exemple : 4♠ 7♣ 6♥ A♥ 2♦
   - Probabilité : 17.4%
