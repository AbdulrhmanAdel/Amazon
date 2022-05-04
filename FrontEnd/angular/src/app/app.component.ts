import {Component, OnDestroy, OnInit} from '@angular/core';
import {UserService} from "./core/account/services/user-service";
import {Store} from "@ngrx/store";
import {AppState} from "./core/store/app-store";
import {Subject, take, takeUntil} from "rxjs";
import {CartService} from "./core/cart/services/cart-service";
import {LoadCartAction} from "./core/store/cart/actions";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {

  private unsubscribe = new Subject();

  constructor(
    private cartService: CartService,
    private store: Store<AppState>,
    private userService: UserService) {
  }

  ngOnInit() {
    console.log("Initialize App")
    if (this.userService.isLoggedIn()) {
      this.userService.loadCurrentUser().pipe(take(1), takeUntil(this.unsubscribe)).subscribe()
    }

    this.cartService.loadCart()
      .pipe(take(1), takeUntil(this.unsubscribe))
      .subscribe(cart => {
        this.store.dispatch(new LoadCartAction(cart))
      })
  }

  ngOnDestroy(): void {
    this.unsubscribe.next(0);
    this.unsubscribe.complete();
  }
}
