import { Component, Input } from '@angular/core';
import { MemberListItem } from './MemberListItem';

@Component({
  selector: 'app-members-list-item',
  templateUrl: './members-list-item.component.html',
  styleUrl: './members-list-item.component.scss'
})
export class MembersListItemComponent {

  @Input()
  cardStyle: boolean = true;

  @Input()
  showActions: boolean = true;

  @Input()
  model?: MemberListItem;

}
