import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from 'util';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  orders: any = [{}];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getOrders();
  }

  getOrders() {
    this.orders = this.http.get('http://localhost:5000/orders').subscribe(
      response => { this.orders = response; },
      error => { console.log(error); }
    );
  }

}
