import {Component, OnDestroy, OnInit} from '@angular/core';
import {UserService} from "../../core/account/services/user-service";
import {AppState, CurrentUser} from "../../core/store/app-store";
import {select, Store} from "@ngrx/store";
import {selectCurrentUser, selectIfStoreHasCurrentUser} from "../../core/store/user/selectors";
import {TokenService} from "../../core/account/services/token-service";
import {BehaviorSubject, interval} from "rxjs";
import {UserRequestToLogOutAction} from "../../core/store/user/actions";
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  loggedIn: boolean;
  currentLoggedInUser: CurrentUser;


  constructor(
    private router: Router,
    private store: Store<AppState>) {
  }

  ngOnInit(): void {
    this.store.pipe(select(selectCurrentUser)).subscribe(currentUser => {
      this.loggedIn = currentUser !== null;
      this.currentLoggedInUser = currentUser ?? new CurrentUser()
    })
  }


  logOut($event: MouseEvent) {
    $event.preventDefault();
    this.store.dispatch(new UserRequestToLogOutAction())
    this.router.navigateByUrl('/');
  }
}
