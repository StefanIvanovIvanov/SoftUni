function matchDate(input) {
    let text = input[0];
    
    let pattern = /(?<day>\d{2})(,| |\/|-|.)(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b/g;
    let result = pattern.exec(text);
    
    while (result !== null) {
        let day = result.groups['day'];
        let month = result.groups['month'];
        let year = result.groups['year'];
        console.log(`Day: ${day}, Month: ${month}, Year: ${year}`);
        result = pattern.exec(text);
    }
}

matchDate(["13/Jul/1928, 10-Nov-1934, , 01/Jan-1951,f 25.Dec.1937 23/09/1973, 1/Feb/2016"]);