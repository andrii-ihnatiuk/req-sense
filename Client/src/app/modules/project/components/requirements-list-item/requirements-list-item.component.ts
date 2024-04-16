import { Component, Input } from '@angular/core';
import { RequirementListItem } from './RequirementListItem';

@Component({
  selector: 'app-requirements-list-item',
  templateUrl: './requirements-list-item.component.html',
  styleUrl: './requirements-list-item.component.scss'
})
export class RequirementsListItemComponent {

  @Input()
  cardStyle: boolean = true;

  @Input()
  model?: RequirementListItem;

}
