function employees(input) {
    let name = "";
    let personalNum = 0;

    for (let i = 0; i < input.length; i++) {
        name = input[i];
        personalNum = input[i].length;
        
        let obj = {
            name: name,
            num: personalNum,
        }

        console.log(`Name: ${obj.name} -- Personal Number: ${obj.num}`);
    }
}

employees(['Silas Butler','Adnaan Buckley','Juan Peterson','Brendan Villarreal']);