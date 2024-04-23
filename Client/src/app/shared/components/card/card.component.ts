import { Component, Input, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrl: './card.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class CardComponent {

  @Input()
  padding: number = 15;

  @Input()
  borderRadius: number = 5;

  @Input()
  raised: boolean = false;

  @Input()
  hoverable: boolean = false;

  getCardStyle(): Object {
    return {
      padding: this.padding + 'px',
      borderRadius: this.borderRadius + 'px',
    };
  }

  getCardClasses(): Object {
    return {
      hoverable: this.hoverable,
      raised: this.raised
    }
  }
}
