import { Component } from '@angular/core';
import { ActivityItem } from 'src/app/core/models/ActivityItem';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {

  cards: ActivityItem[] = [
    {
      title: 'ReqSense',
      icon: 'domain',
      subtitle: 'Visited 25 min. ago',
      link: '/projects'
    },
    {
      title: 'Stakehold.io',
      icon: 'domain',
      subtitle: 'Visited 30 min. ago',
      link: '/projects'
    }
  ];

}
