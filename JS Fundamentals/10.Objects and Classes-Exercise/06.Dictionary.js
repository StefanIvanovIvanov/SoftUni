function dictionary(inputArr) {
    let resultArr = [];
    for (let el of inputArr) {
        let obj = JSON.parse(el);
        let term = Object.keys(obj);
        term = term[0];

        let definition = Object.values(obj);
        definition = definition[0];

        resultArr.push({
            term,
            definition
        })
    }

    for (let i = 0; i < resultArr.length - 1; i++) {
        for (let j = i + 1; j < resultArr.length; j++) {
            if (resultArr[i].term === resultArr[j].term) {
                resultArr.splice(i, 1);
                i = 0;
                j = i + 1;
            }
        }
    }

    resultArr.sort((a, b) => a.term.localeCompare(b.term))

    for (let obj of resultArr) {
        console.log(`Term: ${obj.term} => Definition: ${obj.definition}`);
    }
}

dictionary(['{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
'{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}', 
'{"Bus":"new definition"}',  '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
'{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
'{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}']);