import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from 'util';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  // tslint:disable-next-line:variable-name
  _filterList: string;

  get filterList() {
    return this._filterList;
  }
  set filterList(value: string) {
    this._filterList = value;
    this.ordersFilter = this.filterList ? this.filterOrders(this.filterList) : this.orders;
  }

  ordersFilter: any = [];

  orders: any = [];
  ordersProducts: any = [];
  filtroLista = '';
  isMenuCollapsed = true;
  panelOpenState = false;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getOrders();
  }

  filterOrders(filterTo: string): any {
    filterTo = filterTo.toLocaleLowerCase();
    return this.orders.filter(
      order => order.clientName.toLocaleLowerCase().concat(
        order.date).indexOf(filterTo) !== -1);
  }

  getOrders() {
    this.http.get('http://localhost:5000/api/orders').subscribe(
      response => { this.orders = response; },
      error => { console.error(error); }
    );
  }

  // api dos itens de pedidos
  getProductsOrders(orderId: number) {
    this.http.get(`http://localhost:5000/api/orderproducts/${orderId}`).subscribe(
      response => {
        this.ordersProducts = response;
        console.log(response);
      },
      error => { console.log(error); }
    );
  }
}
