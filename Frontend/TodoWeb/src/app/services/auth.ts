import { HttpClient } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, tap } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class Auth {
  private apiUrl = 'https://localhost:7174/api/Auth';
  isLoggedIn = signal<boolean>(!!localStorage.getItem('authToken'));

  constructor(private http: HttpClient, private router: Router) {
  }

  signup(data: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/signup`, data);
  }

  signin(data: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/signin`, data);
  }
  
  setLoggedIn(token: string) {
    localStorage.setItem('authToken', token);
    this.isLoggedIn.set(true);
  }
  
}
