"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Apartment = exports.MonthlyMotel = void 0;
const partialMonthlyMotel_1 = require("./contracts/partialMonthlyMotel");
class MonthlyMotel extends partialMonthlyMotel_1.PartialMonthlyMotel {
    totalBudget = 0;
    rooms = new Set();
    bookedRooms = new Map();
    addRoom(room) {
        if (!isRoom(room)) {
            return "Value was not a Room.";
        }
        for (const currentRoom of this.rooms) {
            if (currentRoom.roomNumber === room.roomNumber) {
                return `Room '${room.roomNumber}' already exists.`;
            }
        }
        this.rooms.add(room);
        return `Room '${room.roomNumber}' added.`;
    }
    bookRoom(roomNumber, bookedMonth) {
        let roomExists = false;
        let roomPrice = 0;
        for (const room of this.rooms) {
            if (room.roomNumber === roomNumber) {
                roomExists = true;
                roomPrice = room.totalPrice;
                break;
            }
        }
        if (!roomExists) {
            return `Room '${roomNumber}' does not exist.`;
        }
        if (this.bookedRooms.get(roomNumber) === bookedMonth) {
            return `Room '${roomNumber}' is already booked for '${bookedMonth}'`;
        }
        this.bookedRooms.set(roomNumber, bookedMonth);
        this.totalBudget += roomPrice;
        return `Room '${roomNumber}' booked for '${bookedMonth}'.`;
    }
    cancelBooking(roomNumber, bookedMonth) {
        let roomExists = false;
        let cancellationPrice = 0;
        for (const room of this.rooms) {
            if (room.roomNumber === roomNumber) {
                roomExists = true;
                cancellationPrice = room.cancellationPrice;
                break;
            }
        }
        if (!roomExists) {
            return `Room '${roomNumber}' does not exist.`;
        }
        const currentBooking = this.bookedRooms.get(roomNumber);
        if (currentBooking !== bookedMonth) {
            return `Room '${roomNumber}' is not booked for '${bookedMonth}'.`;
        }
        this.bookedRooms.delete(roomNumber);
        this.totalBudget -= cancellationPrice;
        return `Booking cancelled for Room '${roomNumber}' for '${bookedMonth}'.`;
    }
    getTotalBudget() {
        return `Motel: ${partialMonthlyMotel_1.PartialMonthlyMotel.MotelName}\nTotal budget: $${this.totalBudget.toFixed(2)}`;
    }
}
exports.MonthlyMotel = MonthlyMotel;
function isRoom(room) {
    return typeof room === 'object' && room !== null &&
        'roomNumber' in room &&
        'totalPrice' in room &&
        'cancellationPrice' in room &&
        typeof room.roomNumber === 'string' &&
        typeof room.totalPrice === 'number' &&
        typeof room.cancellationPrice === 'number';
}
class Apartment {
    roomNumber;
    totalPrice;
    cancellationPrice;
    constructor(price, roomNumber, numberOfGuests) {
        this.totalPrice = price * numberOfGuests;
        this.cancellationPrice = this.totalPrice * 0.8;
        this.roomNumber = roomNumber;
    }
}
exports.Apartment = Apartment;
//# sourceMappingURL=monthlyMotel.js.map