import { Component } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  user: any = null;
  editing = false;

  constructor(private authService: AuthService) {}

  // ngOnInit() {
  //   this.user = this.authService.getUser();
  // }

  // toggleEdit() {
  //   this.editing = !this.editing;
  // }

  // save() {
  //   this.authService.updateUser(this.user);
  //   this.editing = false;
  // }
}
