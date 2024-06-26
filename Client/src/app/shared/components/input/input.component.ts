import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrl: './input.component.scss'
})
export class InputComponent {

  @Input()
  placeholder: string = '';

  @Input()
  value: string = '';

  @Input()
  icon?: string;

  @Input()
  type: 'text' | 'number' = 'text';
}
