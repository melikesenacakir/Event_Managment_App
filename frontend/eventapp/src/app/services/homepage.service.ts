import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { buildApiUrl, endpoints } from '../config/config';

@Injectable({
  providedIn: 'root'
})
export class HomepageService {

  constructor(private http: HttpClient) { }

  getHomepage(): Observable<Event[]> {
    return this.http.get<any>(buildApiUrl(endpoints.private.home)).pipe(
      map(response => response.$values as Event[])
    );
  }
}
