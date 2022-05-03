import {Component, OnDestroy, OnInit} from '@angular/core';
import {UserService} from "./core/account/services/user-service";
import {Store} from "@ngrx/store";
import {AppState} from "./core/store/app-store";
import {delay, Subject, take, takeUntil} from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'E-Shop';
  private unsubscribe = new Subject();
  constructor(
    private store: Store<AppState>,
    private userService: UserService) {
  }

  ngOnInit() {
    console.log("Initialize App")
    if (this.userService.isLoggedIn()) {
      console.log("User Logged In Already Refresh Store with his data")
      this.userService.loadCurrentUser().pipe(take(1), takeUntil(this.unsubscribe)).subscribe()
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe.next(0);
    this.unsubscribe.complete();
  }
}
