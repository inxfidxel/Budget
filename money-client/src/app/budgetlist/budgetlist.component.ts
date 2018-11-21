import { Component, OnInit } from '@angular/core';

import { Bill } from "../model/bill.model";
import { CadenName } from "../model/caden.model";

@Component({
	selector: 'app-budgetlist',
	templateUrl: './budgetlist.component.html',
	styleUrls: ['./budgetlist.component.less']
})
export class BudgetlistComponent implements OnInit {

	budgetList: Array<Bill>;
	cadenNames: Array<CadenName>;
  	constructor() { 
		//testing
		this.budgetList = new Array<Bill>();
		this.getBudgetList();
		this.cadenNames = new Array<CadenName>();
		//this.testWithjakob();
		this.testWithCaden();
		
	}
	  
	getBudgetList() {

		// this.budgetList.push(new Bill(1, new Date('01/01/2018'), 25.00, 50.00, 200.00, 'First Bill'));
		// this.budgetList.push(new Bill(2, new Date('01/05/2018'), 25.00, 50.00, 300.00, 'Second Bill'));
		// this.budgetList.push(new Bill(3, new Date('01/10/2018'), 25.00, 50.00, 200.00, 'Third Bill'));
		// this.budgetList.push(new Bill(4, new Date('01/10/2018'), 25.00, 50.00, 200.00, 'fourth Bill'));
		// this.budgetList.push(new Bill(5, new Date('01/14/2018'), 25.00, 50.00, 200.00, 'fifth Bill'));
		// this.budgetList.push(new Bill(6, new Date('01/22/2018'), 25.00, 50.00, 200.00, 'sixth Bill'));
		// this.budgetList.push(new Bill(7, new Date('01/21/2018'), 25.00, 50.00, 200.00, 'seventh Bill'));
		// this.budgetList.push(new Bill(8, new Date('01/30/2018'), 25.00, 50.00, 200.00, 'eighth Bill'));
		// this.budgetList.push(new Bill(9, new Date('01/1/2018'), 25.00, 50.00, 200.00, 'nintht Bill'));
		// this.budgetList.push(new Bill(19, new Date('01/18/2018'), 25.00, 50.00, 200.00, 'tenth Bill'));

		console.log('hello caden');

	}

	testWithCaden() {
		for(var i = 0; i < 15; i++) {
			this.cadenNames.push(new CadenName('caden ' + i, 'red'));
		}

		this.cadenNames.forEach(element => {
			console.log(element);
		});
	}

 	ngOnInit() {
  	}

}
