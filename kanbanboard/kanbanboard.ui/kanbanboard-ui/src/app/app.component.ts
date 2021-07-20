import { Observable, of } from 'rxjs';

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
  columns$: Observable<Column[]> = of([]);
  selectedItemText: string | undefined;
  selectedItemId: string | undefined;

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.columns$ = this.apiService.getBoard();
  }

  public getRowCount(columns: Column[]): any[] {
    if(!columns) return [];
    console.log(columns);
    return new Array(Math.max.apply(Math, columns.map(c => c.items.length)));
  }

  setSelectedItem(item: Item | undefined): void {
    this.selectedItemText = item?.text || undefined;
    this.selectedItemId  = item?.id || undefined;
  }

  createItem(): void {
    this.columns$ = this.apiService.createItem(this.selectedItemText!);
    this.setSelectedItem(undefined);
  }

  updateItem(): void {
    this.columns$ = this.apiService.updateItem(this.selectedItemId!, this.selectedItemText!);
    this.setSelectedItem(undefined);
  }

  deleteItem(): void {
    this.columns$ = this.apiService.deleteItem(this.selectedItemId!);
    this.setSelectedItem(undefined);
  }

}
