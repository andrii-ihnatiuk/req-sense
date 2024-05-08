import {
  animate,
  query,
  stagger,
  state,
  style,
  transition,
  trigger,
} from "@angular/animations";
import { Component, OnInit } from "@angular/core";
import { MatSlideToggleChange } from "@angular/material/slide-toggle";
import { UntilDestroy, untilDestroyed } from "@ngneat/until-destroy";
import { catchError, debounceTime, of, Subject, switchMap, tap } from "rxjs";
import { SuggestionService } from "src/app/core/services/suggestion.service";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { Requirement } from "../../../../core/models/Requirement";
import { RequirementService } from "../../../../core/services/requirement.service";
import { ActivatedRoute, Router } from "@angular/router";

@UntilDestroy()
@Component({
  selector: "app-create-requirement",
  templateUrl: "./create-requirement.component.html",
  styleUrl: "./create-requirement.component.scss",
  animations: [
    trigger("aiQuestions", [
      state(
        "visible",
        style({
          opacity: 1,
        })
      ),
      state(
        "invisible",
        style({
          opacity: 0,
          display: "none",
        })
      ),
      transition("visible => invisible", [animate(".2s 0s ease")]),
      transition("invisible => visible", [animate(".3s 0s ease-in")]),
    ]),
    trigger("fadeInGrow", [
      transition(":enter", [
        query("app-card", [
          style({ opacity: 0, transform: "scale(0.8)" }),
          stagger(".1s", [
            animate(".2s", style({ opacity: 1, transform: "scale(1)" })),
          ]),
        ]),
      ]),
    ]),
  ],
})
export class CreateRequirementComponent implements OnInit {
  enableAiHelp: boolean = true;
  isLoading: boolean = false;

  questions: string[] = [];

  requirementChangeSubject = new Subject<string>();

  form?: FormGroup;

  projectId: string;

  constructor(
    private suggestionService: SuggestionService,
    private requirementService: RequirementService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.projectId = this.route.parent?.snapshot.params["projectId"];
  }

  ngOnInit(): void {
    this.buildForm();

    this.requirementChangeSubject
      .pipe(
        untilDestroyed(this),
        debounceTime(1800),
        tap(() => (this.isLoading = true)),
        switchMap((requirementText) =>
          this.suggestionService
            .getRequirementQuestions(requirementText, this.projectId, )
            .pipe(catchError((_) => of({ questions: []})))
        )
      )
      .subscribe((response) => {
        this.questions = response.questions;
        this.isLoading = false;
      });
  }

  getControl(name: string): FormControl {
    return this.form?.controls[name] as FormControl;
  }

  onAiHelpToggle(toggle: MatSlideToggleChange): void {
    this.enableAiHelp = toggle.checked;
  }

  onRequirementChanged(event: any): void {
    if (this.enableAiHelp && event.target.value.length > 0) {
      this.requirementChangeSubject.next(event.target.value);
    }
  }

  onSaveRequirement(): void {
    if (this.form?.invalid) {
      alert("Form is invalid");
      return;
    }

    const requirement: Requirement = {
      title: this.getControl("title").value.trim(),
      description: this.getControl("description").value.trim(),
      projectId: this.projectId,
    };

    this.requirementService
      .createRequirement(requirement)
      .subscribe((response) => {
        if (response.id) {
          this.router.navigate(["/projects", this.projectId, "requirements"]);
        }
      });
  }

  private buildForm(): void {
    this.form = this.fb.group({
      title: ["", [Validators.required, Validators.maxLength(30)]],
      description: ["", [Validators.required, Validators.maxLength(4000)]],
    });
  }
}
