import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectHomeComponent } from './components/project-home/project-home.component';
import { RequirementsComponent } from './components/requirements/requirements.component';
import { ProjectModuleComponent } from './components/project-module/project-module.component';

const routes: Routes = [
  {
    path: '',
    component: ProjectModuleComponent,
    children: [
      {
        path: '',
        component: ProjectHomeComponent
      },
      {
        path: 'requirements',
        component: RequirementsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
