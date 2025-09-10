import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { environment } from '../Environments/environments';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class UserService {
  private readonly userApiUrl = environment.apiUrl + '/User';

  constructor(private http: HttpClient) {}

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.userApiUrl);
  }

  getById(id: number): Observable<User> {
    return this.http.get<User>(`${this.userApiUrl}/${id}`);
  }

  // ✨ accepterer kun felter der ændres, men kræver id
  updateUser(user: Partial<User> & { id: number }): Observable<User> {
    return this.http.put<User>(`${this.userApiUrl}/${user.id}`, user);
  }

  deleteUser(id: number) {
    return this.http.delete<void>(`${this.userApiUrl}/${id}`);
  }

  createUser(user: User) {
    return this.http.post<User>(this.userApiUrl, user);
  }
}
