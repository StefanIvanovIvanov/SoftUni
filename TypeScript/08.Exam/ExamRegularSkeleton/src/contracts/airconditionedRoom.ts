//DO NOT CHANGE
import { decorator1, decorator2, decorator3, decorator4 } from "../decorators.js";
import { Room } from "./room.js";

@decorator1
export class AirconditionedRoom implements Room {
    public readonly roomNumber;
    private _price!: number;

    constructor(price: number, roomNumber: 'A01' | 'A02' | 'A03' | 'B01' | 'B02' | 'B03') {
        this.setPrice(price);
        this.roomNumber = roomNumber;
    }

    private setPrice(@decorator4 val: number){
        this._price = val;
    }

    @decorator2
    public get totalPrice(): number {
        return this._price;
    }

    @decorator3
    public get cancellationPrice(): number {
        return this._price;
    }
}

