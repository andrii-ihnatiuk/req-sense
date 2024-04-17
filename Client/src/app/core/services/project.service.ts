import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Project } from '../models/Project';
import { Observable, Subject } from 'rxjs';
import { appConfiguration } from 'src/app/configuration/configuration-resolver';

@Injectable({
  providedIn: 'root'
})
export class ProjectService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
  }

  getProjectsByUser(userId: string, filter: string): Observable<Project[]> {
    return this.getWithParams(appConfiguration.getUserProjectsApiUrl, new HttpParams({ fromObject: { userId, filter } }));
  }

  createProject(project: Project): Observable<any> {
    return this.post(appConfiguration.createProjectApiUrl, project);
  }
}
