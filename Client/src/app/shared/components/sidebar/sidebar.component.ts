import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'src/app/core/models/MenuItem';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss'
})
export class SidebarComponent {

  @Input()
  menuItems: MenuItem[] = []

  constructor(private router: Router) {
  }

  navigateHome(): void {
    this.router.navigate(['']);
  }
}
