import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Requirement } from "src/app/core/models/Requirement";
import { RequirementService } from "src/app/core/services/requirement.service";

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
    private requirementService: RequirementService
  ) {
    this.requirementId = route.snapshot.params["requirementId"];
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
}
