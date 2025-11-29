import { Injectable } from '@angular/core';
import { catchError, firstValueFrom, map, Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { buildApiUrl, endpoints } from '../config/config';

@Injectable({
  providedIn: 'root'
})
export class AuthService {


  constructor(private http: HttpClient,private router: Router) { }

  async login(username: string, password: string){
    try{
      const response = await firstValueFrom(this.http.post<any>(buildApiUrl(endpoints.public.login), {username, password},{responseType: 'json'}));
      const token = response.token;
      localStorage.setItem ('token', token);
      
      await this.router.navigateByUrl('/home');
      return { success: true };
    }catch(error: any){
      return { success: false, error: error.error || 'Login failed' };
    }
  }

  async register(user: any) {
    try{
     await firstValueFrom(this.http.post(buildApiUrl(endpoints.public.register), user, { responseType: 'text' }));
    }catch(error){
      return error.error;
    }
    this.router.navigateByUrl('/');
  }

}