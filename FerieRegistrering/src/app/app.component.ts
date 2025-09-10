import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from './auth/auth.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private router: Router, public auth: AuthService) {}

  get isLoggedIn(): boolean {
    return this.auth.isLoggedIn();
  }

  get isLeader(): boolean {
    return this.auth.isLeader();
  }

  get isEmployee(): boolean {
    return this.auth.isEmployee();
  }

  logout() {
    this.auth.logout();
    this.router.navigate(['/home']);
  }
}
