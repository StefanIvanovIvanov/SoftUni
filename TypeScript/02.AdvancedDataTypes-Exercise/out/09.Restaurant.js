"use strict";
class CustomerOrder {
    dishName;
    price;
    isVegan;
    orderId;
    quantity;
    orderStatus = "Pending";
    constructor(dishName, price, isVegan, orderId, quantity) {
        this.dishName = dishName;
        this.price = price;
        this.isVegan = isVegan;
        this.orderId = orderId;
        this.quantity = quantity;
    }
    getDishInfo() {
        return `${this.dishName} - Price: $${this.price}, Vegan: ${this.isVegan ? 'Yes' : 'No'}`;
    }
    getOrderSummary() {
        return `Order ID: ${this.orderId} - Dish: ${this.dishName}, Quantity: ${this.quantity}, Total Price: $${this.price * this.quantity}, Status: ${this.orderStatus}`;
    }
    updateOrderStatus() {
        if (this.orderStatus === "Pending") {
            this.orderStatus = "Shipped";
        }
        else if (this.orderStatus === "Shipped") {
            this.orderStatus = "Delivered";
        }
    }
    getOrderStatus() {
        return `Order Status: ${this.orderStatus}`;
    }
}
let order = {
    dishName: 'Cheese Burger',
    price: 12,
    isVegan: false,
    orderId: 101,
    quantity: 2,
    discount: 10,
    deliveryAddress: '456 Burger Lane, Food City',
    orderStatus: 'Pending',
    getDishInfo() {
        return `${this.dishName} - Price: $${this.price}, Vegan: ${this.isVegan ? 'Yes' : 'No'}`;
    },
    getOrderSummary() {
        return `Order ID: ${this.orderId} - Dish: ${this.dishName}, Quantity: ${this.quantity}, Total Price: $${this.price * this.quantity}`;
    },
    updateOrderStatus() {
        if (this.orderStatus === "Pending") {
            this.orderStatus = "Shipped";
        }
        else if (this.orderStatus === "Shipped") {
            this.orderStatus = "Delivered";
        }
    },
    getOrderStatus() {
        return `Order Status: ${this.orderStatus}`;
    },
    getFinalPrice() {
        const totalPrice = this.price * this.quantity;
        const finalPrice = totalPrice - (totalPrice * (this.discount / 100));
        return `Final Price after ${this.discount}% discount: $${finalPrice}`;
    }
};
console.log(order.getDishInfo());
console.log(order.getOrderSummary());
console.log(order.getFinalPrice());
console.log(order.getOrderStatus());
order.updateOrderStatus();
console.log(order.getOrderStatus());
//# sourceMappingURL=09.Restaurant.js.map