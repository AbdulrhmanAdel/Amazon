import {Cart} from "../cart/models/cart";

export class AppState {
  cart: Cart;
  currentUser: CurrentUser
}

export class CurrentUser {
  id: string;
  displayName: string;
  email: string;
}

