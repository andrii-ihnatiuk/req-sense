import { Component, Input } from '@angular/core';
import { ProjectMember } from 'src/app/core/models/ProjectMember';

@Component({
  selector: 'app-members-list-item',
  templateUrl: './members-list-item.component.html',
  styleUrl: './members-list-item.component.scss'
})
export class MembersListItemComponent {

  @Input()
  model?: ProjectMember;

}
