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

  constructor(private router: Router) {}

  login() {
    // Her kan du lave en rigtig auth check senere
    if (this.username === 'admin' && this.password === '1234') {
      // Simpel demo redirect til admin
      this.router.navigate(['/admin']);
    } else {
      alert('Forkert brugernavn eller kodeord');
    }
  }
}
