function oddOccurrences(input) {
    let inputArr = input.toLowerCase().split(" ");
    let obj = {};
    for (let element of inputArr) {
        obj[element] = 0;
    }

    for (let word of inputArr) {
        if (obj.hasOwnProperty(word)) {
            obj[word]++;
        }
    }
    let resultArr = [];
    for (let [key, value] of Object.entries(obj)) {
        if (value % 2 !== 0) {
            resultArr.push(key);
        }
    }
    console.log(resultArr.join(" "));
    
}

oddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');