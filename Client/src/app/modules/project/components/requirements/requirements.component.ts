import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { RequirementService } from "src/app/core/services/requirement.service";
import { RequirementListItem } from "../requirements-list-item/RequirementListItem";

@Component({
  selector: "app-requirements",
  templateUrl: "./requirements.component.html",
  styleUrl: "./requirements.component.scss",
})
export class RequirementsComponent implements OnInit {
  options = [
    { value: "all", label: "All" },
    { value: "own", label: "Own" },
  ];

  projectId: string;

  requirements: RequirementListItem[] = [];

  constructor(
    private route: ActivatedRoute,
    private requirementService: RequirementService
  ) {
    this.projectId = this.route.parent?.snapshot.params["projectId"];
  }

  ngOnInit(): void {
    if (!this.projectId) {
      throw new Error("Project id parameter not available");
    }

    this.requirementService
      .getProjectRequirements(this.projectId)
      .pipe()
      .subscribe((requirements) => {
        this.requirements = requirements.map((r) => {
          const listItem: RequirementListItem = {
            id: r.id!,
            title: r.title,
            createdDate: r.created!,
            owner: r.creatorName!,
          };
          return listItem;
        });
      });
  }
}
