function arrayManipulations(input) {
    let arr = input.shift().split(" ").map(Number);
    
    for (let element of input) {
        let splitted = element.split(" ");
        let command = splitted[0];
        let value = Number(splitted[1]);
        
        
        if (command === "Add") {
            arr.push(value);
        }
        else if (command === "Remove") {
            let index = arr.indexOf(value);
            while (index !== -1) {
                arr.splice(index, 1);
                index = arr.indexOf(value);
            }
            
        }
        else if (command === "RemoveAt") {
            arr.splice(value, 1);
        }
        else if (command === "Insert") {
            let index = Number(splitted[2]);
            arr.splice(index, 0, value);
        }
        
    }
    console.log(arr.join(" "));
}

arrayManipulations(['4 19 2 53 6 43','Add 3','Remove 2','RemoveAt 1','Insert 8 3']);