import {Injectable} from "@angular/core";
import {Observable, of} from "rxjs";
import {Cart} from "../models/cart";
import {CartProduct} from "../models/cart-product";
import {Product} from "../models/add-product";

@Injectable({providedIn: 'root'})
export class CartService {
  constructor() {
  }

  loadCart(): Observable<Cart> {
    const cart = this.fetchCart();
    return of(cart);
  }

  addProductToCart(product: Product, quantity: number) {
    const cart = this.fetchCart() as Cart;
    let products: Map<string, CartProduct> = typeof cart.products === 'object' ?
      new Map<string, CartProduct>() :
      cart.products;

    console.log(cart)
    const productInCart = products.get(product.id);
    if (productInCart) {
      productInCart.quantity += quantity;
    } else {
      products.set(product.id, new CartProduct(product, quantity));
    }
    cart.totalPrice += quantity * product.price;
    cart.totalProductsCount += quantity;
    cart.products = products;
    this.saveCart(cart);
    return of(true);
  }

  removeProductFromCart(productId: string, quantity: number) {
    const cart = this.fetchCart();
  }

  public saveCart(cart: Cart) {
    localStorage.setItem('cart', JSON.stringify(cart));
  }

  private fetchCart(): Cart {
    const loadedCart = localStorage.getItem('cart');
    if (loadedCart) {
      return JSON.parse(loadedCart);
    }
    const cart =  new Cart();
    this.saveCart(cart);
    return cart;
  }
}
