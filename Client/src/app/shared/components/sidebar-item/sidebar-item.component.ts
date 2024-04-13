import { Component, Input } from '@angular/core';
import { MenuItem } from 'src/app/core/models/MenuItem';

@Component({
  selector: 'app-sidebar-item',
  templateUrl: './sidebar-item.component.html',
  styleUrl: './sidebar-item.component.scss'
})
export class SidebarItemComponent {

  @Input()
  item?: MenuItem;
}
