import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from './auth/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private auth: AuthService) {}

  get isLoggedIn(): boolean {
    return this.auth.isLoggedIn;
  }

  logout() {
    if (this.isLoggedIn) {
      this.auth.logout();
    }
  }
}
