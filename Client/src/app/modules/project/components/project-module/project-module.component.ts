import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MenuItem } from 'src/app/core/models/MenuItem';

@Component({
  selector: 'app-project-module',
  templateUrl: './project-module.component.html',
  styleUrl: './project-module.component.scss'
})
export class ProjectModuleComponent {

  routeParam: string;
  sideBarMenuItems: MenuItem[] = [
    {
      title: 'Home',
      icon: 'home',
      link: './'
    },
    {
      title: 'Requirements',
      icon: 'article',
      link: 'requirements'
    }
  ]

  constructor(route: ActivatedRoute) {
    this.routeParam = route.snapshot.params['id'];
  }
}
