import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { AdminGuard } from './admin-guard';
import { AuthService } from './auth.service';

describe('AdminGuard', () => {
  let guard: AdminGuard;
  let authServiceMock: jasmine.SpyObj<AuthService>;
  let routerMock: jasmine.SpyObj<Router>;

  beforeEach(() => {
    authServiceMock = jasmine.createSpyObj('AuthService', ['isLoggedIn', 'getRole']);
    routerMock = jasmine.createSpyObj('Router', ['navigate']);

    TestBed.configureTestingModule({
      providers: [
        AdminGuard,
        { provide: AuthService, useValue: authServiceMock },
        { provide: Router, useValue: routerMock }
      ]
    });

    guard = TestBed.inject(AdminGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });

  it('should allow activation if logged in as admin', () => {
    authServiceMock.isLoggedIn.and.returnValue(true);
    authServiceMock.getRole.and.returnValue('admin');

    expect(guard.canActivate()).toBeTrue();
    expect(routerMock.navigate).not.toHaveBeenCalled();
  });

  it('should block activation and redirect if not admin', () => {
    authServiceMock.isLoggedIn.and.returnValue(true);
    authServiceMock.getRole.and.returnValue('medarbejder');

    expect(guard.canActivate()).toBeFalse();
    expect(routerMock.navigate).toHaveBeenCalledWith(['/login']);
  });

  it('should block activation and redirect if not logged in', () => {
    authServiceMock.isLoggedIn.and.returnValue(false);

    expect(guard.canActivate()).toBeFalse();
    expect(routerMock.navigate).toHaveBeenCalledWith(['/login']);
  });
});
