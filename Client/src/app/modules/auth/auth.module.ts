import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './components/login/login.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { RegistrationComponent } from './components/registration/registration.component';
import { CoreModule } from 'src/app/core/core.module';


@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    AuthRoutingModule,
    SharedModule,
  ],
})
export class AuthModule { }
