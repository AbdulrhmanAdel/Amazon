import {AppState} from "../app-store";

export const selectCurrentUser = (state: AppState) => {
  return state.currentUser?.id ? state.currentUser : null;
}

export const selectIfStoreHasCurrentUser = (state: AppState): boolean => {
  return !!selectCurrentUser(state)
}
