import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { appConfiguration } from "src/app/configuration/configuration-resolver";

@Injectable({
  providedIn: "root",
})
export class SuggestionService extends BaseService {
  constructor(http: HttpClient) {
    super(http);
  }

  getRequirementQuestions(requirementText: string, projectId: string): Observable<any> {
    return this.getWithParams(
      appConfiguration.getQuestionsForRequirementApiUrl,
      new HttpParams({ fromObject: { projectId, requirementText } }),
      true
    );
  }

  getSuggestedRequirementTitle(requirementText: string): Observable<string> {
    return this.getWithParams(
      appConfiguration.getSuggestedRequirementTitleApiUrl,
      new HttpParams({ fromObject: { requirementText } })
    )
  }
}
