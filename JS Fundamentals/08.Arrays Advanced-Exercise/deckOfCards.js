function deckOfCards() {
    let deck = [];
    let shuffledDeck = [];
    let suits = ['Hearts', 'Spades', 'Clubs', 'Diamonds'];
    let values = ['Ace', 2, 3, 4, 5, 6, 7, 8, 9, 10, 'Jack', 'Queen', 'King'];

    for (let i = 0; i < values.length; i++) {
        for (let j = 0; j < suits.length; j++) {
            let card = `${values[i]} of ${suits[j]}`;
            deck.push(card);
        }
    }
    let oldDeck = deck.slice();

    let cards = 51;

    while (deck.length > 0) {
        let randomNum = (Math.random() * cards).toFixed(0);
        let newCard = deck.splice(randomNum, 1);
        shuffledDeck.push(newCard);
        cards -= 1;
    }
    console.log(shuffledDeck.join("\n"));
}

deckOfCards();