import { Component, Inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA, MatSnackBarRef } from '@angular/material/snack-bar';

@Component({
  selector: 'app-snackbar',
  templateUrl: './snackbar.component.html',
  styleUrl: './snackbar.component.scss'
})
export class SnackbarComponent {

  constructor(
    @Inject(MAT_SNACK_BAR_DATA) public data: { message: string, type: 'error' | 'warn' | 'info' | null },
    public snackBarRef: MatSnackBarRef<SnackbarComponent>) {

  }

  getIconClass(): string {
    return this.data.type ?? 'info';
  }

  static ErrorConfig(message: string): Object {
    return {
      verticalPosition: 'top',
      data: { message: message, type: 'error' }
    }
  }

  static WarnConfig(message: string): Object {
    return {
      verticalPosition: 'top',
      data: { message: message, type: 'warn' }
    }
  }

  static InfoConfig(message: string): Object {
    return {
      verticalPosition: 'top',
      data: { message: message, type: 'info' }
    }
  }
}
