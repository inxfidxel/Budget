import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BudgetlistComponent } from './budgetlist/budgetlist.component';
// import { Bill } from './model/bill.model';

@NgModule({
  declarations: [
    AppComponent,
    BudgetlistComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
