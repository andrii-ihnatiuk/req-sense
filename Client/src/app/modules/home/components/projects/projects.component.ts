import { Component } from '@angular/core';
import { Project } from 'src/app/core/models/Project';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrl: './projects.component.scss'
})
export class ProjectsComponent {

  projects: Project[] = [
    {
      id: '1',
      title: 'ChatRPG',
      description: 'Integrate AI into games easily.',
      owner: 'Andrii Ihnatiuk',
      membersCount: 11,
    },
  ];

}
