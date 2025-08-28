import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { environment } from '../Environments/environments';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly userApiUrl = environment.apiUrl + '/User';
  
    constructor(private http: HttpClient) { }

  // private users: User[] = [
  //   { id: 1, username: 'admin', role: 'admin' },
  //   { id: 2, username: 'medarbejder', role: 'user' }
  // ];
  // private nextId = 3;

  // getUsers(): User[] {
  //   return this.users;
  // }

  // addUser(username: string, role: 'admin' | 'user'): void {
  //   this.users.push({
  //     id: this.nextId++,
  //     username,
  //     role
  //   });
  // }

  // deleteUser(id: number): void {
  //   this.users = this.users.filter(u => u.id !== id);
  // }

  //API KALD
  getAllUsers() : Observable<User[]> {
    if (!this.http) {
      throw new Error('HttpClient is not initialized.');
    }
    return this. http.get<User[]>(this.userApiUrl);
  }
}
