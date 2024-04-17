import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, catchError, of } from "rxjs";
import { AuthService } from "./auth.service";
import { MatSnackBar } from "@angular/material/snack-bar";
import { SnackbarComponent } from "src/app/shared/components/snackbar/snackbar.component";


export const apiErrorTitle = 'An error occured during API call';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {


  constructor(
    private router: Router,
    private authService: AuthService,
    private snackBar: MatSnackBar) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const authReq = req.clone({
      withCredentials: true,
    });

    // send cloned request with header to the next handler.
    return next.handle(authReq)
      .pipe(catchError(err => this.handleError(err)));
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    if (error.status === 0) {
      this.snackBar.openFromComponent(SnackbarComponent, SnackbarComponent.ErrorConfig('API is unavailable'));
    }
    else if (error.status === HttpStatusCode.Unauthorized) {
      this.authService.logout();
      this.router.navigate(['account/login']);
      setTimeout(() => {
        this.snackBar.openFromComponent(SnackbarComponent, SnackbarComponent.InfoConfig('Your login has expired.'));
      }, 200)
    }
    else {
      this.snackBar.openFromComponent(SnackbarComponent, SnackbarComponent.ErrorConfig(`API returned status code ${error.status}`));
    }

    throw new Error(apiErrorTitle);
  }
}