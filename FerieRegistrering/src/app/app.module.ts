import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './auth/login/login/login.component';
import { AuthGuard } from './auth/auth-guard';
import { AdminGuard } from './auth/admin-guard';
import { AdminComponent } from './admin/admin.component';
import { FerieComponent } from './ferie/ferie.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AdminComponent,
    FerieComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'admin', component: AdminComponent, canActivate: [AdminGuard] },
      { path: 'ferie', component: FerieComponent, canActivate: [AuthGuard] }, 
      { path: '', redirectTo: '/login', pathMatch: 'full' },
      { path: '**', redirectTo: '/login' }
    ])
  ],
  providers: [
    AuthGuard,
    AdminGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
