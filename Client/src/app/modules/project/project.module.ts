import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectRoutingModule } from './project-routing.module';
import { ProjectHomeComponent } from './components/project-home/project-home.component';
import { SharedModule } from "../../shared/shared.module";
import { RequirementsComponent } from './components/requirements/requirements.component';
import { ProjectModuleComponent } from './components/project-module/project-module.component';
import { MembersListComponent } from './components/members-list/members-list.component';
import { MembersListItemComponent } from './components/members-list-item/members-list-item.component';
import { RequirementsListComponent } from './components/requirements-list/requirements-list.component';
import { RequirementsListItemComponent } from './components/requirements-list-item/requirements-list-item.component';
import { MembersComponent } from './components/members/members.component';
import { ProjectSettingsComponent } from './components/project-settings/project-settings.component';


@NgModule({
    declarations: [
        ProjectHomeComponent,
        RequirementsComponent,
        ProjectModuleComponent,
        MembersListComponent,
        MembersListItemComponent,
        RequirementsListComponent,
        RequirementsListItemComponent,
        MembersComponent,
        ProjectSettingsComponent
    ],
    imports: [
        CommonModule,
        ProjectRoutingModule,
        SharedModule
    ]
})
export class ProjectModule { }
