import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Column } from '../model/column-model';
import { Direction } from '../model/direction-enum';

@Injectable({providedIn: 'root'})
  export class ApiService {
  baseUrl: string;

  constructor(private httpClient: HttpClient) {
    this.baseUrl = environment.api.url;
  }

  public getBoard(): Observable<Column[]> {
    return this.httpClient.get<{columns: Column[]}>(`${this.baseUrl}/board`)
    .pipe(shareReplay(), map(result => result.columns));
  }

  public createItem(text: string): Observable<Column[]> {
    return this.httpClient.post<{columns: Column[]}>('items', { text })
    .pipe(shareReplay(), map(result => result.columns));
  }

  public updateItem(id: string, text: string): Observable<Column[]> {
    return this.httpClient.put<{columns: Column[]}>(`items/${id}`, { text })
    .pipe(shareReplay(), map(result => result.columns));
  }

  public deleteItem(id: string): Observable<Column[]> {
    return this.httpClient.delete<{columns: Column[]}>(`items/${id}`)
    .pipe(shareReplay(), map(result => result.columns));
  }

  public moveItem(id: string, direction: Direction): Observable<Column[]> {
    return this.httpClient.put<{columns: Column[]}>(`items/${id}/move/${direction}`, {})
    .pipe(shareReplay(), map(result => result.columns));
  }
}
