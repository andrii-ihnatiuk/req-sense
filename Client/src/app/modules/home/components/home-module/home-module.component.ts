import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MenuItem } from 'src/app/core/models/MenuItem';
import { ProjectService } from 'src/app/core/services/project.service';
import { CreateProjectDialogComponent } from '../create-project-dialog/create-project-dialog.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home-module.component.html',
  styleUrl: './home-module.component.scss'
})
export class HomeModuleComponent {

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

  constructor(
    private dialog: MatDialog,
    private router: Router
  ) { }


  openNewProjectDialog(): void {
    const dialogRef = this.dialog.open(
      CreateProjectDialogComponent,
      {
        autoFocus: false,
      },
    );

    dialogRef.afterClosed().subscribe(createdId => {
      if (!!createdId) {
        this.router.navigate([`projects/${createdId}`]);
      }
    });
  }
}
