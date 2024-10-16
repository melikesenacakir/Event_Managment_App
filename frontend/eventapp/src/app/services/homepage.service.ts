import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HomepageService {

  private url = 'http://localhost:5214/api/private/homepage';

  constructor(private http: HttpClient) { }

  getHomepage(): Observable<Event[]> {
    return this.http.get<any>(this.url).pipe(
      map(response => response.$values as Event[])
    );
  }
}
