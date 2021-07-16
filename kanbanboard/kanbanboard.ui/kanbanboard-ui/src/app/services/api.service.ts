import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Board } from '../model/bord-model';
import { Direction } from '../model/direction-enum';

@Injectable({providedIn: 'root'})
  export class ApiService {
  baseUrl: string;

  constructor(private httpClient: HttpClient) {
    this.baseUrl = environment.api.url;
  }

  public getBoard(): Observable<Board> {
    return this.httpClient.get<Board>(`${this.baseUrl}/board`);
  }

  public createItem(text: string): Observable<Board> {
    return this.httpClient.post<Board>('items', { text });
  }

  public updateItem(id: string, text: string): Observable<Board> {
    return this.httpClient.put<Board>(`items/${id}`, { text })
  }

  public deleteItem(id: string): Observable<Board> {
    return this.httpClient.delete<Board>(`items/${id}`);
  }

  public moveItem(id: string, direction: Direction): Observable<Board> {
    return this.httpClient.put<Board>(`items/${id}/move/${direction}`, {});
  }
}
