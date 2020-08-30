function solve() {
    return {
        elements: [],
        size: 0,
        add: function (e){
            this.elements.push(e);
            this.elements.sort((a, b) => a - b);
            this.size = this.elements.length;
        },
        remove: function (index){
            if(index >= this.elements.length || index < 0){
                throw new RangeError('Index is outside the bounds of the list.');
            }
            this.elements.splice(index, 1);
            this.size = this.elements.length;
        },
        get: function (index) {
            if(index >= this.elements.length || index < 0){
                throw new RangeError('Index is outside the bounds of the list.');
            }
            return this.elements[index];
        },
    };
}

let myList = solve();
myList.add(15);
myList.add(30);
myList.add(45);
myList.add(60);
myList.add(75);
myList.add(90);

console.log(myList.elements);
myList.remove(2);
console.log(myList.get(2));
console.log(myList.size);