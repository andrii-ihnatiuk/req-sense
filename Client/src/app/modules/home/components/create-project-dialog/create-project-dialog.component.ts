import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { catchError } from 'rxjs';
import { Project } from 'src/app/core/models/Project';
import { ProjectService } from 'src/app/core/services/project.service';

@UntilDestroy()
@Component({
  selector: 'app-create-project-dialog',
  templateUrl: './create-project-dialog.component.html',
  styleUrl: './create-project-dialog.component.scss'
})
export class CreateProjectDialogComponent implements OnInit {

  form?: FormGroup;

  constructor(
    private dialog: MatDialogRef<CreateProjectDialogComponent>,
    private fb: FormBuilder,
    private projectService: ProjectService
  ) {
  }

  ngOnInit(): void {
    this.form = this.fb.group(
      {
        title: ['', Validators.required],
        description: ['', Validators.maxLength(200)]
      }
    );
  }

  getControl(name: string): FormControl {
    return this.form?.get(name) as FormControl;
  }

  submit() {
    if (this.form?.invalid) {
      alert("Form is invalid");
      return;
    }

    const project: Project = {
      title: this.form?.controls['title'].value,
      description: this.form?.controls['description'].value,
    };

    this.projectService.createProject(project)
      .pipe(
        untilDestroyed(this),
        catchError((err) => {
          this.dialog.close(null);
          throw err;
        }))
      .subscribe(result => {
        this.dialog.close(result.id);
      })
  }
}
