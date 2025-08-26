import { Component, OnInit } from '@angular/core';

interface User {
  id: number;
  username: string;
  role: string;
}

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  users: User[] = [];
  editingUser: User | null = null; // Den bruger vi redigerer

  ngOnInit(): void {
    // midlertidigt dummy data (indtil du kobler til backend / DB)
    this.users = [
      { id: 1, username: 'admin', role: 'Admin' },
      { id: 2, username: 'john_doe', role: 'User' },
      { id: 3, username: 'jane_doe', role: 'User' }
    ];
  }

  editUser(user: User) {
    this.editingUser = { ...user }; // clone så vi ikke overskriver direkte
  }

  saveUser() {
    if (this.editingUser) {
      const index = this.users.findIndex(u => u.id === this.editingUser!.id);
      if (index > -1) {
        this.users[index] = { ...this.editingUser };
      }
      this.editingUser = null;
    }
  }

  deleteUser(id: number) {
    this.users = this.users.filter(u => u.id !== id);
  }

  cancelEdit() {
    this.editingUser = null;
  }
}
