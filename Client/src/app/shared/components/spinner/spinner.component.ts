import { AsyncPipe, NgIf, NgTemplateOutlet } from "@angular/common";
import {
  Component,
  ContentChild,
  Input,
  OnInit,
  TemplateRef,
} from "@angular/core";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import {
  RouteConfigLoadEnd,
  RouteConfigLoadStart,
  Router,
} from "@angular/router";
import { Observable, tap } from "rxjs";
import { LoadingService } from "src/app/core/services/loading.service";

@Component({
  selector: "app-spinner",
  standalone: true,
  imports: [AsyncPipe, NgIf, NgTemplateOutlet, MatProgressSpinnerModule],
  templateUrl: "./spinner.component.html",
  styleUrl: "./spinner.component.scss",
})
export class SpinnerComponent implements OnInit {

  loading$: Observable<boolean>;

  @Input()
  detectRouteTransitions: boolean = false;

  @ContentChild("loading")
  customLoadingIndicator: TemplateRef<any> | null = null;

  constructor(private loadingService: LoadingService, private router: Router) {
    this.loading$ = this.loadingService.loading$;
  }

  ngOnInit() {
    if (this.detectRouteTransitions) {
      this.router.events
        .pipe(
          tap((event) => {
            if (event instanceof RouteConfigLoadStart) {
              this.loadingService.loadingOn();
            } else if (event instanceof RouteConfigLoadEnd) {
              this.loadingService.loadingOff();
            }
          })
        )
        .subscribe();
    }
  }
}
