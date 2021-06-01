import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Film } from './film.model';

@Injectable({
  providedIn: 'root'
})
export class FilmsService {

  private apiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.apiUrl = apiUrl;
    }

  getFilms(): Observable<Film[]> {
    return this.httpClient.get<Film[]>(this.apiUrl + 'films');
  }

}
