import { Component } from '@angular/core';
import { RequirementListItem } from '../requirements-list-item/RequirementListItem';

@Component({
  selector: 'app-requirements-list',
  templateUrl: './requirements-list.component.html',
  styleUrl: './requirements-list.component.scss'
})
export class RequirementsListComponent {

  listItems: RequirementListItem[] = [
    {
      title: 'Comments feature',
      owner: 'Emily Blunt',
      createdDate: '12.04.2024'
    },
    {
      title: 'Comments feature',
      owner: 'Emily Blunt',
      createdDate: '12.04.2024'
    }
  ]
}
