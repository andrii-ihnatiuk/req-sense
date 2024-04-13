import { Component, Input } from '@angular/core';
import { Role } from 'src/app/core/constants/role';
import { ProjectMember } from 'src/app/core/models/ProjectMember';

@Component({
  selector: 'app-members-list',
  templateUrl: './members-list.component.html',
  styleUrl: './members-list.component.scss'
})
export class MembersListComponent {

  @Input()
  listItems: ProjectMember[] = [
    {
      id: '',
      name: 'Andrii Ihnatiuk',
      email: 'andrey@gmail.com',
      joinedDate: '2002-11-23',
      role: Role.MEMBER,
    },
  ]

}
