import { Component, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRoute, Router } from "@angular/router";
import { UpdateRequirementRequest } from "src/app/core/models/DTOs/UpdateRequirementRequest";
import { Requirement } from "src/app/core/models/Requirement";
import { RequirementService } from "src/app/core/services/requirement.service";
import { ConfirmationDialog } from "src/app/shared/components/confirmation-dialog/confirmation-dialog.component";

@Component({
  selector: "app-update-requirement",
  templateUrl: "./update-requirement.component.html",
  styleUrl: "./update-requirement.component.scss",
})
export class UpdateRequirementComponent implements OnInit {
  requirementId: string;
  requirement?: Requirement;

  form?: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private requirementService: RequirementService,
    private matDialog: MatDialog,
    private fb: FormBuilder
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
        this.buildForm(requirement);
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

  onUpdateRequirement(): void {
    alert("updating");
    if (this.form?.invalid) {
      alert("The form is invalid");
    }

    const updateDto: UpdateRequirementRequest = {
      id: this.requirement?.id!,
      title: this.getControl("title").value,
      description: this.getControl("description").value,
    };

    this.requirementService.updateRequirement(updateDto).subscribe((res) => {
      this.router.navigate(["../../"], { relativeTo: this.route });
    });
  }

  getControl(name: string): FormControl {
    return this.form?.controls[name] as FormControl;
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

  private buildForm(model: Requirement): void {
    this.form = this.fb.group({
      title: [model.title, Validators.required],
      description: [model.description, Validators.required],
    });
  }
}
