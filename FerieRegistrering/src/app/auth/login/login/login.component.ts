import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  username = '';
  password = '';
  loginError = false;

  constructor(private authService: AuthService, private router: Router) {}

  onLogin() {
    const success = this.authService.login(this.username, this.password);
    if (success) {
      if (this.authService.getRole() === 'admin') {
        this.router.navigate(['/admin']);
      } else {
        this.router.navigate(['/ferie']);
      }
    } else {
      this.loginError = true;
    }
  }
}
