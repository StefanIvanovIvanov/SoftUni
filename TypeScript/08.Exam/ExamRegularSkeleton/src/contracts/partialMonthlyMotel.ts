//DO NOT CHANGE
import { decorator5 } from "../decorators.js";
import { Motel } from "./motel.js";

@decorator5
export abstract class PartialMonthlyMotel implements Motel {
    public static readonly MotelName = 'Motel';

    abstract addRoom(room: unknown): string;

    abstract bookRoom(roomNumber: string, bookedMonth: string): string;

    abstract cancelBooking(roomNumber: string, bookedMonth: string): string;

    getTotalBudget(): string {
        return `Motel: ${PartialMonthlyMotel.MotelName}`;
    }

}