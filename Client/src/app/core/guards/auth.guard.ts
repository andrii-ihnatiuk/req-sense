import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { of, map, tap, catchError } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const router: Router = inject(Router);
  const authService: AuthService = inject(AuthService);

  return authService.isLoggedIn$().pipe(
    tap(result => {
      if (!result) {
        router.navigate(['account/login']);
      }
    }),
    map(isLoggedIn => isLoggedIn),
    catchError(() => of(false))
  );
};
