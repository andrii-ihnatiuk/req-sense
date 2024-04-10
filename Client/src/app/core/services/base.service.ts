import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { appConfiguration } from 'src/app/configuration/configuration-resolver';

export abstract class BaseService {

  constructor(private http: HttpClient) { }

  protected get<TResponseModel>(url: string): Observable<TResponseModel> {
    return this.interceptRequest(
      this.http.get<TResponseModel>(this.getFullUrl(url), { observe: 'response' })
    );
  }

  protected post<TRequestModel, TResponseModel>(
      url: string,
      model: TRequestModel
    ): Observable<TResponseModel> {
    return this.interceptRequest(
      this.http.post<TResponseModel>(this.getFullUrl(url), model, { observe: 'response' })
    );
  }

  private interceptRequest<TResponseModel>(
    request: Observable<HttpResponse<TResponseModel>>
  ): Observable<TResponseModel> {
    return request.pipe(
      map(x => x.body ?? {} as TResponseModel)
    );
  }

  private getFullUrl(url: string) {
    return appConfiguration.baseApiUrl + url;
  }
}
