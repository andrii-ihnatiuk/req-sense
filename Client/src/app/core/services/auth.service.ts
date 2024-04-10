import { LoginRequest } from "../models/LoginRequest";
import { Observable, catchError, map, of, tap } from "rxjs";
import { User } from "../models/User";
import { BaseService } from "./base.service";
import { HttpClient } from "@angular/common/http";
import { appConfiguration } from "src/app/configuration/configuration-resolver";
import { RegistrationRequest } from "../models/RegistrationRequest";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  private loggedUser: User | null = null

  constructor(http: HttpClient) {
    super(http);
  }

  login(model: LoginRequest): Observable<User> {
    return this.post<LoginRequest, User>(
      appConfiguration.loginApiUrl,
      model,
    ).pipe(tap(u => this.loggedUser = u));
  }

  isLoggedIn$(): Observable<boolean> {
    return this.getCurrentUser$().pipe(
      map(user => !!user),
      catchError(() => of(false)),
    );
  }

  getCurrentUser$(): Observable<User> {
    if (!!this.loggedUser) {
      return of(this.loggedUser);
    }

    return this.get<User>(appConfiguration.userInfoApiUrl)
      .pipe(tap(user => this.loggedUser = user));
  }

  register(model: RegistrationRequest): Observable<any> {
    return this.post(appConfiguration.registrationApiUrl, model);
  }
}
