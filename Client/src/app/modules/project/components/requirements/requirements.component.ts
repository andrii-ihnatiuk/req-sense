import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-requirements',
  templateUrl: './requirements.component.html',
  styleUrl: './requirements.component.scss'
})
export class RequirementsComponent {

  buttonText = 'SELECT';

  options = [
    { value: 'all', label: 'All' },
    { value: 'own', label: 'Own' }
  ];


  onChange(value: string) {
    this.buttonText = value || 'SELECT';
  }
}
