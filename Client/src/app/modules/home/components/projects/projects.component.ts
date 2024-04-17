import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Project } from 'src/app/core/models/Project';
import { CreateProjectDialogComponent } from '../create-project-dialog/create-project-dialog.component';
import { ProjectService } from 'src/app/core/services/project.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrl: './projects.component.scss'
})
export class ProjectsComponent implements OnInit {

  ownProjects: Project[] = [];

  memberProjects: Project[] = [];

  constructor(
    private dialog: MatDialog,
    private projectService: ProjectService,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadUserProjects();
  }

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

  loadUserProjects(): void {
    const userId = this.authService.userValue?.id;
    if (!userId) {
      alert('not auth');
      return;
    }

    this.projectService.getProjectsByUser(userId, "own")
      .subscribe(projects => {
        this.ownProjects = projects;
      });

    this.projectService.getProjectsByUser(userId, "member")
      .subscribe(projects => {
        this.memberProjects = projects;
      })
  }
}
