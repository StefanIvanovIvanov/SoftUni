"use strict";
//old example:
function visitFloor(floor) {
    switch (floor.number) {
        case 1:
            floor.train();
            return;
        case 2:
            floor.dine();
            return;
        case 3:
            floor.sleep();
            return;
    }
}
//should pass:
visitFloor({ train() { }, number: 1, hallway: 'A', pass: 'Guest' });
visitFloor({ dine() { }, number: 2, hallway: 'A' });
visitFloor({ sleep() { }, number: 3, hallway: 'C' });
visitFloor({ train() { }, number: 1, hallway: 'C' });
visitFloor({ train() { }, number: 1, hallway: 'A' });
visitFloor({ dine() { }, number: 2, hallway: 'A', pass: 'Guest' });
visitFloor({ sleep() { }, number: 3, hallway: 'A' });
visitFloor({ dine() { }, number: 2, hallway: 'C' });
// should be marked as errors:
// visitFloor({ train() { }, number: 4, hallway: 'A' });
// visitFloor({ train() { }, number: 1, hallway: 'C', pass: 'Guest' });
// visitFloor({ train() { }, number: 2, hallway: 'A' });
// visitFloor({ train() { }, number: 3, hallway: 'C' });
// visitFloor({ train() { }, number: 3, hallway: 'C', pass: 'Guest' });
// visitFloor({ dine() { }, number: 1, hallway: 'A' });
// visitFloor({ dine() { }, number: 1, hallway: 'B' });
// visitFloor({ dine() { }, number: 1, hallway: 'C' });
// visitFloor({ dine() { }, number: 3, hallway: 'C' });
// visitFloor({ dine() { }, number: 2, hallway: 'C', pass: 'Guest' });
// visitFloor({ dine() { }, number: 1, hallway: 'A', pass: 'Guest' });
// visitFloor({ sleep() { }, number: 3, hallway: 'D' });
// visitFloor({ sleep() { }, number: 4, hallway: 'C' });
// visitFloor({ sleep() { }, number: 1, hallway: 'C' });
// visitFloor({ sleep() { }, number: 1, hallway: 'A' });
// visitFloor({ sleep() { }, number: 2, hallway: 'A' });
// visitFloor({ sleep() { }, number: 2, hallway: 'C' });
//# sourceMappingURL=05.HotelVisit.js.map