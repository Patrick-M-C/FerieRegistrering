import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth/auth.service';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  user: User | null = null; 
  editModel: User | null = null;
  editing = false;
  loading = false;
  saving = false;
  error: string | null = null;

  constructor(
    private auth: AuthService,
    private users: UserService,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}

  ngOnInit() {
    if (!isPlatformBrowser(this.platformId)) return;

    const id = this.auth.getUserId();
    if (!id) return;

    this.loading = true;
    this.users.getById(id).subscribe({
      next: u => {
        this.user = u;
        this.loading = false;
      },
      error: e => {
        this.error = 'Kunne ikke hente bruger';
        this.loading = false;
        console.error(e);
      }
    });
  }

  toggleEdit() {
    if (!this.user) return;
    this.editing = !this.editing;
    this.editModel = this.editing ? { ...this.user } : null;
  }

  save() {
    if (!this.user || !this.editModel) return;

    this.saving = true;
    this.users.updateUser({
      id: this.user.id,
      name: this.editModel.name,
      lastName: this.editModel.lastName,
      email: this.editModel.email,
      dateOfBirth: this.editModel.dateOfBirth
    }).subscribe({
      next: updated => {
        this.user = updated;
        this.editing = false;
        this.editModel = null;
        this.saving = false;
      },
      error: e => {
        this.error = 'Kunne ikke gemme ændringer';
        this.saving = false;
        console.error(e);
      }
    });
  }
}
