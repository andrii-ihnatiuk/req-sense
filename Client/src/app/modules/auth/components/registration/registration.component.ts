import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl, ValidatorFn, AbstractControlOptions } from '@angular/forms';
import { Router } from '@angular/router';
import { RegistrationRequest } from 'src/app/core/models/DTOs/RegistrationRequest';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss'
})
export class RegistrationComponent {
  form?: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.setupForm();
  }

  private setupForm() {
    this.form = this.fb.group(
      {
        name: ['', [Validators.required, Validators.minLength(3)]],
        email: ['', [Validators.email, Validators.required]],
        password: ['', [Validators.required]],
        confirmPassword: ['', [Validators.required]]
      },
      {
        validators: [this.passwordMatchValidator()]
      } as  AbstractControlOptions
    );
  }

  getControl(name: string): FormControl {
    return this.form?.get(name) as FormControl;
  }

  passwordMatchValidator(): ValidatorFn {
    return () => {
      const control = this.getControl('password')
      const controlTwo = this.getControl('confirmPassword');

      if (!control || !controlTwo
          || !controlTwo.value.length
          || control.value === controlTwo.value) {
        return null;
      }
      controlTwo.setErrors({ passwordMismatch: true });
      return { passwordMismatch: true };
    };
  }

  register(): void {
    if (!this.form?.valid) {
      alert("The form is not valid");
      return;
    }

    const request: RegistrationRequest = {
      email: this.form.controls['email'].value,
      name: this.form.controls['name'].value,
      password: this.form.controls['password'].value,
    };

    this.authService.register(request)
      .subscribe(() => {
        this.router.navigate(['account/login']);
      });
  }
}
