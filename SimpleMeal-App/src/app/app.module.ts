import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TablesComponent } from './tables/tables.component';
import { NavComponent } from './nav/nav.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { OrdersComponent } from './orders/orders.component';
import { OrderCardComponent } from './order-card/order-card.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatExpansionModule } from '@angular/material/expansion';

@NgModule({
   declarations: [
      AppComponent,
      TablesComponent,
      NavComponent,
      SidebarComponent,
      OrdersComponent,
      OrderCardComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      BrowserAnimationsModule,
      MatExpansionModule,
      FormsModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
