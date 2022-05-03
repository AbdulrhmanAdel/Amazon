export class AppState {
  cart: Card;
  currentUser: CurrentUser
}

export class CurrentUser {
  id: string;
  displayName: string;
  email: string;
}

export class Card {
  products: [];
  ids: [];
  totalPrice: number
}
