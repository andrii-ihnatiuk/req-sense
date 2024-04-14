import { Component } from '@angular/core';
import { MenuItem } from 'src/app/core/models/MenuItem';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  sideBarMenuItems: MenuItem[] = [
    {
      title: 'Dashboard',
      icon: 'dashboard',
      link: '/dashboard'
    },
    {
      title: 'Projects',
      icon: 'stacks',
      link: '/projects'
    },
    {
      title: 'Subscriptions',
      icon: 'new_releases',
      link: '/subscriptions'
    },
    {
      title: 'Notifications',
      icon: 'notifications',
      link: '/notifications'
    }
  ];
}
