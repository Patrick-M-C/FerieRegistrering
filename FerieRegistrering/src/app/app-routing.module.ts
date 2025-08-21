import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login/login.component';
import { AdminGuard } from './auth/admin-guard';
import { AuthGuard } from './auth/auth-guard';
import { AdminComponent } from './admin/admin.component';
import { FerieComponent } from './ferie/ferie.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'ferie', component: FerieComponent, canActivate: [AuthGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [AdminGuard] },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
