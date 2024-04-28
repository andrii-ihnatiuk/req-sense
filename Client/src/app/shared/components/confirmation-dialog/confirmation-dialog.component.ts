import { Component, Inject } from "@angular/core";
import { MatButtonModule } from "@angular/material/button";
import { MAT_DIALOG_DATA, MatDialogModule } from "@angular/material/dialog";

export type ConfirmationDialogData = {
  title: string;
  message: string;
};

@Component({
  selector: "app-confirmation-dialog",
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
  templateUrl: "./confirmation-dialog.component.html",
  styleUrl: "./confirmation-dialog.component.scss",
})
export class ConfirmationDialog {
  constructor(@Inject(MAT_DIALOG_DATA) public data: ConfirmationDialogData) {
    if (!data) {
      throw new Error("No data provided for the dialog");
    }
  }
}
