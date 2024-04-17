import { LoginRequest } from "../models/DTOs/LoginRequest";
import { BehaviorSubject, Observable, tap } from "rxjs";
import { User } from "../models/User";
import { BaseService } from "./base.service";
import { HttpClient } from "@angular/common/http";
import { appConfiguration } from "src/app/configuration/configuration-resolver";
import { RegistrationRequest } from "../models/DTOs/RegistrationRequest";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  private _userKey = 'user';
  private userSubject: BehaviorSubject<User | null>;
  public user: Observable<User | null>;

  constructor(http: HttpClient) {
    super(http);
    const savedUser = localStorage.getItem(this._userKey);
    this.userSubject = new BehaviorSubject(savedUser ? JSON.parse(savedUser) : null);
    this.user = this.userSubject.asObservable();
  }

  public get userValue() {
    return this.userSubject.value;
  }

  login(model: LoginRequest): Observable<User> {
    return this.post<LoginRequest, User>(appConfiguration.loginApiUrl, model)
      .pipe(tap(user => {
        localStorage.setItem(this._userKey, JSON.stringify(user));
        this.userSubject.next(user);
      }));
  }

  logout(): void {
    localStorage.removeItem(this._userKey);
    this.userSubject.next(null);
    this.post(appConfiguration.logoutApiUrl, null).subscribe();
  }

  register(model: RegistrationRequest): Observable<any> {
    return this.post(appConfiguration.registrationApiUrl, model);
  }
}
