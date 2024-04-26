import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { forkJoin } from "rxjs";
import { Project } from "src/app/core/models/Project";
import { ProjectInsights } from "src/app/core/models/ProjectInsights";
import { ProjectService } from "src/app/core/services/project.service";
import { MemberListItem } from "../members-list-item/MemberListItem";

@Component({
  selector: "app-project-home",
  templateUrl: "./project-home.component.html",
  styleUrl: "./project-home.component.scss",
})
export class ProjectHomeComponent implements OnInit {
  project?: Project;
  insights?: ProjectInsights;
  members?: MemberListItem[];

  private membersLimit: number = 5;

  constructor(
    private route: ActivatedRoute,
    private projectService: ProjectService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.params["projectId"];
    forkJoin({
      project: this.projectService.getProjectById(id),
      insights: this.projectService.getProjectInsights(id),
      members: this.projectService.getProjectMembers(id, this.membersLimit)
    })
    .subscribe((response) => {
      this.project = response.project;
      this.insights = response.insights;
      this.members = response.members.map(m => {
        const item: MemberListItem = {
          id: m.id,
          name: m.name,
          email: m.email,
          role: m.role,
          joinedDate: m.joinedDate,
        };
        return item;
      });
    });
  }
}
