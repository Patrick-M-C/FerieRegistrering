import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../auth.service';
import { LoginRequest  } from '../../../models/login';
import { userInfo } from 'os';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  email: string = ''; 
  password: string = '';

  constructor(
    private router: Router,
    private authService: AuthService 
  ) {}

  login() {
    const request: LoginRequest = {
      email: this.email,
      password: this.password,
    };

    this.authService.login(request).subscribe({
      next: (response) => {
        console.log(response);
        if (response.role === 'Leader') {
          this.router.navigate(['/admin']);
        } else {
          this.router.navigate(['/profile']);
        }
      },
      error: (err) => {
        alert('Forkert login: ' + 'Prøv igen');
      },
    });
  }
}
