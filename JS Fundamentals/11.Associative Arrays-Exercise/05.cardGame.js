function cardGame(params) {
    let power = {
        "2": 2, "3": 3, "4": 4, "5": 5, "6": 6,
        "7": 7, "8": 8, "9": 9, "10": 10, "J": 11,
        "Q": 12, "K": 13, "A": 14
    };
    let cards = {
        "S": 4, "H": 3, "D": 2, "C": 1
    };

    function getCardValue(card) {
        let p = card.slice(0, card.length - 1);
        let m = card[card.length - 1];
        return power[p] * cards[m];
    }

    let persons = {};

    for (let line of params) {
        let splitted = line.split(": ");
        let name = splitted[0];
        let cards = splitted[1].split(", ");

        if (!persons.hasOwnProperty(name)) {
            persons[name] = cards.filter((value, index, self) => self.indexOf(value) === index);;
        } else {
            persons[name] = persons[name]
            .concat(cards)
            .filter((value, index, self) => self.indexOf(value) === index);
        }
    }

    for (let arr of Object.entries(persons)) {
        let name = arr[0];
        let deckSum = arr[1].map(c => getCardValue(c)).reduce((a, b) => a + b, 0);
        console.log(`${name}: ${deckSum}`);
    }
}
cardGame([
    'Peter: 2C, 4H, 9H, AS, QS',
    'Tomas: 3H, 10S, JC, KD, 5S, 10S',
    'Andrea: QH, QC, QS, QD',
    'Tomas: 6H, 7S, KC, KD, 5S, 10C',
    'Andrea: QH, QC, JS, JD, JC',
    'Peter: JD, JD, JD, JD, JD, JD'
]);