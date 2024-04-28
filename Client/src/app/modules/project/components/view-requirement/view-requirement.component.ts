import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRoute, Router } from "@angular/router";
import { Requirement } from "src/app/core/models/Requirement";
import { RequirementService } from "src/app/core/services/requirement.service";
import { ConfirmationDialog } from "src/app/shared/components/confirmation-dialog/confirmation-dialog.component";

@Component({
  selector: "app-view-requirement",
  templateUrl: "./view-requirement.component.html",
  styleUrl: "./view-requirement.component.scss",
})
export class ViewRequirementComponent implements OnInit {
  requirementId: string;
  requirement?: Requirement;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private requirementService: RequirementService,
    private matDialog: MatDialog
  ) {
    this.requirementId = this.route.snapshot.params["requirementId"];
  }

  ngOnInit(): void {
    if (!this.requirementId) {
      throw new Error("Requirement id was not provided in the route");
    }

    this.requirementService
      .getRequirementById(this.requirementId)
      .subscribe((requirement) => {
        this.requirement = requirement;
        console.log(this.requirement);
      });
  }

  onDeleteRequirement(): void {
    const dialogRef = this.matDialog.open(ConfirmationDialog, {
      data: {
        title: "Delete requirement",
        message: "Are you sure you want to delete this requirement?",
      },
    });

    dialogRef.afterClosed().subscribe((userConfirmed) => {
      if (userConfirmed) {
        this.sendDeleteRequest();
      }
    });
  }

  private sendDeleteRequest(): void {
    this.requirementService
      .deleteRequirement(this.requirementId)
      .subscribe((res) => {
        this.router.navigate(["requirements"], {
          relativeTo: this.route.parent,
        });
      });
  }
}
