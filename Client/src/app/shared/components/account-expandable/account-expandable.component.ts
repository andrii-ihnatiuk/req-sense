import { Component } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-account-expandable',
  templateUrl: './account-expandable.component.html',
  styleUrl: './account-expandable.component.scss'
})
export class AccountExpandableComponent {

  constructor(private auth: AuthService) {

  }

  signOut(): void {
    this.auth.logout();
  }
}
