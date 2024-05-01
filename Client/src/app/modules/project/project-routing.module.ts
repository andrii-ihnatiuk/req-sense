import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ProjectHomeComponent } from "./components/project-home/project-home.component";
import { RequirementsComponent } from "./components/requirements/requirements.component";
import { ProjectModuleComponent } from "./components/project-module/project-module.component";
import { MembersComponent } from "./components/members/members.component";
import { ProjectSettingsComponent as ProjectSettingsComponent } from "./components/project-settings/project-settings.component";
import { CreateRequirementComponent } from "./components/create-requirement/create-requirement.component";
import { ViewRequirementComponent } from "./components/view-requirement/view-requirement.component";
import { UpdateRequirementComponent } from "./components/update-requirement/update-requirement.component";

const routes: Routes = [
  {
    path: "",
    component: ProjectModuleComponent,
    children: [
      {
        path: "",
        component: ProjectHomeComponent,
      },
      {
        path: "requirements",
        component: RequirementsComponent,
      },
      {
        path: "members",
        component: MembersComponent,
      },
      {
        path: "settings",
        component: ProjectSettingsComponent,
      },
      {
        path: "requirements/new",
        component: CreateRequirementComponent,
      },
      {
        path: "requirements/view/:requirementId",
        component: ViewRequirementComponent
      },
      {
        path: "requirements/edit/:requirementId",
        component: UpdateRequirementComponent
      }
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProjectRoutingModule {}
