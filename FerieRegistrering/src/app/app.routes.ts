import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login/login.component';
import { AdminComponent } from './admin/admin.component';
import { FerieComponent } from './ferie/ferie.component';
import { HomeComponent } from './homepage/home.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'ferie', component: FerieComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' }
];
