import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-account-expandable',
  templateUrl: './account-expandable.component.html',
  styleUrl: './account-expandable.component.scss'
})
export class AccountExpandableComponent {

  constructor(
    private auth: AuthService,
    private router: Router
  ) {

  }

  signOut(): void {
    this.auth.logout();
    this.router.navigate(['']);
  }
}
