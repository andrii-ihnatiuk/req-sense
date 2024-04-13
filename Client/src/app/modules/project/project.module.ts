import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectRoutingModule } from './project-routing.module';
import { ProjectHomeComponent } from './components/project-home/project-home.component';
import { SharedModule } from "../../shared/shared.module";
import { RequirementsComponent } from './components/requirements/requirements.component';
import { ProjectModuleComponent } from './components/project-module/project-module.component';
import { MembersListComponent } from './components/members-list/members-list.component';
import { MembersListItemComponent } from './components/members-list-item/members-list-item.component';


@NgModule({
    declarations: [
        ProjectHomeComponent,
        RequirementsComponent,
        ProjectModuleComponent,
        MembersListComponent,
        MembersListItemComponent
    ],
    imports: [
        CommonModule,
        ProjectRoutingModule,
        SharedModule
    ]
})
export class ProjectModule { }
