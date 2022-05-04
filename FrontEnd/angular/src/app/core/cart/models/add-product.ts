export class AddProductToCartModel {
  product: Product;
  quantity: number;
}


export class Product {
  price: number;
  id: string;
  title: string;
  description: string;
  imageUrl: string;
}
