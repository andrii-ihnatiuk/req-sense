import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, catchError } from "rxjs";
import { AuthService } from "./auth.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private router: Router, private authService: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const authReq = req.clone({
      withCredentials: true,
    });

    // send cloned request with header to the next handler.
    return next.handle(authReq)
      .pipe(catchError(err => this.handleError(err)));
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    if (error.status === HttpStatusCode.Unauthorized) {
      this.router.navigate(['account/login']);
    }

    throw new Error("An error occured during API call");
  }
}