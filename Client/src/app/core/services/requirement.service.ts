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

  createRequirement(model: Requirement): Observable<any> {
    return this.post(
      appConfiguration.createRequirementApiUrl.replace(
        environment.routeIdTemplate,
        model.projectId
      ),
      model
    );
  }
}
