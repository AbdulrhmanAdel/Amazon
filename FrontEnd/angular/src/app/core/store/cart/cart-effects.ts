import {Injectable} from "@angular/core";
import {Actions, createEffect, ofType} from "@ngrx/effects";
import {AddingProductToCartRequestedAction, CartActionTypes, ProductAddedToCartAction} from "./actions";
import {map, tap} from "rxjs";
import {CartService} from "../../cart/services/cart-service";

@Injectable()
export class CartEffects {
  constructor(
    private actions$: Actions,
    private cartService: CartService
  ) {
  }

  addProductToCart$ = createEffect(() => this.actions$.pipe(
      ofType<AddingProductToCartRequestedAction>(CartActionTypes.AddingProductToCartRequested),
      tap(cartProduct => this.cartService.addProductToCart(cartProduct.payload.product,
        cartProduct.payload.quantity)),
      map(cartProduct => new ProductAddedToCartAction(cartProduct.payload)
    )
  ));
}
