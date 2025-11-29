import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Users } from '../datasources/users.datasource';
import { map, Observable,of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { buildApiUrl, config, endpoints } from '../config/config';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  getUsers():Observable<User[]>{
    return this.http.get<any>(buildApiUrl(endpoints.private.users.getUsers)).pipe(
      map(response => response.$values as User[])
    ); 
  }

  getUser(id: number):Observable<User | undefined>{
    return of(Users.find(u=>u.id===id)) || undefined;
  }

  createUser(user: User):Observable<void>{
    Users.push(user);
    return of(undefined);
  }

  updateUser(user: User):Observable<void>{
    let index = Users.findIndex(u => u.id === user.id);
    Users[index] = user;
    return of(undefined);
  }

  deleteUser(id: number):Observable<void>{
    let index = Users.findIndex(u => u.id === id);
    Users.splice(index, 1);
    return of(undefined);
  }
}
