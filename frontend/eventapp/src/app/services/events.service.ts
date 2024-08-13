import { Injectable } from '@angular/core';
import { Events } from '../datasources/event.datasource';
import { Event } from '../models/event';
import { Observable,of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

    constructor() { }

    getEvents():Observable<Event[]>{
      return of(Events); //bu of metodu ile Events dizisini observable'a çeviriyoruz.
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

    getEvent(id: number): Observable<Event | undefined>{
      return of(Events.find(e => e.id === id)) || undefined;
    }
  
}
