import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  authService: any;

  constructor(private router: Router) {}

  login() {
    const success = this.authService.login(this.username, this.password);
    if (success) {
      const role = this.authService.getRole();
      if (role === 'admin') {
        this.router.navigate(['/admin']);
      } else {
        this.router.navigate(['/profile']);
      }
    } else {
      alert('Forkert brugernavn eller adgangskode');
    }
  }
}
