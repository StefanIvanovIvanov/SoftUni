function solve(input) {
    let tokens = input.split(' ').filter(token => token !== '');
    let totalSum = 0;


    tokens.forEach(str => {
        let firstChar = str[0];
        let lastChar = str[str.length - 1];
        let number = Number(str.substring((str.indexOf(firstChar) + 1), str.indexOf(lastChar)));
        let sum = 0


        isUpperCase(firstChar) ? number /= getAlphabetPosition(firstChar) : number *= getAlphabetPosition(firstChar);

        isUpperCase(lastChar) ? number -= getAlphabetPosition(lastChar) : number += getAlphabetPosition(lastChar);

        sum += number;
        totalSum += sum;
    });

    console.log(totalSum.toFixed(2));

    function isUpperCase(letter) {
        return (/^[A-Z]$/).test(letter)
    }

    function getAlphabetPosition(letter) {
        letter = letter.toLowerCase();
        return (letter.charCodeAt() - 96)
    };

}
solve('     a5 ');