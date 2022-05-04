import {Component, OnInit} from '@angular/core';
import {NgForm} from "@angular/forms";
import {Store} from "@ngrx/store";
import {AddingProductToCartRequestedAction} from "../../core/store/cart/actions";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: Array<any>

  constructor(private store:Store) {
  }

  ngOnInit(): void {
    this.products = [
      this.generateProduct(), this.generateProduct(),
      this.generateProduct(), this.generateProduct(),
      this.generateProduct(), this.generateProduct(),
      this.generateProduct(), this.generateProduct(),
      this.generateProduct(), this.generateProduct(),
      this.generateProduct()]
  }

  id = 0;

  generateProduct() {
    this.id++;
    const idAsString = this.id.toString()
    return {
      id: idAsString,
      title: "product" + idAsString,
      description: "product is so good" + idAsString,
      imageUrl: `./assets/fake-api-asset/${idAsString}.jpg`,
      price: this.id * 50,
      quantityInStock: this.id * 2
    }

  }

  quantityLoopGenerator(length: number) {
    return new Array(length)
  }

  addToCart(
    product: any,
    addToCartForm: NgForm,
    $event: MouseEvent) {
    $event.preventDefault();
    this.store.dispatch(new AddingProductToCartRequestedAction({product: product,
      quantity: parseInt(addToCartForm.value.quantity)}))
  }
}
