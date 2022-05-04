// Action Types
import {Action} from "@ngrx/store";
import {Cart} from "../../cart/models/cart";
import {AddProductToCartModel} from "../../cart/models/add-product";

export enum CartActionTypes {
  CartLoaded = "CartLoaded",
  AddingProductToCartRequested = "AddingProductToCartRequested",
  ProductAddedToCart = "ProductAddedToCart",
  ProductQuantityUpdated = "ProductQuantityUpdated"
}


// Actions
export class LoadCartAction implements Action {
  readonly type: string = CartActionTypes.CartLoaded;

  constructor(public payload: Cart) {
  }
}

export class AddingProductToCartRequestedAction implements Action {
  readonly type: string = CartActionTypes.AddingProductToCartRequested;

  constructor(public payload: AddProductToCartModel) {
  }
}

export class ProductAddedToCartAction implements Action {
  readonly type: string = CartActionTypes.ProductAddedToCart;

  constructor(public payload: AddProductToCartModel) {
  }
}

export class ProductQuantityUpdatedAction implements Action {
  readonly type: string = CartActionTypes.ProductQuantityUpdated;

  constructor(public payload: { productId: number, quantity: number, increase: boolean }) {
  }
}

