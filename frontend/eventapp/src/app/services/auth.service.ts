import { Injectable } from '@angular/core';
import { catchError, firstValueFrom, map, Observable, throwError } from 'rxjs';
import { User } from '../models/user';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private url = 'http://localhost:5214/api/public/auth';

  constructor(private http: HttpClient,private router: Router) { }

  async login(username: string, password: string){
    try{
      const response = await firstValueFrom(this.http.post<any>(`${this.url}/login`, {username, password},{responseType: 'json'}));
      const token = response.token;
      localStorage.setItem ('token', token);
    }catch(error){
      return error.error;
    }
    this.router.navigateByUrl('/home').then(() => {
      window.location.reload();
  });
  }

  async register(user: any) {
    try{
     await firstValueFrom(this.http.post(`${this.url}/register`, user, { responseType: 'text' }));
    }catch(error){
      return error.error;
    }
    this.router.navigateByUrl('/');
  }

}