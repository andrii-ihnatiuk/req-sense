import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { HttpClient } from "@angular/common/http";
import { Requirement } from "../models/Requirement";
import { Observable } from "rxjs";
import { appConfiguration } from "../../configuration/configuration-resolver";
import { environment } from "src/environments";

@Injectable({
  providedIn: "root",
})
export class RequirementService extends BaseService {
  constructor(http: HttpClient) {
    super(http);
  }

  getProjectRequirements(projectId: string): Observable<Requirement[]> {
    return this.get(
      appConfiguration.getRequirementsByProjectApiUrl.replace(
        environment.routeIdTemplate,
        projectId
      )
    );
  }

  getRequirementById(id: string): Observable<Requirement> {
    return this.get(
      appConfiguration.getRequirementByIdApiUrl.replace(
        environment.routeIdTemplate,
        id
      )
    );
  }

  createRequirement(model: Requirement): Observable<{ id: string }> {
    return this.post(
      appConfiguration.createRequirementApiUrl.replace(
        environment.routeIdTemplate,
        model.projectId
      ),
      model
    );
  }

  deleteRequirement(id: string): Observable<any> {
    return this.delete(
      appConfiguration.deleteRequirementApiUrl.replace(
        environment.routeIdTemplate,
        id
      )
    );
  }
}
