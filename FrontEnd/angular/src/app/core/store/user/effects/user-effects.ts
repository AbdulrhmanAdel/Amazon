import {Injectable} from "@angular/core";
import {Actions, createEffect, ofType} from '@ngrx/effects';
import {UserService} from "../../../account/services/user-service";

import {map, mergeMap, tap} from "rxjs";
import {TokenService} from "../../../account/services/token-service";
import {
  UserActionsTypes,
  UserLoggedInAction,
  UserLoggedOutAction,
  UserRequestedToSignUp,
  UserRequestToLoginAction, UserRequestToLogOutAction
} from "../actions";

@Injectable()
export class UserEffects {
  constructor(
    private actions$: Actions,
    private userService: UserService,
    private tokenService: TokenService) {
  }

  logIn$ = createEffect(() =>
    this.actions$.pipe(
      ofType<UserRequestToLoginAction>(UserActionsTypes.UserRequestedToLogin),
      mergeMap(userModel =>
        this.userService.logIn(userModel.payload)
        .pipe(map(userModel => userModel.data))),
      tap(data => {
        this.tokenService.saveToken(data.token, data.rememberPassword);
      }),
      map(data => new UserLoggedInAction(data)))
  )

  signUp$ = createEffect(() =>
    this.actions$.pipe(
      ofType<UserRequestedToSignUp>(UserActionsTypes.UserRequestedToSignUp),
      mergeMap(userModel => {
          return this.userService.signUp(userModel.payload)
            .pipe(map(response => response.data))
        }
      ),
      tap(result => {
        this.tokenService.saveToken(result.token, result.rememberPassword);
      }),
      map(data => new UserLoggedInAction(data)))
  )

  logOut$ = createEffect(() =>
    this.actions$.pipe(
      ofType<UserRequestToLogOutAction>(UserActionsTypes.UserRequestToLogOutAction),
      tap(data => this.userService.logOut()),
      map(data => new UserLoggedOutAction()))
    );
}
