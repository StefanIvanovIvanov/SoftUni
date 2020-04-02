function convertToJSON(name, lastName, hairColor) {
    let obj = {
        name,
        lastName,
        hairColor
    }
    let objToJSON = JSON.stringify(obj);
    console.log(objToJSON);
}

convertToJSON('George', 'Jones', 'Brown');