import { Injectable } from '@angular/core';
import { Events } from '../datasources/event.datasource';
import { Event } from '../models/event';
import { map, Observable,of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  private url = 'http://localhost:5214/api/private/events';

  private getHeaders(): HttpHeaders {
    const authToken = localStorage.getItem('token');
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${authToken}`
    });
  }

    constructor(private http: HttpClient) { }

    getEvents(): Observable<Event[]> {
      const headers = this.getHeaders();
      return this.http.get<any>(this.url,{headers}).pipe(
        map(response => response.$values as Event[])
      );
    }

    updateEvent(event: Event):Observable<void>{
      let index = Events.findIndex(e => e.id === event.id);
      Events[index] = event;
      return of(undefined);
    }

    createEvent(event: Event):Observable<void>{
      Events.push(event);
      return of(undefined);
    }

    deleteEvent(event: Event):Observable<void>{
      let index = Events.findIndex(e => e.id === event.id);
      Events.splice(index, 1);
      return of(undefined);
    }

    getEvent(id: number): Observable<Event>{
      var events: Event;
      const headers = this.getHeaders();
      return this.http.get<any>(`${this.url}/${id}`,{headers})
      .pipe(
        map(response => {
          const event =response.$values[0];
          events = {
            id: event.events.id,
            date: event.events.date,
            description: event.events.description,
            image: event.events.image,
            location: event.events.location,
            quota: event.events.quota,
            time: event.events.time,
            title: event.events.title,
            user_name: event.user_name
          };
          return events;
    })
    );
    }

    joinEvent(eventId: number, event: Event): Observable<void> {
      const headers = this.getHeaders();
      return this.http.post<any>(`${this.url}/participate/${eventId}`, event,{headers}).pipe(
        map(response => {
          const event = response.$values[0];
          Events.push(event);
          return;
        })
      );
    }

  
}
