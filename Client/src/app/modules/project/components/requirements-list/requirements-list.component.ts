import { Component, Input } from '@angular/core';
import { RequirementListItem } from '../requirements-list-item/RequirementListItem';

@Component({
  selector: 'app-requirements-list',
  templateUrl: './requirements-list.component.html',
  styleUrl: './requirements-list.component.scss'
})
export class RequirementsListComponent {

  @Input()
  listItems?: RequirementListItem[];
}
