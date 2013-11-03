# BlackJack
from random import shuffle
from random import randrange

class Player:
    def __init__(self):
        self.hand = Hand()
        self.isStanding = False

    def hit(self, value):
        self.hand.addCard(value)

    def stand(self):
        self.isStanding = True

    def getTotal(self):
        return self.hand.getTotal()

    def getCards(self):
        return self.hand.getCards()

    def reset(self):
        self.hand.reset()
        self.isStanding = False

class Hand:
    def __init__(self):
        self.cards = []
        self.total = 0
        self.numAces = 0
        self.__totalWithOutAces = 0

    def addCard(self, value):
        if value != 1:
            self.cards.append(value)
            self.__totalWithOutAces += value;
        else:
            self.numAces += 1

        self.__calculateHand()

    def reset(self):
        self.cards.clear()
        self.total = 0
        self.numAces = 0
        self.__totalWithOutAces = 0

    def getTotal(self):
        return self.total

    def getCards(self):
        allCards = self.cards[:]
        if self.numAces > 0:
            aceCount = self.numAces;
            while aceCount >0:
                allCards.append(1)
                aceCount -=1
        return allCards

    def __calculateHand(self):
        currentTotal = self.__totalWithOutAces
        aceCount = self.numAces
        while aceCount > 0:
            if currentTotal + 11 <= 21 and aceCount -1 == 0:
                currentTotal += 11
            else:
                currentTotal +=1
            aceCount -= 1
        self.total = currentTotal

class Dealer(Player):
    def __init__(self):
        self.resetDeck()
        super().__init__()

    def resetDeck(self):
        print("New deck is being initialized")
        self.deck = self.__initalizeDeck()
        self.__nextCardIndex = 0;

    def dealCard(self):
        if self.__nextCardIndex == len(self.deck):
            self.resetDeck()

        card = self.deck[self.__nextCardIndex]
        self.__nextCardIndex += 1
        return card

    def __initalizeDeck(self):
        newDeck = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,
                   1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,
                   1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10,
                   1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10]
        shuffle(newDeck)
        return newDeck

class BlackJack:
    def __init__(self):
        self.player = Player()
        self.dealer = Dealer()

    def start(self):
        # Initial Phase - Dealer deals two cards to everybody
        # Dealer gives two card to player
        self.player.hit(self.dealer.dealCard())
        self.player.hit(self.dealer.dealCard())

        # Dealer takes two card for himself
        self.dealer.hit(self.dealer.dealCard())
        self.dealer.hit(self.dealer.dealCard())

        playerTotal = 0
        dealerTotal = 0

        while True:
            # Player strategy
            if self.player.isStanding == False:
                playerTotal = self.player.getTotal()
                if playerTotal >= 17 and playerTotal <= 21:
                    self.player.stand()
                else:
                    self.player.hit(self.dealer.dealCard())

            # Dealer strategy
            if self.dealer.isStanding == False:
                dealerTotal = self.dealer.getTotal()
                if dealerTotal >= 17 and dealerTotal <= 21:
                     self.dealer.stand()
                else:
                    self.dealer.hit(self.dealer.dealCard())

            playerTotal = self.player.getTotal()
            dealerTotal = self.dealer.getTotal()

            if playerTotal > 21:
                print("Dealer wins")
                break
            elif dealerTotal > 21:
                print("Player wins")
                break
            elif self.player.isStanding == True and self.dealer.isStanding == True:
                if playerTotal > dealerTotal and playerTotal <=21:
                    print("Player wins")
                    break
                elif playerTotal == dealerTotal:
                    print("Draw")
                    break
                else:
                    print("Dealer wins")
                    break
        print("Player: %d Dealer: %d" %(playerTotal, dealerTotal))
        print("Player hand: %s" %self.player.getCards())
        print("Dealer hand: %s" %self.dealer.getCards())

        # Reset
        self.dealer.reset()
        self.player.reset()

# Test
bj = BlackJack()

for index in range(10):
    print("Game %d is starting....." %index)
    bj.start()
    print("\n")






