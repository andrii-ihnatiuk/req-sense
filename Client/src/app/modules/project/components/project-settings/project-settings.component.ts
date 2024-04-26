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

@Component({
  selector: "app-project-settings",
  templateUrl: "./project-settings.component.html",
  styleUrl: "./project-settings.component.scss",
})
export class ProjectSettingsComponent implements OnInit {
  form?: FormGroup;
  project?: Project;

  @ViewChild("deleteProjectTemplate", { static: true })
  deleteProjectTemplate?: TemplateRef<void>;

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
    if (!this.deleteProjectTemplate) {
      throw new Error("Dialog template is not present");
    }

    const dialogRef = this.dialog.open(this.deleteProjectTemplate!);
    dialogRef.afterClosed().subscribe((userApproved) => {
      if (userApproved) {
        this.projectService.deleteProject(this.project?.id!).subscribe((_) => {
          this.router.navigate(["/projects"]);
        });
      }
    });
  }
}
