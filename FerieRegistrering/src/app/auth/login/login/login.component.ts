import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../auth.service';
import { LoginRequest  } from '../../../models/login';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  email: string = ''; // backend forventer email, ikke username
  password: string = '';

  constructor(
    private router: Router,
    private authService: AuthService // <-- rigtig injection
  ) {}

  login() {
    const request: LoginRequest = {
      email: this.email,
      password: this.password,
    };

    this.authService.login(request).subscribe({
      next: (response) => {
        console.log(response);
        // her har du response med token, role, osv.
        if (response.role === 'Leader') {
          this.router.navigate(['/admin']);
        } else {
          this.router.navigate(['/profile']);
        }
      },
      error: (err) => {
        alert('Forkert login: ' + (err.error || 'Prøv igen'));
      },
    });
  }
}
