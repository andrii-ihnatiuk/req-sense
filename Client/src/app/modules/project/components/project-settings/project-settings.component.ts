import {
  Component,
  ElementRef,
  OnInit,
  TemplateRef,
  ViewChild,
} from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRoute, Router } from "@angular/router";
import { Project } from "src/app/core/models/Project";
import { ProjectService } from "src/app/core/services/project.service";
import { ConfirmationDialog } from "src/app/shared/components/confirmation-dialog/confirmation-dialog.component";

@Component({
  selector: "app-project-settings",
  templateUrl: "./project-settings.component.html",
  styleUrl: "./project-settings.component.scss",
})
export class ProjectSettingsComponent implements OnInit {
  form?: FormGroup;
  project?: Project;

  constructor(
    private projectService: ProjectService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    const projectId = this.route.parent?.snapshot.params["projectId"];
    this.projectService.getProjectById(projectId).subscribe((project) => {
      this.project = project;
      this.buildForm();
    });
  }

  buildForm(): void {
    this.form = this.fb.group({
      title: [this.project?.title, Validators.required],
      description: [this.project?.description, Validators.maxLength(200)],
    });
  }

  getControl(name: string): FormControl {
    return this.form?.controls[name] as FormControl;
  }

  updateProject(): void {
    if (!this.form?.valid) {
      alert("The form is invalid");
      return;
    }

    const projectVal: Project = {
      id: this.project?.id,
      title: this.getControl("title").value,
      description: this.getControl("description").value,
    };

    this.projectService.updateProject(projectVal).subscribe((_) => {
      this.router.navigate(["/projects", this.project?.id]);
    });
  }

  deleteProject(): void {
    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        title: "Delete project",
        message: `Are you sure you want to delete "${this.project?.title}"?`,
      },
    });
    dialogRef.afterClosed().subscribe((userApproved) => {
      if (userApproved) {
        this.projectService.deleteProject(this.project?.id!).subscribe((_) => {
          this.router.navigate(["/projects"]);
        });
      }
    });
  }
}
