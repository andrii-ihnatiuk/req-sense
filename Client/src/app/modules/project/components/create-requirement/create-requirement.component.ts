import {
  animate,
  query,
  stagger,
  state,
  style,
  transition,
  trigger,
} from "@angular/animations";
import { Component, ElementRef, ViewChild } from "@angular/core";
import { MatSlideToggleChange } from "@angular/material/slide-toggle";

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
export class CreateRequirementComponent {
  @ViewChild("aiBlock")
  aiBlock?: ElementRef;

  enableAiHelp: boolean = true;

  questions: string[] = [
    "Can user like others' comments?",
    "Can user reply to other comments?",
  ];

  onAiHelpToggle(toggle: MatSlideToggleChange): void {
    this.enableAiHelp = toggle.checked;
  }
}
