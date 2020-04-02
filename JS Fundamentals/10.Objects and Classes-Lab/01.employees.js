function employees(firstName, lastName, age) {
    let resultObj = {
        firstName,
        lastName,
        age
    }
    let resultArr = Object.entries(resultObj);
    for (let [key, value] of resultArr) {
        console.log(`${key}: ${value}`);
        
    }
}

employees("Peter", "Pan", "20");