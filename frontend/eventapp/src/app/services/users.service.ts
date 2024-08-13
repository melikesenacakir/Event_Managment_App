import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Users } from '../datasources/users.datasource';
import { Observable,of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor() { }

  getUsers():Observable<User[]>{
    return of(Users); 
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
