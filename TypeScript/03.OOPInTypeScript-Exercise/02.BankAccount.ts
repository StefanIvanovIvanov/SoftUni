class BankAccount {
    private balance: number;

   constructor(balance: number){
    this.balance = balance
   }

    public deposit(amount: number): void {
        this.balance += amount;
   }

    public withdraw(amount: number): void {
        if(this.balance >= amount) {
        this.balance -= amount;
        } 
   }

    public getBalance(): number {
        return this.balance;
   }
}

const account = new BankAccount(100);
account.deposit(50);
account.withdraw(30);
console.log(account.getBalance());


const account2 = new BankAccount(20);
account2.withdraw(30);
console.log(account2.getBalance());