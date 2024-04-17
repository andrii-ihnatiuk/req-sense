import { APP_INITIALIZER, ErrorHandler, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { provideAnimationsAsync } from "@angular/platform-browser/animations/async";
import { resolveConfiguration } from "./configuration/configuration-resolver";
import {
  HTTP_INTERCEPTORS,
  HttpClientModule,
  provideHttpClient,
  withInterceptors,
} from "@angular/common/http";
import { AuthInterceptor } from "./core/services/auth.interceptor";
import { GlobalErrorHandlerService } from "./core/services/error-handler";
import { SpinnerComponent } from "./shared/components/spinner/spinner.component";
import { loadingInterceptor } from "./core/services/loading.interceptor";

@NgModule({
  declarations: [AppComponent],
  providers: [
    {
      provide: APP_INITIALIZER,
      multi: true,
      useFactory: () => resolveConfiguration,
    },
    {
      provide: HTTP_INTERCEPTORS,
      multi: true,
      useClass: AuthInterceptor,
    },
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandlerService,
    },
    provideAnimationsAsync(),
    provideHttpClient(withInterceptors([loadingInterceptor])),
  ],
  bootstrap: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SpinnerComponent,
  ],
})
export class AppModule {}
