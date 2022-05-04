import {Component, OnInit} from '@angular/core';
import {AppState, CurrentUser} from "../../core/store/app-store";
import {Store} from "@ngrx/store";
import {UserRequestToLogOutAction} from "../../core/store/user/actions";
import {Router} from "@angular/router";
import {Cart} from "../../core/cart/models/cart";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  loggedIn: boolean;
  currentLoggedInUser: CurrentUser;
  cart: Cart;

  constructor(
    private router: Router,
    private store: Store<AppState>) {
  }

  ngOnInit(): void {
    this.store
      .subscribe(state => {
        const currentUser = state.currentUser;
        this.cart = state.cart;
        this.loggedIn = currentUser !== null;
        this.currentLoggedInUser = currentUser ?? new CurrentUser()
      })
  }


  logOut($event: MouseEvent) {
    $event.preventDefault();
    this.store.dispatch(new UserRequestToLogOutAction())
    this.router.navigateByUrl('/');
  }

  showMobileNav() {

  }
}
