import {AddingProductToCartRequestedAction, CartActionTypes, LoadCartAction, ProductAddedToCartAction} from "./actions";
import {CartProduct} from "../../cart/models/cart-product";
import {Cart} from "../../cart/models/cart";
import {AddProductToCartModel} from "../../cart/models/add-product";

type CartActions = LoadCartAction | AddingProductToCartRequestedAction | ProductAddedToCartAction;
export default function (state: Cart, action: CartActions) {
  switch (action.type) {
    case CartActionTypes.CartLoaded: {
      return action.payload;
    }
    case CartActionTypes.ProductAddedToCart: {
      return addProductToCart(state, action.payload as AddProductToCartModel);
    }
  }

  return state;
}


function addProductToCart(state: any, addedProduct: AddProductToCartModel) {

  const updatedState = {...state};
  const {product, quantity} = addedProduct;

  const productInCart = state.products[product.id];
  if (productInCart) {
    productInCart.quantity += quantity;
  } else {
    updatedState.products = {
      ...state.products,
      [product.id]: new CartProduct(product, quantity)
    };
  }

  updatedState.totalPrice += quantity * product.price;
  updatedState.totalProductsCount += quantity;

  return updatedState;
}
