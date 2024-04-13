import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { HeaderComponent } from './components/header/header.component';
import { SidebarItemComponent } from './components/sidebar-item/sidebar-item.component';
import { RouterModule } from '@angular/router';
import { CardComponent } from './components/card/card.component';
import { InputComponent } from './components/input/input.component';
import { MatRippleModule } from '@angular/material/core';
import { MembersListComponent } from '../modules/project/components/members-list/members-list.component';
import { MembersListItemComponent } from '../modules/project/components/members-list-item/members-list-item.component';


@NgModule({
  declarations: [
    SidebarComponent,
    HeaderComponent,
    SidebarItemComponent,
    CardComponent,
    InputComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    FormsModule,
    MatButtonModule,
    MatRippleModule
  ],
  exports: [
    RouterModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    FormsModule,
    MatButtonModule,
    SidebarComponent,
    HeaderComponent,
    SidebarItemComponent,
    CardComponent,
    MatRippleModule,
  ]
})
export class SharedModule { }
