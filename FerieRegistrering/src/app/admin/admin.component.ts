import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { resetUser, User } from '../models/user';
import { UserService } from '../services/user.service';

// interface User {
//   id: number;
//   username: string;
//   role: string;
// }

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  imports: [CommonModule, FormsModule ],
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  users: User[] = [];
  user: User = resetUser();

  constructor(private userService: UserService) {}

  // users: User[] = [];
  // editingUser: User | null = null; // Den bruger vi redigerer

  ngOnInit(): void {
    // midlertidigt dummy data (indtil du kobler til backend / DB)
    // this.users = [
    //   { id: 1, username: 'admin', role: 'Admin' },
    //   { id: 2, username: 'john_doe', role: 'User' },
    //   { id: 3, username: 'jane_doe', role: 'User' }
    // ];
    this.loadUsers();
  }

  // editUser(user: User) {
  //    this.editingUser = { ...user }; // clone så vi ikke overskriver direkte
  // }

  saveUser() {
    // if (this.editingUser) {
    //   const index = this.users.findIndex(u => u.id === this.editingUser!.id);
    //   if (index > -1) {
    //     this.users[index] = { ...this.editingUser };
    //   }
    //   this.editingUser = null;
    // }
  }

  deleteUser(id: number) {
    // this.users = this.users.filter(u => u.id !== id);
  }

  cancelEdit() {
    // this.editingUser = null;
  }

  loadUsers() {
    this.userService.getAllUsers().subscribe({
      next: (data) => {
        this.users = data;
      },
      error: (error) => {
        console.error('Error fetching users:', error);
      }
    })
  }
}
