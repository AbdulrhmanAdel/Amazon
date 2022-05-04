import {Product} from "./add-product";

export class CartProduct {
  id: string;
  title: string;
  description: string;
  imageUrl: string;
  quantity: number;
  price: number;

  constructor(product: Product | null = null, quantity = 1) {
    if (product) {
      this.id = product.id;
      this.title = product.title;
      this.description = product.description;
      this.imageUrl = product.imageUrl;
      this.price = product.price;
    }
    this.quantity = quantity;
  }

}
