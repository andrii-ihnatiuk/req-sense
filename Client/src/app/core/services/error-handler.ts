import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler, Inject, Injectable, Injector } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { SnackbarComponent } from "src/app/shared/components/snackbar/snackbar.component";
import { apiErrorTitle } from "./auth.interceptor";

@Injectable()
export class GlobalErrorHandlerService extends ErrorHandler {
  constructor(@Inject(Injector) private injector: Injector) {
    super();
  }

  private get snackBar(): MatSnackBar {
    return this.injector.get(MatSnackBar);
  }

  override handleError(error: Error | HttpErrorResponse): void {
    if (error.message === apiErrorTitle) {
      return;
    }

    this.snackBar.openFromComponent(SnackbarComponent, SnackbarComponent.ErrorConfig(error.message));

    super.handleError(error);
  }
}