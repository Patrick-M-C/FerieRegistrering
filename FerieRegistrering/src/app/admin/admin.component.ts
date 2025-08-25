import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  users: User[] = [];
  newUsername = '';
  newRole: 'admin' | 'user' = 'user';

  constructor(private userService: UserService) {
    this.users = this.userService.getUsers();
  }

  addUser() {
    if (this.newUsername.trim()) {
      this.userService.addUser(this.newUsername, this.newRole);
      this.newUsername = '';
      this.newRole = 'user';
      this.users = this.userService.getUsers(); // opdater liste
    }
  }

  deleteUser(id: number) {
    this.userService.deleteUser(id);
    this.users = this.userService.getUsers();
  }
}
