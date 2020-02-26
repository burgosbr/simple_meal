import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.css']
})
export class TablesComponent implements OnInit {

  tables: any = [{}];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getTables();
  }

  getTables() {
    this.tables = this.http.get('http://localhost:5000/tables').subscribe(
      response => { this.tables = response; },
      error => { console.log(error); }
    );
  }

}
