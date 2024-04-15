import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrl: './card.component.scss'
})
export class CardComponent {

  @Input()
  padding: number = 15;

  @Input()
  borderRadius: number = 5;

  getCardStyle(): Object {
    return {
      padding: this.padding + 'px',
      borderRadius: this.borderRadius + 'px',
    };
  }

}
