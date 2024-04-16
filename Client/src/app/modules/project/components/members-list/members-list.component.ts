import { Component, Input } from '@angular/core';
import { Role } from 'src/app/core/constants/role';
import { MemberListItem } from '../members-list-item/MemberListItem';

@Component({
  selector: 'app-members-list',
  templateUrl: './members-list.component.html',
  styleUrl: './members-list.component.scss'
})
export class MembersListComponent {

  @Input()
  listItems: MemberListItem[] = [
    {
      id: '',
      name: 'Andrii Ihnatiuk',
      email: 'andrey@gmail.com',
      joinedDate: '2002-11-23',
      role: Role.MEMBER,
    },
    {
      id: '',
      name: 'Andrii Ihnatiuk',
      email: 'andrey@gmail.com',
      joinedDate: '2002-11-23',
      role: Role.MEMBER,
    },
  ]

  @Input()
  withActions: boolean = false;

  @Input()
  withCardStyle: boolean = false;

}
