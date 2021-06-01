import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Film } from '../film.model';

@Component({
  selector: 'app-list-films',
  templateUrl: './films-list.component.html',
  styleUrls: ['./films-list.component.css']
})
export class FilmsListComponent {

  public films: Film[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<Film[]>(apiUrl + 'films').subscribe(result => {
      this.films = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }
}
