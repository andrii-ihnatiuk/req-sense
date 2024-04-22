import { HttpClient, HttpParams, HttpResponse } from "@angular/common/http";
import { Observable, map } from "rxjs";
import { appConfiguration } from "src/app/configuration/configuration-resolver";

export abstract class BaseService {
  constructor(private http: HttpClient) {}

  protected get<TResponseModel>(url: string): Observable<TResponseModel> {
    return this.interceptRequest(
      this.http.get<TResponseModel>(this.getFullUrl(url), {
        observe: "response",
      })
    );
  }

  protected getWithParams<TResponseModel>(
    url: string,
    params: HttpParams
  ): Observable<TResponseModel> {
    return this.interceptRequest(
      this.http.get<TResponseModel>(this.getFullUrl(url), {
        observe: "response",
        params: params,
      })
    );
  }

  protected post<TRequestModel, TResponseModel>(
    url: string,
    model: TRequestModel
  ): Observable<TResponseModel> {
    return this.interceptRequest(
      this.http.post<TResponseModel>(this.getFullUrl(url), model, {
        observe: "response",
      })
    );
  }

  protected put<TRequestModel, TResponseModel>(
    url: string,
    model: TRequestModel
  ): Observable<TResponseModel> {
    return this.interceptRequest(
      this.http.put<TResponseModel>(this.getFullUrl(url), model, {
        observe: "response",
      })
    );
  }

  protected delete<TResponseModel>(url: string): Observable<TResponseModel> {
    return this.interceptRequest(
      this.http.delete<TResponseModel>(this.getFullUrl(url), {
        observe: "response",
      })
    );
  }

  private interceptRequest<TResponseModel>(
    request: Observable<HttpResponse<TResponseModel>>
  ): Observable<TResponseModel> {
    return request.pipe(map((x) => x.body ?? ({} as TResponseModel)));
  }

  private getFullUrl(url: string) {
    return appConfiguration.baseApiUrl + url;
  }
}
