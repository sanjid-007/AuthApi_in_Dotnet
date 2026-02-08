import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Task {
  private apiUrl = 'https://localhost:7174/api/Todo';
  constructor(private http: HttpClient) {}

  getTasks(): Observable<Task[]> {
    return this.http.get<any>(`${this.apiUrl}/all-tasks`); 
  }
  addTask(data: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/add-Task`, data); 
  }
}
