import {CartProduct} from "./cart-product";

export class Cart {
  products: Map<string, CartProduct>;
  ids: [];
  totalProductsCount: number;
  totalPrice: number

  constructor() {
    this.products = new Map<string, CartProduct>();
    this.ids = [];
    this.totalProductsCount = 0;
    this.totalPrice = 0;
  }
}
