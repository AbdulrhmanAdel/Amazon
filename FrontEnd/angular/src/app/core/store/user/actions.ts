import {Action} from "@ngrx/store";
import {UserLoginModel} from "../../account/models/user-login-model";
import {CurrentUser} from "../app-store";
import {UserSignupModel} from "../../account/models/user-signup-model";

// Actions Type
export enum UserActionsTypes {
  UserRequestedToLogin = "UserRequestedToLogin",
  UserLoggedIn = "UserLoggedIn",
  UserRequestedToSignUp = "UserRequestedToSignUp",
  CurrentUserLoaded = "CurrentUserLoaded",
  UserLoggedOut = "UserLoggedOutAction",
  UserRequestToLogOutAction = "UserRequestToLogOutAction"
}

// Actions
export class UserRequestToLoginAction implements Action {
  readonly type = UserActionsTypes.UserRequestedToLogin

  constructor(public payload: UserLoginModel) {
  }
}
export class CurrentUserLoadedAction implements Action {
  readonly type = UserActionsTypes.CurrentUserLoaded

  constructor(public payload: CurrentUser) {
  }
}
export class UserRequestedToSignUp implements Action {
  readonly type = UserActionsTypes.UserRequestedToSignUp

  constructor(public payload: UserSignupModel) {
  }
}

export class UserRequestToLogOutAction implements Action {
  readonly type = UserActionsTypes.UserRequestToLogOutAction

  constructor() {
  }
}

export class UserLoggedOutAction implements Action {
  readonly type = UserActionsTypes.UserLoggedOut

  constructor() {
  }
}
export class UserLoggedInAction implements Action {
  readonly type = UserActionsTypes.UserLoggedIn

  constructor(public payload: { id: string, token: string }) {}
}



