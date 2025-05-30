interface Animal {
    makeSound(): string;
}

class Dog implements Animal {
    private sound: string = 'Woof';

     public makeSound(): string {
        return this.sound;
    }
}

const dog = new Dog();
console.log(dog.makeSound());