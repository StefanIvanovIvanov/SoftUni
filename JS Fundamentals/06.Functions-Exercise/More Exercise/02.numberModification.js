function numModification(num) {
    let currentArr = num.toString().split("");
    let sum = 0;
    for (let element of currentArr) {
        element = Number(element);
        sum += element;
    }
    let average = sum / currentArr.length;

    while (average <= 5) {
        currentArr.push("9");
        sum = 0;
        for (let element of currentArr) {
            element = Number(element);
            sum += element;
        }
        average = sum / currentArr.length;
    }
    console.log(currentArr.join(""));
}

numModification(101);