import { Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private users: User[] = [
    { id: 1, username: 'admin', role: 'admin' },
    { id: 2, username: 'medarbejder', role: 'user' }
  ];
  private nextId = 3;

  getUsers(): User[] {
    return this.users;
  }

  addUser(username: string, role: 'admin' | 'user'): void {
    this.users.push({
      id: this.nextId++,
      username,
      role
    });
  }

  deleteUser(id: number): void {
    this.users = this.users.filter(u => u.id !== id);
  }
}
