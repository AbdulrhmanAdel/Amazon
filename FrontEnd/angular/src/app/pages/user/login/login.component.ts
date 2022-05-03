import {Component, OnInit, ViewChild} from '@angular/core';
import {AppState} from "../../../core/store/app-store";
import {Store} from "@ngrx/store";
import {selectIfStoreHasCurrentUser} from "../../../core/store/user/selectors";
import {Route, Router} from "@angular/router";
import {NgForm} from "@angular/forms";
import {UserService} from "../../../core/account/services/user-service";
import {UserRequestToLoginAction} from "../../../core/store/user/actions";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(
    private store: Store<AppState>,
    private route: Router
  ) {
  }

  ngOnInit(): void {
    this.store.select(selectIfStoreHasCurrentUser).subscribe(isLoggedIn => {
      if (isLoggedIn) {
        this.route.navigateByUrl('/');
      }
    })
  }

  logIn(loggingForm: NgForm) {
    const value = loggingForm.value;
    value.rememberPassword = !!value.rememberPassword;
    this.store.dispatch(new UserRequestToLoginAction(value));
  }
}
