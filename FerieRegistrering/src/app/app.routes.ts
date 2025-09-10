import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login/login.component';
import { AdminComponent } from './admin/admin.component';
import { FerieComponent } from './ferie/ferie.component';
import { HomeComponent } from './homepage/home.component';
import { ProfileComponent } from './profile/profile.component';
import { AdminDasboardComponent } from './admin-dasboard-component/admin-dasboard-component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'ferie', component: FerieComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'dashboard', component: AdminDasboardComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' }
];
