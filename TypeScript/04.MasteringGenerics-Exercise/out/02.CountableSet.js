"use strict";
class CountedSet {
    _items = new Map();
    add(item) {
        const currentCount = this._items.get(item);
        if (currentCount) {
            this._items.set(item, currentCount + 1);
        }
        else {
            this._items.set(item, 1);
        }
    }
    ;
    remove(item) {
        const currentCount = this._items.get(item);
        if (currentCount) {
            this._items.set(item, currentCount - 1);
        }
    }
    ;
    contains(item) {
        const currentCount = this._items.get(item);
        return currentCount !== undefined && currentCount > 0;
    }
    ;
    getNumberOfCopies(item) {
        return this._items.get(item) ?? 0;
    }
    ;
}
let countedSet = new CountedSet();
countedSet.add('test');
countedSet.add('test');
console.log(countedSet.contains('test'));
console.log(countedSet.getNumberOfCopies('test'));
countedSet.remove('test');
countedSet.remove('test');
countedSet.remove('test');
console.log(countedSet.getNumberOfCopies('test'));
console.log(countedSet.contains('test'));
let codesCounterSet2 = new CountedSet();
codesCounterSet2.add(404);
codesCounterSet2.add(200);
console.log(codesCounterSet2.contains(404));
console.log(codesCounterSet2.getNumberOfCopies(200));
// codesCounterSet.add(205);   //TS Error
// codesCounterSet.getNumberOfCopies(350);    //TS Error
//# sourceMappingURL=02.CountableSet.js.map