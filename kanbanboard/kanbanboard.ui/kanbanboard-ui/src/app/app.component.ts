import { Observable } from 'rxjs';

import { Component, OnInit } from '@angular/core';

import { Column } from './model/column-model';
import { Item } from './model/item-model';
import { ApiService } from './services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  columns$: Observable<Column[]> = this.apiService.getBoard();

  constructor(private apiService: ApiService) {}

  ngOnInit() {
  }

  public getRowCount(columns: Column[]): any[] {
    if(!columns) return [];
    console.log(columns);
    return new Array(Math.max.apply(Math, columns.map(c => c.items.length)));
  }

}
