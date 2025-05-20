function formatPerson(personInfo: [string, number]) : string {
    return `Hello, my name is ${personInfo[0]} and my age is ${personInfo[1]}`;
}

console.log(formatPerson(['Ivan', 20]));