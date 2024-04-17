import { Component, OnInit } from '@angular/core';
import { ActivityItem } from 'src/app/core/models/ActivityItem';
import { Project } from 'src/app/core/models/Project';
import { AuthService } from 'src/app/core/services/auth.service';
import { ProjectService } from 'src/app/core/services/project.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit {

  projects: Project[] = [];

  constructor(
    private authService: AuthService,
    private projectService: ProjectService
  ) {
  }

  ngOnInit(): void {
    const user = this.authService.userValue;
    if (!user) {
      return;
    }

    this.projectService.getProjectsByUser(user.id, "own")
      .subscribe(projects => {
        this.projects = projects;
      })
  }

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
