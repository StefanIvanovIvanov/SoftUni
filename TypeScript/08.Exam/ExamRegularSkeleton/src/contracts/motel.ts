//DO NOT CHANGE
import { SummerMonth, WinterMonth } from "./util.js";


export interface Motel {
    addRoom(room: unknown): string;
    bookRoom(roomNumber: 'A01' | 'A02' | 'A03' | 'B01' | 'B02' | 'B03', bookedMonth: WinterMonth | SummerMonth): string;
    cancelBooking(roomNumber: 'A01' | 'A02' | 'A03' | 'B01' | 'B02' | 'B03', bookedMonth: WinterMonth | SummerMonth): string;
    getTotalBudget(): string;
}
