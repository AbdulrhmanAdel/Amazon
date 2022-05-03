import {AppState} from "../app-store";

import {
  CurrentUserLoadedAction,
  UserActionsTypes, UserLoggedInAction, UserLoggedOutAction, UserRequestToLoginAction, UserRequestToLogOutAction
} from "./actions";

export type UserActions =
  UserRequestToLoginAction |
  UserLoggedInAction |
  CurrentUserLoadedAction |
  UserRequestToLogOutAction |
  UserLoggedOutAction;


export default function (state: AppState, action: UserActions) {
  switch (action.type) {
    case UserActionsTypes.UserLoggedIn: {
      return {...action.payload}
    }
    case UserActionsTypes.CurrentUserLoaded: {
      return {...action.payload}
    }
    case UserActionsTypes.UserLoggedOut: {
      return null;
    }
  }

  return state;
}


