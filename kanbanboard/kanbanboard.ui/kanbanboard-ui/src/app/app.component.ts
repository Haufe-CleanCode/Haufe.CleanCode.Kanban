import { Observable } from 'rxjs';

import { Component, OnInit } from '@angular/core';

import { Board } from './model/bord-model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  board$: Observable<Board>;

  ngOnInit() {
    this.loadBoard();
  }

  loadBoard(): void {

  }

}
