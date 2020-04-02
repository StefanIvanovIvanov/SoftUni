function cats(inputArr) {
   
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.meow = () => {
                console.log(`${this.name}, age ${this.age} says Meow`);
            }
        }
    }
    for (let input of inputArr) {
        let splitted = input.split(" ");
        let name = splitted[0];
        let age = splitted[1];
        let currentCat = new Cat(name, age);
        currentCat.meow();
    }
}

cats(['Mellow 2', 'Tom 5']);