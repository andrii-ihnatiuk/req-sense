import { Component, Inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA, MatSnackBarConfig, MatSnackBarRef } from '@angular/material/snack-bar';

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

  static ErrorConfig(message: string, duration?: number): MatSnackBarConfig {
    return {
      verticalPosition: 'top',
      data: { message: message, type: 'error' },
      duration: duration
    }
  }

  static WarnConfig(message: string, duration?: number): MatSnackBarConfig {
    return {
      verticalPosition: 'top',
      data: { message: message, type: 'warn' },
      duration: duration
    }
  }

  static InfoConfig(message: string, duration?: number): MatSnackBarConfig {
    return {
      verticalPosition: 'top',
      data: { message: message, type: 'info' },
      duration: duration
    }
  }
}
