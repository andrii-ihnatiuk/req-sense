import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/core/models/User';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-account-expandable',
  templateUrl: './account-expandable.component.html',
  styleUrl: './account-expandable.component.scss'
})
export class AccountExpandableComponent {
  user: User | null;

  constructor(
    public auth: AuthService,
    private router: Router
  ) {
    this.user = auth.userValue;
  }

  signOut(): void {
    this.auth.logout();
    this.router.navigate(['/account/login']);
  }
}
