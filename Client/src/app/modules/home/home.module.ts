import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ProjectsComponent } from './components/projects/projects.component';
import { HomeModuleComponent } from './components/home-module/home-module.component';
import { ActivityCardComponent } from './components/activity-card/activity-card.component';


@NgModule({
  declarations: [
    DashboardComponent,
    ProjectsComponent,
    HomeModuleComponent,
    ActivityCardComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule
  ]
})
export class HomeModule { }
