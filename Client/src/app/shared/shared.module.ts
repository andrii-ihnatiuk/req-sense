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
import { MatSelectModule } from '@angular/material/select';
import { SelectComponent } from './components/select/select.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { AccountExpandableComponent } from './components/account-expandable/account-expandable.component';


@NgModule({
  declarations: [
    SidebarComponent,
    HeaderComponent,
    SidebarItemComponent,
    CardComponent,
    InputComponent,
    SelectComponent,
    AccountExpandableComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    FormsModule,
    MatButtonModule,
    MatRippleModule,
    MatSelectModule,
    MatExpansionModule,
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
    InputComponent,
    MatSelectModule,
    SelectComponent,
    AccountExpandableComponent
  ]
})
export class SharedModule { }
