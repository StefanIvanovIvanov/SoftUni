import { Motel } from "./contracts/motel";
import { PartialMonthlyMotel } from "./contracts/partialMonthlyMotel";
import { Room } from "./contracts/room";
import { WinterMonth, SummerMonth } from "./contracts/util";

type RoomNumber = "A01" | "A02" | "A03" | "B01" | "B02" | "B03";
type Month = WinterMonth | SummerMonth;

export class MonthlyMotel<T extends Month> extends PartialMonthlyMotel implements Motel {

    private totalBudget: number = 0;
    private rooms: Set<Room> = new Set<Room>();
    private bookedRooms: Map<RoomNumber, T> = new Map<RoomNumber, T>();


    public addRoom(room: unknown): string {

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

    public bookRoom(roomNumber: RoomNumber, bookedMonth: T): string {
        
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
    this.totalBudget +=roomPrice;
	return `Room '${roomNumber}' booked for '${bookedMonth}'.`;     
    }



    public cancelBooking(roomNumber: RoomNumber, bookedMonth: T): string {
        
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


    public getTotalBudget(): string {
        return `Motel: ${PartialMonthlyMotel.MotelName}\nTotal budget: $${this.totalBudget.toFixed(2)}`
    }
}


function isRoom(room: unknown): room is Room {
    return typeof room === 'object' && room !== null &&
        'roomNumber' in room && 
        'totalPrice' in room && 
        'cancellationPrice' in room &&
        typeof (room as Room).roomNumber === 'string' &&
        typeof (room as Room).totalPrice === 'number' &&
        typeof (room as Room).cancellationPrice === 'number';
}


export class Apartment implements Room {
    public roomNumber: RoomNumber;
    public totalPrice: number;
    public cancellationPrice: number;
    
    constructor(price: number, roomNumber: RoomNumber, numberOfGuests: number) {
        this.totalPrice = price * numberOfGuests;
        this.cancellationPrice = this.totalPrice * 0.8;
        this.roomNumber = roomNumber;
    }
}