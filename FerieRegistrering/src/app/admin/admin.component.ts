import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  users: any[] = [];
  newUsername = '';
  newRole = 'user';

  addUser() {
    this.users.push({ username: this.newUsername, role: this.newRole });
    this.newUsername = '';
    this.newRole = 'user';
  }
}
