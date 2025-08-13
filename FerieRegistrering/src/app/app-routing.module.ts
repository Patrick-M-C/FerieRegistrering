import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { AuthGuard } from './auth/admin-guard';
import { AdminGuard } from './auth/admin-guard';

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
