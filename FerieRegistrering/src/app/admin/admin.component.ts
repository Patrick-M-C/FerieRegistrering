import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { resetUser, User } from '../models/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-admin',
  standalone: true,
  templateUrl: './admin.component.html',
  imports: [CommonModule, FormsModule ],
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  users: User[] = [];
  editingUser: User | null = null;
  user: User = resetUser();
  creating = false;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  editUser(user: User) {
    this.editingUser = { ...user }; // laver en kopi så vi ikke ændrer live-data
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

  startCreate() {
    this.user = resetUser();
    this.creating = true;
  }

  // 🔹 Gem ny bruger
  createUser() {
    this.userService.createUser(this.user).subscribe({
      next: (newUser) => {
        this.users.push(newUser);
        this.creating = false;
        this.user = resetUser();
      },
      error: (error) => console.error('Error creating user:', error)
    });
  }

  // 🔹 Luk create-form
  cancelCreate() {
    this.creating = false;
    this.user = resetUser();
  }

  openEdit(user: User) {
    this.editingUser = { ...user }; // Kopi af brugerdata
  }

  saveUser() {
    if (!this.editingUser) return;

    this.userService.updateUser(this.editingUser).subscribe({
      next: () => {
        this.loadUsers();
        this.editingUser = null;
      },
      error: (error) => console.error('Error Kan ikke opdatere user:', error)
    });
  }

  deleteUser(id: number) {
    if (!confirm('Er du sikker på at du vil slette denne bruger?')) return;

    this.userService.deleteUser(id).subscribe({
      next: () => this.loadUsers(),
      error: (error) => console.error('Error Kan ikke slette brugere', error)
    });
  }

  closeEdit() {
    this.editingUser = null;
  }
}
