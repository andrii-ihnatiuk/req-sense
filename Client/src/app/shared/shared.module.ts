import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AccountExpandableComponent } from './components/account-expandable/account-expandable.component';
import { SnackbarComponent } from './components/snackbar/snackbar.component';


@NgModule({
  declarations: [
    SidebarComponent,
    HeaderComponent,
    SidebarItemComponent,
    CardComponent,
    InputComponent,
    SelectComponent,
    AccountExpandableComponent,
    SnackbarComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,
    MatRippleModule,
    MatSelectModule,
    MatExpansionModule,
    MatDialogModule,
  ],
  exports: [
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,
    SidebarComponent,
    HeaderComponent,
    SidebarItemComponent,
    CardComponent,
    MatRippleModule,
    InputComponent,
    MatSelectModule,
    SelectComponent,
    AccountExpandableComponent,
    MatDialogModule,
    MatSnackBarModule,
  ]
})
export class SharedModule { }
