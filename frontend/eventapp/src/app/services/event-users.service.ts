import { Injectable } from '@angular/core';
import { EventUser } from '../models/eventusers';
import { Observable,of } from 'rxjs';
import { EventUsers } from '../datasources/event_users.datasource';

@Injectable({
  providedIn: 'root'
})
export class EventUsersService {

  constructor() { }

  getEventUsers():Observable<EventUser[]>{
    return of(EventUsers); 
  }

  getEventUser(id: number):Observable<EventUser | undefined>{
    return of(EventUsers.find(e=>e.id===id)) || undefined;
  }
}
