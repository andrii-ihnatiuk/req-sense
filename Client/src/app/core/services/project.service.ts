import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Project } from "../models/Project";
import { Observable } from "rxjs";
import { appConfiguration } from "src/app/configuration/configuration-resolver";
import { environment } from "src/environments";
import { ProjectInsights } from "../models/ProjectInsights";
import { ProjectMember } from "../models/ProjectMember";

@Injectable({
  providedIn: "root",
})
export class ProjectService extends BaseService {
  constructor(http: HttpClient) {
    super(http);
  }

  getProjectsByUser(userId: string, filter: string): Observable<Project[]> {
    return this.getWithParams(
      appConfiguration.getUserProjectsApiUrl,
      new HttpParams({ fromObject: { userId, filter } })
    );
  }

  getProjectById(id: string): Observable<Project> {
    return this.get(
      appConfiguration.getProjectApiUrl.replace(environment.routeIdTemplate, id)
    );
  }

  getProjectInsights(id: string): Observable<ProjectInsights> {
    return this.get(
      appConfiguration.getProjectInsightsApiUrl.replace(
        environment.routeIdTemplate,
        id
      )
    );
  }

  getProjectMembers(id: string, limit?: number): Observable<ProjectMember[]> {
    return this.getWithParams(
      appConfiguration.getProjectMembersApiUrl.replace(
        environment.routeIdTemplate,
        id
      ),
      new HttpParams({ fromObject: { limit: limit ?? '' } })
    );
  }

  createProject(project: Project): Observable<any> {
    return this.post(appConfiguration.createProjectApiUrl, project);
  }
}
