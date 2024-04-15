import { Component, Input, ViewChild } from '@angular/core';
import { MatSelect } from '@angular/material/select';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrl: './select.component.scss'
})
export class SelectComponent {

  @ViewChild('control')
  control?: MatSelect;

  @Input()
  value: any;

  @Input()
  options: { value: any, label: string }[] = []

  openSelect(): void {
    this.control?.open();
  }
}
