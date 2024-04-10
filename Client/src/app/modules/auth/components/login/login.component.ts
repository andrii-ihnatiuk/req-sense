import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {

  form?: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
  ) {
  }

  ngOnInit(): void {
    this.setupForm();
  }

  value: string = "hello";

  private setupForm() {
    this.form = this.fb.group({
      email: ['', [Validators.email, Validators.required]],
      password: ['', Validators.required]
    });
  }

  getControl(name: string): FormControl {
    return this.form?.get(name) as FormControl;
  }

  login(): void {
    if (!this.form?.valid) {
      alert('The form is not valid');
      return;
    }

    const loginRequest = {
      email: this.form?.controls['email'].value,
      password: this.form?.controls['password'].value
    };

    this.authService.login(loginRequest)
      .subscribe(u => this.router.navigate(['/']));
  }
}
