function convertToObj(strJSON) {
    let obj = JSON.parse(strJSON);
    let objArr = Object.entries(obj);
    for (let [key, value] of objArr) {
        console.log(`${key}: ${value}`);
    }
}

convertToObj('{"name": "George", "age": 40, "town": "Sofia"}');