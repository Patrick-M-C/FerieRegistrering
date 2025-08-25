import { Component } from '@angular/core';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService) {}

  login() {
    const success = this.authService.login(this.username, this.password);
    if (!success) {
      this.errorMessage = 'Forkert brugernavn eller adgangskode';
    }
  }
}
