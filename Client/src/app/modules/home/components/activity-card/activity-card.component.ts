import { Component, Input } from '@angular/core';
import { ActivityItem } from 'src/app/core/models/ActivityItem';

@Component({
  selector: 'app-activity-card',
  templateUrl: './activity-card.component.html',
  styleUrl: './activity-card.component.scss'
})
export class ActivityCardComponent {

  @Input()
  model?: ActivityItem;

}
