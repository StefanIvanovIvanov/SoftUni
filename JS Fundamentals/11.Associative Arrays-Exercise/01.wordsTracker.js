function wordsTracker(params) {
    let words = params.shift().split(" ");

    let map = new Map();
    let quantity = 0;
    for (let word of words) {
        map.set(word, quantity);
    }
    for (let param of params) {
        if (map.has(param)) {
            let oldQuantity = map.get(param);
            map.set(param, oldQuantity + 1);
        }
    }
    let sorted = [...map.entries()].sort((a, b) => b[1] - a[1]);
    for (let word of sorted) {
        console.log(`${word[0]} - ${word[1]}`);
    }
}

wordsTracker([
'this sentence', 
'In',
'this',
'sentence',
'you',
'have',
'to',
'count',
'the', 
'occurances',
'of', 
'the', 
'words', 
'this', 
'and', 
'sentence',
'because', 
'this',
'is',
'your', 
'task']);