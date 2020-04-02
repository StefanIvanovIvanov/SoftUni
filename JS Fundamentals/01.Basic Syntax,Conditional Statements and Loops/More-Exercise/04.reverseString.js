function reverseString(input) {
    let splitted = input.split("");
    let reversedString = ""
    for (let i = splitted.length - 1; i >= 0; i--) {
        reversedString += splitted[i];
    }
    console.log(reversedString);   
    
}

reverseString(`Pesho Stanev`);
