"use strict";
let bankAccount = {
    money: 2000,
    deposit(value) {
        this.money += value;
    }
};
let myself = {
    name: "Mike",
    bankAccount: bankAccount,
    hobbies: ["baseball", "programming"]
};
myself.bankAccount.deposit(3000);
console.log(myself);
