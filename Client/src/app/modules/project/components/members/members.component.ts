import { Component, OnInit } from "@angular/core";
import { ProjectService } from "src/app/core/services/project.service";
import { MemberListItem } from "../members-list-item/MemberListItem";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-members",
  templateUrl: "./members.component.html",
  styleUrl: "./members.component.scss",
})
export class MembersComponent implements OnInit {
  members?: MemberListItem[];

  options = [
    { value: "all", label: "All" },
    { value: "own", label: "Own" },
  ];

  constructor(
    private projectService: ProjectService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const projectId = this.route.parent?.snapshot.params["id"];
    this.projectService.getProjectMembers(projectId).subscribe((members) => {
      this.members = members.map((m) => {
        const member: MemberListItem = {
          id: m.id,
          name: m.name,
          email: m.email,
          role: m.role,
          joinedDate: m.joinedDate,
        };
        return member;
      });
    });
  }
}
