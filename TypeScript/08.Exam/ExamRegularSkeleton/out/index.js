"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const monthlyMotel_js_1 = require("./monthlyMotel.js");
const airconditionedRoom_js_1 = require("./contracts/airconditionedRoom.js");
const util_js_1 = require("./contracts/util.js");
// EXAMPLE 1
// let motel = new MonthlyMotel<SummerMonth>();
// let roomA02: Room = new AirconditionedRoom(130, 'A02');
// let roomB01: Room = new AirconditionedRoom(50, 'B01');
// console.log(motel.addRoom(roomA02));
// console.log(motel.addRoom(roomB01));
// console.log(motel.getTotalBudget());
// console.log(motel.bookRoom('A02', SummerMonth.August)); 
// console.log(motel.bookRoom('B01', SummerMonth.July)); 
// console.log(motel.bookRoom('B01', SummerMonth.September)); 
// console.log(motel.getTotalBudget());
// console.log(motel.cancelBooking('B01',SummerMonth.September));  
// console.log(motel.getTotalBudget());
// EXAMPLE 2
// let motel = new MonthlyMotel<WinterMonth>();
// let roomA01: Room = {
//  roomNumber: 'A01',
//  get totalPrice() { return 120; },
//  get cancellationPrice() { return 120; }
// };
// let roomB01: Room = new AirconditionedRoom(200, 'B01');
// let roomNumberB02: 'A01' | 'A02' | 'A03' | 'B01' | 'B02' | 'B03' = 'B02';
// let roomB02 = {
//     roomNumber: roomNumberB02,
//     flatDiscount: 20,
//     price: 320,
//     get totalPrice() { return this.price  - this.flatDiscount },
//     get cancellationPrice() { return this.totalPrice * 0.5; }
// };
// console.log(motel.addRoom(roomA01));
// console.log(motel.addRoom(roomA01));
// console.log(motel.addRoom(roomB01));
// console.log(motel.getTotalBudget());
// console.log(motel.bookRoom('B02', WinterMonth.December));
// console.log(motel.addRoom(roomB02));
// console.log(motel.bookRoom('B02', WinterMonth.December));
// console.log(motel.getTotalBudget());
// console.log(motel.bookRoom('A01', WinterMonth.December));
// console.log(motel.bookRoom('A01', WinterMonth.December));
// console.log(motel.bookRoom('B01', WinterMonth.February));
// console.log(motel.getTotalBudget());
// console.log(motel.cancelBooking('B02', WinterMonth.January));
// console.log(motel.cancelBooking('B02', WinterMonth.December));
// console.log(motel.cancelBooking('B01', WinterMonth.February));
// console.log(motel.getTotalBudget());
// EXAMPLE 3
// let motel = new MonthlyMotel<SummerMonth>();
// console.log(motel.bookRoom('A02', WinterMonth.December));
// console.log(motel.cancelBooking('A02', WinterMonth.December));
// console.log(motel.bookRoom('A04', SummerMonth.August));
//EXAMPLE 4
// let motel = new MonthlyMotel<WinterMonth>();
// let roomA01: Room = new Apartment(110, 'A01', 4);
// let roomA02: Room = new Apartment(70, 'A02', 3);
// console.log(motel.addRoom(roomA01));
// console.log(motel.addRoom(roomA02));
// console.log(motel.bookRoom('A01', WinterMonth.March));
// console.log(motel.getTotalBudget());
// console.log(motel.cancelBooking('A01',WinterMonth.March));
// console.log(motel.getTotalBudget());
// console.log(motel.bookRoom('A02', WinterMonth.February));
// console.log(motel.getTotalBudget());
// EXAMPLE 5
// let roomA01: Room = new AirconditionedRoom(100, 'A01');
// console.log(roomA01.totalPrice);
// console.log(roomA01.cancellationPrice);
// console.log(PartialMonthlyMotel.MotelName);
//EXAMPLE 6
let motel = new monthlyMotel_js_1.MonthlyMotel();
let roomA01 = new airconditionedRoom_js_1.AirconditionedRoom(100, 'A01');
let roomA02 = new airconditionedRoom_js_1.AirconditionedRoom(80, 'A02');
console.log(motel.addRoom(roomA01));
console.log(motel.addRoom(roomA02));
console.log(motel.bookRoom('A01', util_js_1.SummerMonth.August));
console.log(motel.bookRoom('A02', util_js_1.SummerMonth.June));
console.log(motel.getTotalBudget());
console.log(motel.cancelBooking('A01', util_js_1.SummerMonth.August));
console.log(motel.getTotalBudget());
//# sourceMappingURL=index.js.map