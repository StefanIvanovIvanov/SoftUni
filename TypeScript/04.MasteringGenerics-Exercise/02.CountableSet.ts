interface CountableSet<T> {
    add(item:T): void;
    remove(item: T): void;
    contains(item: T): boolean;
    getNumberOfCopies(item: T): number;
}

class CountedSet<T> implements CountableSet<T> {
    private _items: Map<T, number> = new Map();


    add(item:T): void{
        const currentCount = this._items.get(item);

        if(currentCount) {
            this._items.set(item, currentCount + 1);
        } else {
            this._items.set(item, 1);
        }
    };

    remove(item: T): void {
        const currentCount = this._items.get(item);

        if(currentCount) {
            this._items.set(item, currentCount - 1);
        }
    };

    contains(item: T): boolean {
        const currentCount = this._items.get(item);

        return currentCount !== undefined && currentCount > 0;
    };

    getNumberOfCopies(item: T): number {
       return this._items.get(item) ?? 0;
    };
}

let countedSet = new CountedSet<string>();
countedSet.add('test');
countedSet.add('test');
console.log(countedSet.contains('test'));
console.log(countedSet.getNumberOfCopies('test'));
countedSet.remove('test')
countedSet.remove('test')
countedSet.remove('test')
console.log(countedSet.getNumberOfCopies('test'));
console.log(countedSet.contains('test'));


let codesCounterSet2 = new CountedSet<200 | 301 | 404 | 500>();
codesCounterSet2.add(404);
codesCounterSet2.add(200);
console.log(codesCounterSet2.contains(404));
console.log(codesCounterSet2.getNumberOfCopies(200));

// codesCounterSet.add(205);   //TS Error
// codesCounterSet.getNumberOfCopies(350);    //TS Error