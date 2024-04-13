import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';


export const authGuard: CanActivateFn = (route, state) => {
  const router: Router = inject(Router);
  const authService: AuthService = inject(AuthService);


  const user = authService.userValue;

  if (user) {
    const { roles } = route.data;
    if (roles && !roles.includes(user.role.toUpperCase())) {
      router.navigate(['/']);
      return false;
    }

    return true;
  }

  router.navigate(['account/login']);
  return false;
};
