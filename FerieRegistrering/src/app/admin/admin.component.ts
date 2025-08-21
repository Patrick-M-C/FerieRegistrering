import { Component } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  users = [
    { id: 1, name: 'Peter', email: 'peter@example.com' },
    { id: 2, name: 'Sara', email: 'sara@example.com' },
    { id: 3, name: 'Lars', email: 'lars@example.com' }
  ];

  deleteUser(id: number) {
    this.users = this.users.filter(user => user.id !== id);
  }
}
