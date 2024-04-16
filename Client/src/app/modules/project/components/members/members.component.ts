import { Component } from '@angular/core';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrl: './members.component.scss'
})
export class MembersComponent {

  options = [
    { value: 'all', label: 'All' },
    { value: 'own', label: 'Own' }
  ];
}
