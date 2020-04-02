function piccolo(input) {
    let obj = {};
    for (let element of input) {
        let splitted = element.split(", ");
        let direction = splitted[0];
        let carNumber = splitted[1];
        obj[carNumber] = direction;
    }
    let resultArr = [];
    for (let [carNum, command] of Object.entries(obj)) {
        if (command === "IN") {
            resultArr.push(carNum);
        } else {
            if(resultArr.includes(carNum)) {
                let index = resultArr.indexOf(carNum);
                resultArr.splice(index, 1);
            }
        }
    }
    let sortedArr = resultArr.sort((a, b) => {
       return a.localeCompare(b);
    })
    if (sortedArr.length > 0) {
        console.log(sortedArr.join("\n"));
    } else {
        console.log("Parking Lot is Empty");
    }
}

piccolo(['IN, CA2844AA','IN, CA1234TA','OUT, CA2844AA','OUT, CA1234TA']);