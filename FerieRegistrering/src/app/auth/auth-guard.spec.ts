import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { AuthGuard } from './auth-guard';
import { AuthService } from './auth.service';

describe('AuthGuard', () => {
  let guard: AuthGuard;
  let authServiceMock: jasmine.SpyObj<AuthService>;
  let routerMock: jasmine.SpyObj<Router>;

  beforeEach(() => {
    authServiceMock = jasmine.createSpyObj('AuthService', ['isLoggedIn']);
    routerMock = jasmine.createSpyObj('Router', ['navigate']);

    TestBed.configureTestingModule({
      providers: [
        AuthGuard,
        { provide: AuthService, useValue: authServiceMock },
        { provide: Router, useValue: routerMock }
      ]
    });

    guard = TestBed.inject(AuthGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });

  it('should allow activation if logged in', () => {
    authServiceMock.isLoggedIn.and.returnValue(true);

    expect(guard.canActivate()).toBeTrue();
    expect(routerMock.navigate).not.toHaveBeenCalled();
  });

  it('should block activation and redirect to login if not logged in', () => {
    authServiceMock.isLoggedIn.and.returnValue(false);

    expect(guard.canActivate()).toBeFalse();
    expect(routerMock.navigate).toHaveBeenCalledWith(['/login']);
  });
});
