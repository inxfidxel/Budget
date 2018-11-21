export class Bill {
    
    billId: number;
    dueDate: Date;
    minimumPayment: number;
    payAmount: number;
    billBalance: number;
    billName: string;

    constructor(billId: number, dueDate: Date, minimumPayment: number, payAmount: number, billBalance: number, billName: string) {
        this.billId = billId;
        this.dueDate = dueDate;
        this.minimumPayment = minimumPayment;
        this.payAmount = payAmount;
        this.billBalance = billBalance;
        this.billName = billName;
    }
}